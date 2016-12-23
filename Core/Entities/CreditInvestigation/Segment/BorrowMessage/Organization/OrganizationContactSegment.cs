namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using AutoMapper;
    using Customers.Enterprise;

    public class OrganizationContactSegment : AbsSegment
    {
        public OrganizationContactSegment(OrganizationContact contact)
        {
            Mapper.Map(contact, this);
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        protected OrganizationContactSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "E"; }
        }

        /// <summary>
        /// 办公（生产、经营）地址
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(2, false)]
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [MetaCode(35, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 财务部联系电话
        /// </summary>
        [MetaCode(35, MetaCodeTypeEnum.AN), SegmentRule(117, false)]
        public string FinancialContactPhone { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(152, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(160, true)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
