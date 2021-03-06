﻿namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using AutoMapper;
    using Customers.Enterprise;

    /// <summary>
    /// 高管
    /// </summary>
    public class ManagerSegment : Segment
    {
        public ManagerSegment(Manager manager)
        {
            Mapper.Map(manager, this);
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        protected ManagerSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public override char SegmentType
        {
            get { return 'F'; }
        }

        /// <summary>
        /// 关系人类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string Type { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(3, true)]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(83, true)]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(85, true)]
        public string CertificateCode { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(105, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(113, false)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
