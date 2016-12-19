namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;

    public class Litigation
    {
        public string 信息类别
        {
            get { return "B"; }
        }

        /// <summary>
        /// 被起诉流水号
        /// </summary>
        [Required]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Required]
        public string ProsecuteName { get; set; }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Display(Name = "判决执行金额"), Required]
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Required]
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Required]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Required]
        public string Reason { get; set; }
    }
}
