namespace MainUI.Procedure.Controls
{
    public partial class UcRainyManual : UserControl
    {
        public UcRainyManual()
        {
            InitializeComponent();
            switchPictureBox.Click += SwitchPictureBox_Click;

            // 加载流量监控配置
            LoadFlowMonitorConfig();

            // 初始化稳定性状态标签
            InitStabilityStatusLabel(); 
        }

        #region 事件定义

        /// <summary>
        /// 开关点击事件
        /// </summary>
        public event EventHandler OpenClick;

        /// <summary>
        /// 流量超标报警事件
        /// </summary>
        public event EventHandler<FlowAlarmEventArgs> FlowAlarm;

        #endregion

        #region 流量监控配置

        private double _thresholdPercent = 10.0;
        private bool _enableFlowMonitor = true;
        private bool _isAlarming = false; // 防止重复报警

        /// <summary>
        /// 流量历史记录队列(用于稳定性检测)
        /// </summary>
        private Queue<double> _flowHistory = new Queue<double>();

        /// <summary>
        /// 稳定性检测所需采样数量
        /// </summary>
        private int _stabilitySampleCount = 10;

        /// <summary>
        /// 稳定性判断阈值(百分比)
        /// </summary>
        private double _stabilityThreshold = 5.0;

        /// <summary>
        /// 最小流量阈值(低于此值不检测稳定性)
        /// </summary>
        private double _minimumFlowThreshold = 0.5;

        /// <summary>
        /// 流量是否已稳定
        /// </summary>
        private bool _flowStabilized = false;

        /// <summary>
        /// 稳定性状态标签(可选,用于界面显示)
        /// </summary>
        private Label _stabilityStatusLabel;

        /// <summary>
        /// 加载流量监控配置
        /// </summary>
        private void LoadFlowMonitorConfig()
        {
            try
            {
                FlowMonitorConfig config = new();
                config.Load();

                // 加载原有配置
                _thresholdPercent = config.GetThresholdPercent();
                _enableFlowMonitor = config.IsMonitorEnabled();

                // 加载稳定性检测配置
                _stabilitySampleCount = config.GetStabilitySampleCount();
                _stabilityThreshold = config.GetStabilityThreshold();
                _minimumFlowThreshold = config.GetMinimumFlowThreshold();

                NlogHelper.Default.Info(
                    $"流量监控配置加载成功: " +
                    $"超标阈值={_thresholdPercent}%, " +
                    $"稳定性采样数={_stabilitySampleCount}, " +
                    $"稳定性阈值={_stabilityThreshold}%, " +
                    $"最小流量={_minimumFlowThreshold}m³/h");
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"加载流量监控配置失败：{ex.Message}", ex);

                // 使用默认值
                _thresholdPercent = 10.0;
                _enableFlowMonitor = true;
                _stabilitySampleCount = 10;
                _stabilityThreshold = 5.0;
                _minimumFlowThreshold = 0.5;
            }
        }

        /// <summary>
        /// 超标阈值百分比
        /// </summary>
        public double ThresholdPercent
        {
            get => _thresholdPercent;
            set => _thresholdPercent = value;
        }

        /// <summary>
        /// 是否启用流量监控
        /// </summary>
        public bool EnableFlowMonitor
        {
            get => _enableFlowMonitor;
            set => _enableFlowMonitor = value;
        }

        /// <summary>
        /// 初始化稳定性状态标签(可选功能)
        /// </summary>
        private void InitStabilityStatusLabel()
        {
            _stabilityStatusLabel = new Label
            {
                AutoSize = false,
                Size = new Size(150, 25),
                Location = new Point(20, 350), // 调整到控件底部位置 (控件高度409,放在350位置)
                Font = new Font("微软雅黑", 9F, FontStyle.Bold),
                ForeColor = Color.Orange,
                BackColor = Color.FromArgb(80, 0, 0, 0), //半透明深色背景,更明显
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "稳定性: 等待数据",
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle // 添加边框,更容易看到
            };

            this.Controls.Add(_stabilityStatusLabel);
            _stabilityStatusLabel.BringToFront(); // 确保在最前面显示

            NlogHelper.Default.Debug($"稳定性状态标签已创建: 位置({_stabilityStatusLabel.Location.X}, {_stabilityStatusLabel.Location.Y})");
        }

