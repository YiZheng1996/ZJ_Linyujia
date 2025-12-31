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

        /// <summary>
        /// 获取超标阈值百分比(数值)
        /// </summary>
        /// <returns>百分比数值，默认返回10</returns>
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
    }
}