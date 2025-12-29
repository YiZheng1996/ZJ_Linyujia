namespace MainUI.MQTT
{
    public class MqttConfig : IniConfig
    {
        public MqttConfig()
          : base(Application.StartupPath + "config\\MqttConfig.ini")
        {
        }

        public MqttConfig(string sectionName)
          : base(Application.StartupPath + "config\\MqttConfig.ini")
        {
            SetSectionName(sectionName);
            Load();
        }

        /// <summary>
        /// IP地址
        /// </summary>
        [IniKeyName("IP地址")]
        public string IPAddress { get; set; }

        /// <summary>
        /// IP端口
        /// </summary>
        [IniKeyName("IP端口")]
        public string IPPort { get; set; }

        /// <summary>
        /// 设备编码(账号)
        /// </summary>
        [IniKeyName("设备编码(账号)")]
        public string EquipmentCode { get; set; }

        /// <summary>
        /// MQTT密码
        /// </summary>
        [IniKeyName("MQTT密码")]
        public string MqttPassWord { get; set; }

        /// <summary>
        /// 客户端ID号
        /// 设备clientId由2部分组成：设备编码、设备身份标识类型、通过下划线“_”分隔。
        /// 设备编码：由MES进行分配，设备端进行存储。
        /// 设备身份标识类型：固定值为0。
        /// </summary>
        [IniKeyName("客户端ID号")]
        public string ClientId { get; set; }
        
    }
}