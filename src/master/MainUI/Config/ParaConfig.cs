namespace MainUI.Config
{
    public class ParaConfig : IniConfig
    {
        public ParaConfig()
          : base(Application.StartupPath + "config\\Para.ini")
        {
        }
        public ParaConfig(string sectionName)
            : base(Application.StartupPath + "config\\Para.ini")
        {
            this.SetSectionName(sectionName);
            Load();
        }

        /// <summary>
        /// 报表名称
        /// </summary>
        [IniKeyName("报表名称")]
        public string RptFile { get; set; }

        /// <summary>
        /// 喷淋时间
        /// </summary>
        [IniKeyName("喷淋时间")]
        public string SprayTime { get; set; }

        /// <summary>
        /// 喷淋压力
        /// </summary>
        [IniKeyName("喷淋压力")]
        public string SprayKpa { get; set; }

        /// <summary>
        /// 电机行走速度
        /// </summary>
        [IniKeyName("电机行走速度")]
        public string WalkingSpeed { get; set; }
    }
}
