namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using AutoMapper;
    using Customers.Enterprise;

    public class PropertySegment : AbsSegment
    {
        public PropertySegment(OrganizationProperties property)
        {
            Mapper.Map(property, this);
            SetupDate = property.SetupDate == null ? "" : property.SetupDate.Value.ToString("yyyyMMdd");
            CertificateDueDate = property.CertificateDueDate == null ? "" : property.CertificateDueDate.Value.ToString("yyyyMMdd");
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "C"; }
        }

        /// <summary>
        /// 机构中文名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(2, false)]
        public string InstitutionChName { get; set; }

        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(82, false)]
        public string 机构英文名称
        {
            get { return string.Empty.PadLeft(80, ' '); }
        }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(162, false)]
        public string RegisterAddress { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public string 国别
        {
            get { return "CHN"; }
        }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        [MetaCode(6, MetaCodeTypeEnum.N), SegmentRule(245, false)]
        public string RegisterAdministrativeDivision { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(251, false)]
        public string SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(259, false)]
        public string CertificateDueDate { get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        [MetaCode(400, MetaCodeTypeEnum.ANC), SegmentRule(267, false)]
        public string BusinessScope { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(667, false)]
        public string 注册资本币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.Amount), SegmentRule(670, false)]
        public string RegisterCapital { get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(680, false)]
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(681, false)]
        public string OrganizationCategorySubdivision { get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        [MetaCode(5, MetaCodeTypeEnum.AN), SegmentRule(683, false)]
        public string EconomicSectorsClassification { get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(688, false)]
        public string EconomicType { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(690, false)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(698, true)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
