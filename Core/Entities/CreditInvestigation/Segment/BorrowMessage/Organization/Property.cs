namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Property
    {
        public string 信息类别
        {
            get { return "C"; }
        }

        /// <summary>
        /// 机构中文名称
        /// </summary>
        [Display(Name = "机构名称"), StringLength(80)]
        public string InstitutionChName { get; set; }

        public string 机构英文名称
        {
            get { return string.Empty.PadLeft(80, ' '); }
        }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        [Display(Name = "注册登记地址"), StringLength(80)]
        public string RegisterAddress { get; set; }

        public string 国别
        {
            get { return "CHN"; }
        }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        [Display(Name = "注册（登记）地行政区划"), StringLength(6)]
        public string RegisterAdministrativeDivision { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [Display(Name = "成立日期")]
        public string SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        [Display(Name = "证书到期日期")]
        public string CertificateDueDate { get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        [Display(Name = "经营（业务）范围"), StringLength(400)]
        public string BusinessScope { get; set; }

        public string 注册资本币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        [Display(Name = "注册资本（万元）"), DataType(DataType.Currency)]
        public string RegisterCapital { get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        [Display(Name = "组织机构类别"), StringLength(1)]
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        [Display(Name = "组织机构类别细分"), StringLength(2)]
        public string OrganizationCategorySubdivision { get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        [Display(Name = "经济行业分类"), StringLength(5)]
        public string EconomicSectorsClassification { get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        [Display(Name = "经济类型"), StringLength(2)]
        public string EconomicType { get; set; }

        [StringLength(8)]
        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
