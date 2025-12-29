namespace MainUI.Config
{
    public class TestParaConfig : IniConfig
    {
        public TestParaConfig()
          : base(Application.StartupPath + "config\\TestPara.ini")
        {
        }
        public TestParaConfig(string sectionName)
            : base(Application.StartupPath + "config\\TestPara.ini")
        {
            this.SetSectionName(sectionName);
            Load();
        }

        /// <summary>
        /// 水箱高液位设置
        /// </summary>
        [IniKeyName("水箱高液位设置")]
        public string WaterHighSet { get; set; }

        /// <summary>
        /// 水箱低液位设置
        /// </summary>
        [IniKeyName("水箱低液位设置")]
        public string WaterLowSet { get; set; }

        /// <summary>
        /// 水箱极低液位设置
        /// </summary>
        [IniKeyName("水箱极低液位设置")]
        public string WaterVeryLowSet { get; set; }

        /// <summary>
        /// 管路流量低设置
        /// </summary>
        [IniKeyName("管路流量低设置")]
        public string InternetTrafficSet { get; set; }

        /// <summary>
        /// 喷淋时间
        /// </summary>
        [IniKeyName("喷淋时间")]
        public string SprayTimeSet { get; set; }

        /// <summary>
        /// 频率1给定
        /// </summary>
        [IniKeyName("频率1给定")]
        public string Frequency1Set { get; set; }

        /// <summary>
        /// 频率2给定
        /// </summary>
        [IniKeyName("频率2给定")]
        public string Frequency2Set { get; set; }

        /// <summary>
        /// 压力给定
        /// </summary>
         [IniKeyName("压力给定")]
        public string AirSet { get; set; }
    }
}
