namespace MainUI.Config
{
    public class InternetTrafficBZConfig : IniConfig
    {
        public InternetTrafficBZConfig()
         : base(Application.StartupPath + "config\\InternetTrafficBZ.ini")
        {
        }
        public InternetTrafficBZConfig(string sectionName)
            : base(Application.StartupPath + "config\\InternetTrafficBZ.ini")
        {
            this.SetSectionName(sectionName);
            Load();
        }

        /// <summary>
        /// 供车顶
        /// </summary>
        [IniKeyName("供车顶")]
        public string Standard01 { get; set; }

        /// <summary>
        /// 西侧墙
        /// </summary>
        [IniKeyName("西侧墙")]
        public string Standard02 { get; set; }

        /// <summary>
        /// 西车底
        /// </summary>
        [IniKeyName("西车底")]
        public string Standard03 { get; set; }

        /// <summary>
        /// 北车罩
        /// </summary>
        [IniKeyName("北车罩")]
        public string Standard04 { get; set; }

        /// <summary>
        /// 南车罩
        /// </summary>
        [IniKeyName("南车罩")]
        public string Standard05 { get; set; }

        /// <summary>
        /// 东侧墙
        /// </summary>
        [IniKeyName("东侧墙")]
        public string Standard06 { get; set; }

        /// <summary>
        /// 东车底
        /// </summary>
        [IniKeyName("东车底")]
        public string Standard07 { get; set; }
    }
}
