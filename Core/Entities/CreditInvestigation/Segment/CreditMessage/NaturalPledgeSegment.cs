namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using AutoMapper;
    using Core.Entities.Loan;

    /// <summary>
    /// 自然人质押
    /// </summary>
    public class NaturalPledgeSegment : AbsSegment
    {
        public NaturalPledgeSegment(GuarantyContractPledge guaranty)
        {
            Mapper.Map(guaranty, this);
            if (guaranty.Guarantor is GuarantorPerson)
            {
                var person = guaranty.Guarantor as GuarantorPerson;
                CertificateType = person.CertificateType;
                CertificateNumber = person.CertificateNumber;
            }
            Name = guaranty.Guarantor.Name;
            PledgeType = guaranty.PledgeType.Value.ToString("D");
            EffectiveState = guaranty.EffectiveState.Value.ToString("D");
            质押合同编号 = guaranty.Id.ToString();
            SigningDate = guaranty.SigningDate == null ? "" : guaranty.SigningDate.Value.ToString("yyyyMMdd");
        }

        protected NaturalPledgeSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "I"; }
        }

        /// <summary>
        /// 质押合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "金融机构标识一笔质押合同的唯一编号")]
        public string 质押合同编号 { get; set; }

        /// <summary>
        /// 质押序号
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(62, true, Describe = "区别多个质押的序列号")]
        public string PledgeNumber { get; set; }

        /// <summary>
        /// 出质人名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(64, true)]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(144, true)]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.ANC), SegmentRule(145, true)]
        public string CertificateNumber { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(163, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物价值
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(166, true)]
        public string CollateralValue { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(186, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 质押物种类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(194, true)]
        public string PledgeType { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(195, true)]
        public string 质押币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(198, true)]
        public string Margin { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(218, true)]
        public string EffectiveState { get; set; }
    }
}
