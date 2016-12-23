namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;

    /// <summary>
    /// 欠息数据段
    /// </summary>
    public class DebitInterestSegment : AbsSegment
    {
        public DebitInterestSegment(Loan.PaymentHistory payment) : base()
        {
            欠息余额 = (payment.ScheduledPaymentInterest - payment.ActualPaymentPrincipal).ToString();
            欠息余额改变日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        protected DebitInterestSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "D"; }
        }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(5, true)]
        public string 欠息余额 { get; set; }

        /// <summary>
        /// 欠息类型（1表示表内）
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(25, true)]
        public string 欠息类型
        {
            get { return "1"; }
        }

        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(26, true)]
        public string 欠息余额改变日期 { get; set; }
    }
}