        #endregion

        #region 属性

        private void SwitchPictureBox_Click(object sender, EventArgs e)
        {
            OpenClick?.Invoke(this, e);
        }

        private string _titleName;
        /// <summary>
        /// 标题名称
        /// </summary>
        public string TitleName
        {
            get { return _titleName; }
            set
            {
                _titleName = value;
                TitlePanel.Text = _titleName;
            }
        }

        private bool _isopen;
        /// <summary>
        /// 电磁阀开关状态
        /// </summary>
        public bool IsOpen
        {
            get { return _isopen; }
            set
            {
                _isopen = value;
                switchPictureBox.Switch = _isopen;
                if (value)
                {
                    LabZT.Text = "开";
                    _isAlarming = false; // 重新开启时重置报警状态

                    // 阀门开启时重置稳定性检测
                    ResetStabilityDetection();
                    NlogHelper.Default.Info($"[{_titleName}] 阀门已开启,开始稳定性检测");
                }
                else
                {
                    LabZT.Text = "关";
                    // 阀门关闭时清空检测数据 
                    ResetStabilityDetection();
                }
            }
        }

        private string _solenoidname;
        /// <summary>
        /// 电磁阀名称
        /// </summary>
        public string SolenoidName
        {
            get { return _solenoidname; }
            set
            {
                _solenoidname = value;
                switchPictureBox.Text = _solenoidname;
            }
        }

