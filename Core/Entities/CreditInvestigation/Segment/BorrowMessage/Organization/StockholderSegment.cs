namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using AutoMapper;
    using Customers.Enterprise;

    /// <summary>
    /// 重要股东
    /// </summary>
    public class StockholderSegment : AbsSegment
    {
        public StockholderSegment(Stockholder stockholder)
        {
            Mapper.Map(stockholder, this);
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 股东类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(3, true)]
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 证件类型/登记注册号类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(83, false)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 证件号码/登记注册号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(85, false)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(105, false)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.AN), SegmentRule(115, false)]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(133, false)]
        public string SharesProportion { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(143, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(151, false)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
