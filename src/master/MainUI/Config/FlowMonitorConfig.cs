namespace MainUI.Config
{
    /// <summary>
    /// 流量监控配置类
    /// </summary>
    public class FlowMonitorConfig : IniConfig
    {
        public FlowMonitorConfig()
         : base(Application.StartupPath + "config\\FlowMonitor.ini")
        {
        }

        public FlowMonitorConfig(string sectionName)
            : base(Application.StartupPath + "config\\FlowMonitor.ini")
        {
            this.SetSectionName(sectionName);
            Load();
        }

        /// <summary>
        /// 超标报警阈值百分比 (默认10，表示超过标准10%报警)
        /// </summary>
        [IniKeyName("超标阈值百分比")]
        public string OverflowThresholdPercent { get; set; } = "10";

        /// <summary>
        /// 是否启用流量监控报警
        /// </summary>
        [IniKeyName("启用流量监控")]
        public string EnableFlowMonitor { get; set; } = "true";

        // ==================== 新增稳定性检测配置 ====================

        /// <summary>
        /// 稳定性检测采样数量 (默认10个采样点)
        /// </summary>
        [IniKeyName("稳定性采样数")]
        public string StabilitySampleCount { get; set; } = "10";

        /// <summary>
        /// 稳定性判断阈值百分比 (默认5%,即所有采样点与平均值偏差在5%以内视为稳定)
        /// </summary>
        [IniKeyName("稳定性阈值百分比")]
        public string StabilityThresholdPercent { get; set; } = "5";

        /// <summary>
        /// 最小流量阈值 (默认0.5 m³/h, 低于此值不进行稳定性检测)
        /// </summary>
        [IniKeyName("最小流量阈值")]
        public string MinimumFlowThreshold { get; set; } = "0.5";

        // ==================== 获取方法 ====================

        /// <summary>
        /// 获取超标阈值百分比(数值)
        /// </summary>
        public double GetThresholdPercent()
        {
            if (double.TryParse(OverflowThresholdPercent, out double result))
            {
                return result;
            }
            return 10.0;
        }

        /// <summary>
        /// 是否启用监控
        /// </summary>
        public bool IsMonitorEnabled()
        {
            return EnableFlowMonitor?.ToLower() == "true";
        }

        /// <summary>
        /// 获取稳定性采样数量
        /// </summary>
        public int GetStabilitySampleCount()
        {
            if (int.TryParse(StabilitySampleCount, out int result) && result > 0)
            {
                return result;
            }
            return 10;
        }

        /// <summary>
        /// 获取稳定性阈值百分比
        /// </summary>
        public double GetStabilityThreshold()
        {
            if (double.TryParse(StabilityThresholdPercent, out double result) && result > 0)
            {
                return result;
            }
            return 5.0;
        }

        /// <summary>
        /// 获取最小流量阈值
        /// </summary>
        public double GetMinimumFlowThreshold()
        {
            if (double.TryParse(MinimumFlowThreshold, out double result) && result >= 0)
            {
                return result;
            }
            return 0.5;
        }
    }
}