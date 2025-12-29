using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MainUI.MQTT
{
    #region 能耗数据相关实体类

    /// <summary>
    /// 能耗数据反馈响应类
    /// Topic: $di/devices/{device_id}/energy/response
    /// </summary>
    public class EnergyDataResponse
    {
        /// <summary>
        /// 能耗数据列表
        /// </summary>
        public List<EnergyResult> Results { get; set; } = [];
    }

    /// <summary>
    /// 能耗数据结果实体
    /// </summary>
    public class EnergyResult
    {
        /// <summary>
        /// 采集类别 - 车间代码+名称+能源类型+仪表代码（固定值1）
        /// </summary>
        public int collect_type { get; set; } = 1;

        /// <summary>
        /// 设备名称（万用表/电流表）（淋雨架）
        /// </summary>
        public string equip_name { get; set; } = "动车组淋雨架";

        /// <summary>
        /// 用能设备代码
        /// </summary>
        public string usingenergy_equip_code { get; set; } = "999-699";

        ///// <summary>
        ///// 车间代码 {A07、A08、C01、C03、C04、D04、B23} =====没找到字段
        ///// </summary>
        //public string workshop_code { get; set; } = string.Empty;

        /// <summary>
        /// 计量仪表代码SL1（水流量表1），D1（电表1）数字按顺序往后排列
        /// </summary>
        public string meteringdevice_code { get; set; } = "";

        /// <summary>
        /// 计量单位 {kWh、m3、t}Kwh（电）t(水)
        /// </summary>
        public string metering_unit { get; set; } = "kWh,t";

        /// <summary>
        /// 采集来源 (默认4)
        /// 1、管理信息系统
        /// 2、生产监控管理系统
        /// 3、工业控制系统
        /// 4、现场仪表
        /// </summary>
        public int collection_source { get; set; } = 4;

        /// <summary>
        /// 用于结算统计（默认1），接口文件不存在此字段，暂时保留
        /// </summary>
        public int billing { get; set; } = 1;

        /// <summary>
        /// 供能方向（默认1），接口文件不存在此字段，暂时保留
        /// </summary>
        public int energy_direct { get; set; } = 1;

        /// <summary>
        /// 电压等级(默认380，水就是2)，接口文件不存在此字段，暂时保留
        /// </summary>
        public int votage_level { get; set; } = 380;

        /// <summary>
        /// 采集数值，接口文件不存在此字段，暂时保留
        /// </summary>
        public double energy_value { get; set; } = 0.0;

        /// <summary>
        /// 生产代码，接口文件不存在此字段，暂时保留
        /// </summary>
        public string production_process_code = "动车组调试基地";

        /// <summary>
        /// 工序代码，接口文件不存在此字段，暂时保留
        /// </summary>
        public string process_unit_code = "淋雨工序";

        /// <summary>
        /// 采集类型 (默认2)
        /// 一般选择二次能源
        /// 一次能源代表二级计量仪表
        /// </summary>
        public int collection_type { get; set; } = 2;

        /// <summary>
        /// 能源类型
        /// 3300、电力
        /// 0101、压缩空气
        /// 0100、其他气体（蒸汽）
        /// 0102、新水
        /// 2100、柴油
        /// </summary>
        public string energy_type { get; set; } = "3300";

        /// <summary>
        /// 数据用途（默认31）
        /// 工业生产消费 21
        /// 非工业生产消费 22
        /// 工业生产消费用作原材料 23
        /// 产出 30
        /// 用于工业 31
        /// 用于非工业 32
        /// 回收利用 40
        /// </summary>
        public string data_usage { get; set; } = "31";

        /// <summary>
        /// 车型
        /// </summary>
        public string locomotive_type { get; set; } = string.Empty;

        /// <summary>
        /// 节车号
        /// </summary>
        public string singer_car_code { get; set; } = string.Empty;

        /// <summary>
        /// 仪表（设备唯一编码）
        /// </summary>
        public string equip_code { get; set; } = string.Empty;

        /// <summary>
        /// 采集开始时间
        /// </summary>
        public string collection_start_time { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 采集结束时间
        /// </summary>
        public string collection_end_time { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 采集部位 ？？？
        /// </summary>
        public string collect_part { get; set; } = "整机电量";

        /// <summary>
        /// 备注
        /// </summary>
        public string desc { get; set; } = string.Empty;
    }

    #endregion

    #region 故障状态相关实体类

    /// <summary>
    /// 故障状态上传响应类
    /// Topic: $di/devices/{device_id}/fault/response
    /// </summary>
    public class FaultDataResponse
    {
        /// <summary>
        /// 是否为开机第一次提交
        /// </summary>
        [JsonProperty("start")]
        [Required]
        public bool Start { get; set; }

        /// <summary>
        /// 故障数据列表
        /// </summary>
        [JsonProperty("results")]
        [Required]
        public List<FaultResult> Results { get; set; } = [];
    }

    /// <summary>
    /// 故障数据结果实体
    /// </summary>
    public class FaultResult
    {
        /// <summary>
        /// 故障代码（A001,A002）变频器故障
        /// </summary>
        [JsonProperty("fault_code")]
        [Required]
        [StringLength(32)]
        public string FaultCode { get; set; } = string.Empty;

        /// <summary>
        /// 故障等级
        /// </summary>
        [JsonProperty("fault_level")]
        [Required]
        [StringLength(50)]
        public string FaultLevel { get; set; } = string.Empty;

        /// <summary>
        /// 故障描述（故障信息）
        /// </summary>
        [JsonProperty("fault_desc")]
        [Required]
        [StringLength(50)]
        public string FaultDesc { get; set; } = string.Empty;

        /// <summary>
        /// 状态（0：故障中 1：解决）
        /// 故障复位 通知中控
        /// </summary>
        [JsonProperty("fault_status")]
        [Required]
        [StringLength(50)]
        public string FaultStatus { get; set; } = "1";

        /// <summary>
        /// 时间
        /// </summary>
        [JsonProperty("fault_time")]
        [Required]
        [StringLength(50)]
        public string FaultTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("desc")]
        [StringLength(50)]
        public string Desc { get; set; } = string.Empty;
    }

    #endregion

}