        private double _pressure;
        /// <summary>
        /// 气压传感器值
        /// </summary>
        public double Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                LabPressure.Value = _pressure;
            }
        }

        private string _pressurename;
        /// <summary>
        /// 气压传感器值名称
        /// </summary>
        public string PressureName
        {
            get { return _pressurename; }
            set
            {
                _pressurename = value;
                LabPressureName.Text = _pressurename;
            }
        }

        private string _internettrafficBZ;
        /// <summary>
        /// 流量标准(显示文本)
        /// </summary>
        public string InternetTrafficBZ
        {
            get { return _internettrafficBZ; }
            set
            {
                _internettrafficBZ = value;
                LabInternetTrafficBZ.Text = _internettrafficBZ;
                // 尝试从显示文本中提取标准值
                TryParseStandardValue(value);
            }
        }

        private double _standardValue = 0;
        /// <summary>
        /// 流量标准值(数值型，用于比较)
        /// </summary>
        public double StandardValue
        {
            get { return _standardValue; }
            set { _standardValue = value; }
        }

        /// <summary>
        /// 尝试从显示文本中提取标准值
        /// 例如："流量标准10.5(m³/h)" -> 10.5
        /// </summary>
        private void TryParseStandardValue(string displayText)
        {
            if (string.IsNullOrEmpty(displayText))
                return;

            try
            {
                // 提取数字部分：流量标准{数值}(m³/h)
                string numStr = System.Text.RegularExpressions.Regex.Match(
                    displayText, @"[\d.]+").Value;

                if (double.TryParse(numStr, out double result))
                {
                    _standardValue = result;
                }
            }
            catch
            {
                // 忽略解析错误
            }
        }

        private double _internettraffic;
        /// <summary>
        /// 流量传感器值
        /// </summary>
        public double InternetTraffic
        {
            get { return _internettraffic; }
            set
            {
                _internettraffic = value;
                LabInternetTraffic.Value = _internettraffic;

                // 只有阀门开启时才进行检测
                if (_isopen && _enableFlowMonitor)
                {
                    // 如果流量尚未稳定,继续检测稳定性
                    if (!_flowStabilized)
                    {
                        CheckFlowStability(value);
                    }
                    // 流量已稳定,检查是否超标
                    else
                    {
                        CheckFlowOverflow(value);
                    }
                }
            }
        }

        private string _internettrafficname;
        /// <summary>
        /// 流量传感器值名称
        /// </summary>
        public string InternetTrafficName
        {
            get { return _internettrafficname; }
            set
            {
                _internettrafficname = value;
                LabInternetTrafficName.Text = _internettrafficname;
            }
        }

        #endregion

        #region 流量超标检测

        /// <summary>
        /// 检查流量是否超标
        /// </summary>
        /// <param name="currentFlow">当前流量值</param>
        private void CheckFlowOverflow(double currentFlow)
        {
            // 检查是否启用监控
            if (!_enableFlowMonitor)
                return;

            // 检查流量是否已稳定
            if (!_flowStabilized)
                return;

            // 检查是否已报警(避免重复触发)
            if (_isAlarming)
                return;

            // 检查阀门是否开启(只有开启时才监控)
            if (!_isopen)
                return;

            // 检查标准值是否有效
            if (_standardValue <= 0)
                return;

            // 计算超标阈值
            double threshold = _standardValue * (1 + _thresholdPercent / 100.0);

            // 判断是否超标
            if (currentFlow > threshold)
            {
                _isAlarming = true;
                TriggerFlowAlarm(currentFlow, _standardValue, threshold);
            }
        }

        /// <summary>
        /// 触发流量超标报警
        /// </summary>
        private void TriggerFlowAlarm(double currentFlow, double standardValue, double threshold)
        {
            // 创建报警事件参数
            var alarmArgs = new FlowAlarmEventArgs
            {
                ChannelName = _titleName,
                CurrentFlow = currentFlow,
                StandardValue = standardValue,
                Threshold = threshold,
                ThresholdPercent = _thresholdPercent,
                AlarmTime = DateTime.Now,
                ChannelTag = this.Tag?.ToString() ?? "0"
            };

            // 记录日志
            NlogHelper.Default.Warn(
                $"[流量超标报警] 管路:{_titleName}, " +
                $"当前流量:{currentFlow:F2}m³/h, " +
                $"标准值:{standardValue:F2}m³/h, " +
                $"阈值:{threshold:F2}m³/h (超标{_thresholdPercent}%)");

            // 关闭当前管路输出(关闭电磁阀)
            //CloseValve();

            // 触发报警事件(由ucHMI处理MQTT上传)
            FlowAlarm?.Invoke(this, alarmArgs);
        }

        /// <summary>
        /// 关闭电磁阀
        /// </summary>
        private void CloseValve()
        {
            // 通过触发OpenClick事件来控制关闭
            // 或者直接设置IsOpen属性
            if (_isopen)
            {
                // 这里先触发事件，让ucHMI来处理DO信号
                OpenClick?.Invoke(this, new FlowAlarmCloseEventArgs { IsAutoClose = true });
            }
        }

        /// <summary>
        /// 重置报警状态
        /// </summary>
        public void ResetAlarmState()
        {
            _isAlarming = false;
        }

        /// <summary>
        /// 获取当前是否处于报警状态
        /// </summary>
        public bool IsAlarming => _isAlarming;

        #endregion

        #region 流量稳定性检测

        /// <summary>
        /// 检测流量稳定性
        /// </summary>
        /// <param name="currentFlow">当前流量值</param>
        private void CheckFlowStability(double currentFlow)
        {
            try
            {
                // 低于最小阈值不检测(可能是管路未开启或传感器异常)
                if (currentFlow < _minimumFlowThreshold)
                {
                    UpdateStabilityStatus($"流量过低({currentFlow:F2})", Color.Gray);
                    return;
                }

                // 添加到历史记录队列
                _flowHistory.Enqueue(currentFlow);

                // 保持队列固定长度(移除最早的数据)
                if (_flowHistory.Count > _stabilitySampleCount)
                {
                    _flowHistory.Dequeue();
                }

                // 需要足够的样本才能判断稳定性
                if (_flowHistory.Count < _stabilitySampleCount)
                {
                    int remaining = _stabilitySampleCount - _flowHistory.Count;
                    UpdateStabilityStatus($"收集中... ({_flowHistory.Count}/{_stabilitySampleCount})", Color.Orange);

                    NlogHelper.Default.Debug(
                        $"[{_titleName}] 稳定性检测采样中: {_flowHistory.Count}/{_stabilitySampleCount}, " +
                        $"当前流量: {currentFlow:F2}");
                    return;
                }

                // 计算平均值
                double avgFlow = _flowHistory.Average();

                // 计算每个采样点与平均值的偏差百分比
                List<double> deviations = new List<double>();
                foreach (double flow in _flowHistory)
                {
                    double deviation = Math.Abs(flow - avgFlow) / avgFlow * 100;
                    deviations.Add(deviation);
                }

                // 获取最大偏差
                double maxDeviation = deviations.Max();

                // 判断是否稳定:所有采样点偏差都在阈值内
                if (maxDeviation <= _stabilityThreshold)
                {
                    if (!_flowStabilized) // 首次达到稳定状态
                    {
                        _flowStabilized = true;

                        string msg = $"[{_titleName}] 流量已稳定,启动监控 " +
                                   $"(平均值: {avgFlow:F2} m³/h, " +
                                   $"最大偏差: {maxDeviation:F2}%, " +
                                   $"采样数: {_flowHistory.Count})";

                        NlogHelper.Default.Info(msg);
                        UpdateStabilityStatus("已稳定 ✓", Color.Green);

                        // 可选:触发稳定事件通知上层
                        // FlowStabilized?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    // 流量波动超过阈值,重置稳定状态
                    if (_flowStabilized)
                    {
                        NlogHelper.Default.Warn(
                            $"[{_titleName}] 流量波动过大,重置稳定状态 " +
                            $"(平均: {avgFlow:F2}, 最大偏差: {maxDeviation:F2}%)");
                    }

                    _flowStabilized = false;
                    UpdateStabilityStatus($"波动中 ({maxDeviation:F1}%)", Color.Orange);
                }
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"[{_titleName}] 稳定性检测异常: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 更新稳定性状态显示(可选功能)
        /// </summary>
        private void UpdateStabilityStatus(string text, Color color)
        {
            if (_stabilityStatusLabel != null && _stabilityStatusLabel.IsHandleCreated)
            {
                if (_stabilityStatusLabel.InvokeRequired)
                {
                    _stabilityStatusLabel.Invoke(() =>
                    {
                        _stabilityStatusLabel.Text = $"稳定性: {text}";
                        _stabilityStatusLabel.ForeColor = color;
                        _stabilityStatusLabel.Visible = _isopen; // 只在阀门开启时显示
                    });
                }
                else
                {
                    _stabilityStatusLabel.Text = $"稳定性: {text}";
                    _stabilityStatusLabel.ForeColor = color;
                    _stabilityStatusLabel.Visible = _isopen;
                }
            }
        }

        /// <summary>
        /// 重置稳定性检测状态
        /// </summary>
        private void ResetStabilityDetection()
        {
            _flowStabilized = false;
            _flowHistory.Clear();
            UpdateStabilityStatus("等待数据", Color.Gray);

            NlogHelper.Default.Debug($"[{_titleName}] 稳定性检测已重置");
        }

        /// <summary>
        /// 获取当前稳定性状态信息(用于调试或监控)
        /// </summary>
        public string GetStabilityStatusInfo()
        {
            if (!_isopen)
                return "阀门关闭";

            if (_flowHistory.Count < _stabilitySampleCount)
                return $"采样中 {_flowHistory.Count}/{_stabilitySampleCount}";

            return _flowStabilized ? $"已稳定 (平均: {_flowHistory.Average():F2})" : "波动中";
        }

        #endregion
    }

    #region 事件参数类

    /// <summary>
    /// 流量超标报警事件参数
    /// </summary>
    public class FlowAlarmEventArgs : EventArgs
    {
        /// <summary>
        /// 管路名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 当前流量值
        /// </summary>
        public double CurrentFlow { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        public double StandardValue { get; set; }

        /// <summary>
        /// 超标阈值
        /// </summary>
        public double Threshold { get; set; }

        /// <summary>
        /// 超标百分比
        /// </summary>
        public double ThresholdPercent { get; set; }

        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime { get; set; }

        /// <summary>
        /// 管路Tag标识
        /// </summary>
        public string ChannelTag { get; set; }
    }

    /// <summary>
    /// 流量超标自动关闭事件参数
    /// </summary>
    public class FlowAlarmCloseEventArgs : EventArgs
    {
        /// <summary>
        /// 是否为自动关闭(超标报警触发)
        /// </summary>
        public bool IsAutoClose { get; set; }
    }

    #endregion
}