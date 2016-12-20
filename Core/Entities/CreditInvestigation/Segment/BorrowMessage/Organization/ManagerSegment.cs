namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations;

    public class ManagerSegment
    {
        public string 信息类别
        {
            get { return "F"; }
        }

        /// <summary>
        /// 关系人类型
        /// </summary>
        [Display(Name = "关系人类型"), StringLength(1)]
        public string Type { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名"), StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [Display(Name = "证件类型"), StringLength(2), Required]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码"), StringLength(20), Required]
        public string CertificateCode { get; set; }

        [StringLength(8)]
        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
