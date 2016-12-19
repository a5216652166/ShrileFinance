namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 大事件
    /// </summary>
    public class BigEvent
    {
        public string 信息类别
        {
            get { return "D"; }
        }
        /// <summary>
        /// 大事件流水号
        /// </summary>
        [Display(Name = "大事件流水号"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(2, 60, Describe = "报送机构用于标识某个借款人一条大事记录的唯一编号")]
        public string BigEventNumber { get; set; }

        /// <summary>
        /// 大事件描述
        /// </summary>
        [Display(Name = "大事描述"), IsRequiredAndType(true, IsRequiredAndTypeAttribute.DataTypeEnum.ANC), LocationAndLength(62, 250, Describe = "用文本描述，包括借款人逃废债、重组、借款人改制、借款人破产、借款人提供虚假资料等内容")]
        public string BigEventDescription { get; set; }
    }
}
