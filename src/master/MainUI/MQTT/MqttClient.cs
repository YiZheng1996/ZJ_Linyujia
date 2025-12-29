using MainUI.MQTT;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Newtonsoft.Json;
using System.Text;

namespace MainUI.MQTT
{
    /// <summary>
    /// MQTT 接口客户端
    /// </summary>
    public class MqttClient : IDisposable
    {
        public MqttConfig _config;

        private readonly IMqttClient _mqttClient;
        private MqttClientOptions _mqttOptions;

        private int _reconnectAttempts = 0;
        private const int MaxReconnectAttempts = 100; // 最多尝试次数
        private const int ReconnectDelayMilliseconds = 6000; // 每次失败后延迟

        // 已连接异步
        public Func<MqttClientConnectedEventArgs, Task> mqttClient_ConnectedAsync;

        // 消息处理相关
        public event Action<string, string> MessageReceived;

        public bool Communication { get => _mqttClient.IsConnected; set { } }

        public MqttClient(MqttConfig _config)
        {
            this._config = _config ??
                throw new ArgumentNullException(nameof(_config), "MQTT配置不能为空。");
            var factory = new MqttFactory();

            _mqttClient = factory.CreateMqttClient();

            // 设置连接处理程序（连接后需要订阅）
            _mqttClient.ConnectedAsync += _MqttClient_ConnectedAsync;

            // 断开后重连
            _mqttClient.DisconnectedAsync += _MqttClient_DisconnectedAsync;

            // 设置消息接收处理程序
            _mqttClient.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
        }

        /// <summary>
        /// 断开后重连
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private async Task _MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            // 订阅测试主题
            var testTopics = new[]
            {
        $"$di/devices/{_config.EquipmentCode}/energy/task/response",
        $"$di/devices/{_config.EquipmentCode}/fault/task/response",
        $"$di/devices/{_config.EquipmentCode}/+/response",  // 通配符订阅
        $"$di/devices/+/energy/response"  // 订阅所有设备的能耗响应
    };

            foreach (var topic in testTopics)
            {
                try
                {
                    await SubscribeAsync(topic);
                    NlogHelper.Default.Info($"成功订阅主题: {topic}");
                }
                catch (Exception ex)
                {
                    NlogHelper.Default.Error($"订阅主题失败 {topic}: {ex.Message}");
                }
            }

            await (mqttClient_ConnectedAsync?.Invoke(arg) ?? Task.CompletedTask);
        }

        private async Task _MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            NlogHelper.Default.Info("MQTT连接被断开，准备自动重连...");

            await _mqttClient.DisconnectAsync(new MqttClientDisconnectOptions { ReasonString = "Reconnecting" });

            if (!_mqttClient.IsConnected && _reconnectAttempts < MaxReconnectAttempts)
            {
                try
                {
                    _reconnectAttempts++;
                    NlogHelper.Default.Info($"第 {_reconnectAttempts} 次重连尝试...");
                    await Task.Delay(ReconnectDelayMilliseconds); // 可扩展成指数退避
                    await ConnectAsync();
                }
                catch (Exception ex)
                {
                    NlogHelper.Default.Info($"重连失败（第 {_reconnectAttempts} 次）：{ex.Message}");
                }
            }

