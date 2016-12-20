namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations;

    public class ParentSegment
    {
        public string 信息类别
        {
            get { return "I"; }
        }

        /// <summary>
        /// 上级机构名称
        /// </summary>
        [Display(Name = "上级机构名称"), StringLength(80), Required]
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号
        /// </summary>
        [Display(Name = "登记注册号"), StringLength(20)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18)]
        public string InstitutionCreditCode { get; set; }

        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
