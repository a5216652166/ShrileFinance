namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class RepaymentSegment
    {
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 借据编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "用来标识同一笔贷款合同项下的多笔放款借据的编号")]
        public string LoanId { get; set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(62, true)]
        public string DatePayment { get; set; }

        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(70, true, Describe = "标识还款的顺序号，起始次数可以不为1，从小到大顺序排列")]
        public string 还款次数 { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(74, true)]
        public string PaymentTypes { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(76, true)]
        public string ActualPaymentPrincipal { get; set; }
    }
}