            // 如果重连次数超过最大限制，记录日志或触发报警
            if (!_mqttClient.IsConnected && _reconnectAttempts >= MaxReconnectAttempts)
            {
                NlogHelper.Default.Info("MQTT重连超过最大次数！");
            }
        }

        // 接收消息处理
        private Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            if (arg.ApplicationMessage.Retain) return Task.CompletedTask;
            var topic = arg.ApplicationMessage.Topic;
            var payload = Encoding.UTF8.GetString(arg.ApplicationMessage.PayloadSegment.Array ?? []);
            //NlogHelper.Default.Info($"接收到消息: 主题={topic}, 内容={payload}");
            MessageReceived?.Invoke(topic, payload);

            //var message = JsonSerializer.Deserialize<ProductionModelUpdateMessage>(payload);
            //OnProductionModelUpdate?.Invoke(this, message);

            return Task.CompletedTask;
        }


        /// <summary>
        /// 连接到 MQTT 服务器。
        /// </summary>
        /// <returns>表示异步操作的任务。</returns>
        public async Task ConnectAsync()
        {
            if (Communication) return;

            _mqttOptions = new MqttClientOptionsBuilder()
              .WithTcpServer(_config.IPAddress, _config.IPPort.ToInt())
              .WithClientId(_config.ClientId)
              .WithCredentials(_config.EquipmentCode, _config.MqttPassWord)
              .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
              .WithProtocolVersion(MqttProtocolVersion.V500)
              .WithCleanSession()
              .Build();

            try
            {
                await _mqttClient.ConnectAsync(_mqttOptions);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Info($"目标计算机拒绝连接，请检查服务器状态！{ex.Message}");
                return;
            }
            VarHelper.Communication = Communication = true;
            _reconnectAttempts = 0; // 重置重连次数
            NlogHelper.Default.Info("MQTT客户端已连接.");
        }

        /// <summary>
        /// 订阅指定的主题。
        /// </summary>
        /// <param name="topic">要订阅的主题。</param>
        /// <returns>表示异步操作的任务。</returns>
        public async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            NlogHelper.Default.Info($"订阅主题: {topic}");
        }

        /// <summary>
        /// 取消订阅指定的主题。
        /// </summary>
        /// <param name="topic">要取消订阅的主题。</param>
        /// <returns>表示异步操作的任务。</returns>
        public async Task UnsubscribeAsync(string topic)
        {
            await _mqttClient.UnsubscribeAsync(topic);
            NlogHelper.Default.Info($"取消订阅主题: {topic}");
        }

        /// <summary>
        /// 发布消息到指定的主题（推荐版本）
        /// </summary>
        /// <param name="topic">要发布消息的主题</param>
        /// <param name="message">要发布的消息</param>
        /// <returns>发布结果</returns>
        public async Task<PublishResult> PublishAsync(string topic, string message)
        {
            if (!Communication)
            {
                NlogHelper.Default.Info("MQTT客户端未连接，无法发布消息");
                return PublishResult.Failure("MQTT客户端未连接");
            }

            try
            {
                // 步骤1: 验证输入参数
                if (string.IsNullOrEmpty(topic))
                {
                    return PublishResult.Failure("主题不能为空");
                }

                if (string.IsNullOrEmpty(message))
                {
                    return PublishResult.Failure("消息内容不能为空");
                }

                // 步骤2: 清理和验证消息内容
                var cleanedMessage = CleanMessageContent(message);
                if (string.IsNullOrEmpty(cleanedMessage))
                {
                    return PublishResult.Failure("消息内容清理后为空");
                }

                // 步骤3: 检查消息大小
                var messageBytes = Encoding.UTF8.GetBytes(cleanedMessage);
                if (messageBytes.Length > 1024 * 1024) // 1MB 限制
                {
                    NlogHelper.Default.Warn($"消息过大: {messageBytes.Length} bytes");
                    return PublishResult.Failure($"消息过大: {messageBytes.Length} bytes，超过1MB限制");
                }

                NlogHelper.Default.Info($"准备发布消息 - 主题: {topic}, 消息长度: {messageBytes.Length} bytes");

                // 步骤4: 创建MQTT消息
                var mqttMessage = new MqttApplicationMessageBuilder()
                                     .WithTopic(topic)
                                     .WithPayload(messageBytes) // 直接使用字节数组而不是字符串
                                     //.WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                                     .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                                     .Build();

                // 步骤5: 发布消息并处理结果
                var result = await _mqttClient.PublishAsync(mqttMessage);

                // 步骤6: 详细的结果日志
                string statusMessage = $"发布消息结果 - 主题: {topic}, 状态: {result.ReasonCode}";

                if (result.ReasonCode == MqttClientPublishReasonCode.Success)
                {
                    NlogHelper.Default.Info($"{statusMessage} - 成功");
                    return PublishResult.Success(result);
                }
                else
                {
                    NlogHelper.Default.Error($"{statusMessage} - 失败 {GetReasonCodeDescription(result.ReasonCode)}");
                    return PublishResult.Failure($"发布失败: {result.ReasonCode} - {GetReasonCodeDescription(result.ReasonCode)}");
                }
            }
            catch (ArgumentException argEx)
            {
                string error = $"参数错误: {argEx.Message}";
                NlogHelper.Default.Error(error);
                return PublishResult.Failure(error);
            }
            catch (InvalidOperationException ioEx)
            {
                string error = $"操作无效: {ioEx.Message}";
                NlogHelper.Default.Error(error);
                return PublishResult.Failure(error);
            }
            catch (FormatException formatEx)
            {
                string error = $"格式错误: {formatEx.Message} - 这可能是你遇到的错误!";
                NlogHelper.Default.Error($"{error}\n消息内容长度: {message?.Length ?? 0}");
                return PublishResult.Failure(error);
            }
            catch (Exception ex)
            {
                string error = $"发布消息错误: {ex.GetType().Name} - {ex.Message}";
                NlogHelper.Default.Error($"{error}\n堆栈跟踪: {ex.StackTrace}");
                return PublishResult.Failure(error);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public async Task DisconnectAsync()
        {
            if (_mqttClient != null && Communication)
            {
                await _mqttClient.DisconnectAsync();
                Communication = false;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            DisconnectAsync().Wait();
            _mqttClient?.Dispose();
        }

        // 清理消息内容
        private static string CleanMessageContent(string message)
        {
            if (string.IsNullOrEmpty(message))
                return string.Empty;

            var cleanedBuilder = new StringBuilder(message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];

                // 移除或替换问题字符
                if (char.IsControl(c))
                {
                    // 保留常见的控制字符
                    if (c == '\n' || c == '\r' || c == '\t')
                    {
                        cleanedBuilder.Append(c);
                    }
                    // 跳过其他控制字符
                }
                else if (c == '\0') // 空字符
                {
                    // 跳过空字符
                }
                else
                {
                    cleanedBuilder.Append(c);
                }
            }

            string cleaned = cleanedBuilder.ToString();

            // 验证清理后的字符串是否为有效的UTF-8
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(cleaned);
                string reconstructed = Encoding.UTF8.GetString(bytes);
                return reconstructed;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"UTF-8编码验证失败: {ex.Message}");
                return string.Empty;
            }
        }

        // 获取错误代码的描述
        private static string GetReasonCodeDescription(MqttClientPublishReasonCode reasonCode)
        {
            return reasonCode switch
            {
                MqttClientPublishReasonCode.Success => "成功",
                MqttClientPublishReasonCode.NoMatchingSubscribers => "没有匹配的订阅者",
                MqttClientPublishReasonCode.UnspecifiedError => "未指定错误",
                MqttClientPublishReasonCode.ImplementationSpecificError => "实现特定错误",
                MqttClientPublishReasonCode.NotAuthorized => "未授权",
                MqttClientPublishReasonCode.TopicNameInvalid => "主题名称无效",
                MqttClientPublishReasonCode.PacketIdentifierInUse => "数据包标识符正在使用",
                MqttClientPublishReasonCode.QuotaExceeded => "配额超出",
                MqttClientPublishReasonCode.PayloadFormatInvalid => "负载格式无效",
                _ => $"未知错误代码: {reasonCode}"
            };
        }
    }


    // 使用自定义结果类型
    public class PublishResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public MqttClientPublishResult MqttResult { get; set; }

        public static PublishResult Success(MqttClientPublishResult result) =>
            new() { IsSuccess = true, MqttResult = result };

        public static PublishResult Failure(string error) =>
            new() { IsSuccess = false, ErrorMessage = error };
    }

    /// <summary>
    /// 发送能耗数据和故障状态的操作类
    /// </summary>
    /// <param name="client"></param>
    public class MqttOperate(MqttClient client)
    {
        private readonly MqttClient _mqttClient = client ??
                 throw new ArgumentNullException(nameof(client), "MQTT客户端不能为空。");

        // 能耗结果主题常量
        private const string ENERGY_CONSUMPTION_TOPIC = "energy/task/response";
        // 故障状态主题常量
        private const string ERR_CONSUMPTION_TOPIC = "fault/task/response";

        /// <summary>
        /// 发送能耗数据
        /// </summary>
        /// <param name="message">能耗数据</param>
        /// <param name="customTopic">自定义主题（可选）</param>
        /// <returns>发送结果详情</returns>
        public async Task<(bool Success, string Message)> SendEnergyConsumptionAsync(
            EnergyResult message, string customTopic = null)
        {
            try
            {
                var json = JsonConvert.SerializeObject(message);
                var topic = customTopic ??
                   $"$di/devices/{_mqttClient._config.EquipmentCode}" +
                   $"/{ENERGY_CONSUMPTION_TOPIC}";

                var result = await _mqttClient.PublishAsync(topic, json);

                if (result == null)
                {
                    return (false, "发送失败：无返回结果");
                }

                return (result.IsSuccess, result.IsSuccess ? "发送成功" : result.ErrorMessage ?? "发送失败");
            }
            catch (Exception ex)
            {
                return (false, $"发送能耗数据异常：{ex.Message}");
            }
        }

        /// <summary>
        /// 故障状态上传
        /// </summary>
        /// <param name="message">故障数据</param>
        /// <param name="customTopic">自定义主题（可选）</param>
        /// <returns></returns>
        public async Task<(bool Success, string Message)> SendFaultInformationAsync(
          FaultDataResponse message, string customTopic = null)
        {
            try
            {
                var json = JsonConvert.SerializeObject(message);
                var topic = customTopic ??
                   $"$di/devices/{_mqttClient._config.EquipmentCode}" +
                   $"/{ERR_CONSUMPTION_TOPIC}";

                var result = await _mqttClient.PublishAsync(topic, json);

                if (result == null)
                {
                    return (false, "发送失败：无返回结果");
                }

                return (result.IsSuccess, result.IsSuccess ? "发送成功" : result.ErrorMessage ?? "发送失败");
            }
            catch (Exception ex)
            {
                return (false, $"故障状态上传异常：{ex.Message}");
            }
        }

    }
}