namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using AutoMapper;
    using Customers.Enterprise;

    public class AssociatedEnterpriseSegment : AbsSegment
    {
        public AssociatedEnterpriseSegment(AssociatedEnterprise AssociatedEnterprise)
        {
            Mapper.Map(AssociatedEnterprise, this);
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "H"; }
        }

        /// <summary>
        /// 关联类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string AssociatedType { get; set; }

        /// <summary>
        /// 关联企业名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(4, true)]
        public string Name { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(84, false)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(86, false)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(106, false)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.AN), SegmentRule(116, false)]
        public string InstitutionCreditCode { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(134, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(142, false)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
