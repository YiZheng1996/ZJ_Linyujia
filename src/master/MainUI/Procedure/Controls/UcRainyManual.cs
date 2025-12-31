namespace MainUI.Procedure.Controls
{
    public partial class UcRainyManual : UserControl
    {
        public UcRainyManual()
        {
            InitializeComponent();
            switchPictureBox.Click += SwitchPictureBox_Click;
            LoadFlowMonitorConfig();
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
        /// 加载流量监控配置
        /// </summary>
        private void LoadFlowMonitorConfig()
        {
            try
            {
                FlowMonitorConfig config = new();
                config.Load();
                _thresholdPercent = config.GetThresholdPercent();
                _enableFlowMonitor = config.IsMonitorEnabled();
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"加载流量监控配置失败：{ex.Message}", ex);
                _thresholdPercent = 10.0;
                _enableFlowMonitor = true;
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
                }
                else
                {
                    LabZT.Text = "关";
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

                // 检查流量是否超标
                CheckFlowOverflow(value);
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
            CloseValve();

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