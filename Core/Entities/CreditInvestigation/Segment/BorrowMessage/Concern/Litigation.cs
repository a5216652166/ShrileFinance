namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 诉讼事件
    /// </summary>
    public class Litigation
    {
        [IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.AN), LocationAndLength(1, 1, Describe = "段标")]
        public string 信息类别
        {
            get { return "D"; }
        }

        [Display(Name = "被起诉流水号"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(2, 60, Describe = "报报送机构用于标识一起诉讼的唯一编号")]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Display(Name = "起诉人姓名"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(62, 80)]
        public string ProsecuteName { get; set; }

        [IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.AN), LocationAndLength(142, 3)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Display(Name = "判决执行金额"),IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.AN), LocationAndLength(145, 20)]
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Display(Name = "判决执行日期"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.N), LocationAndLength(165, 8)]
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Display(Name = "执行结果"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(173,100)]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Display(Name = "被起诉原因"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(273, 300)]
        public string Reason { get; set; }
    }
}
