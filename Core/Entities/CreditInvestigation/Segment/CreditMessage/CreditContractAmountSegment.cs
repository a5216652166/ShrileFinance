namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using Core.Entities.Loan;

    public class CreditContractAmountSegment : Segment
    {
        public CreditContractAmountSegment(CreditContract credit, decimal balance)
        {
            AutoMapper.Mapper.Map(credit, this);
            CreditBalance = balance.ToString();
        }

        protected CreditContractAmountSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public override char SegmentType
        {
            get { return 'E'; }
        }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 贷款合同金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(5, true)]
        public string CreditLimit { get; set; }

        /// <summary>
        /// 贷款余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(25, true)]
        public string CreditBalance { get; set; }
    }
}
