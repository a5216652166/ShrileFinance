namespace Core.Entities.Message.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations;

    public class Family
    {
        public string 信息类别
        {
            get { return "B"; }
        }

        /// <summary>
        /// 家族成员关系
        /// </summary>
        [Display(Name = "家族成员关系"), StringLength(1)]
        public string Relationship { get; set; }

        /// <summary>
        /// 家族成员姓名
        /// </summary>
        [Display(Name = "家族成员姓名"), StringLength(80), Required]
        public string Name { get; set; }

        /// <summary>
        /// 家族成员证件类型
        /// </summary>
        [Display(Name = "家族成员证件类型"), StringLength(2), Required]
        public string CertificateType { get; set; }

        /// <summary>
        /// 家族成员证件号码
        /// </summary>
        [Display(Name = "家族成员证件号码"), StringLength(20), Required]
        public string CertificateCode { get; set; }

        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
