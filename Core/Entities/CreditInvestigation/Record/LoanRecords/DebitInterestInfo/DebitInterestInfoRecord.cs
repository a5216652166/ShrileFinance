namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;
    using Loan;


    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : AbsRecord
    {
        public DebitInterestInfoRecord(CreditContract credit, PaymentHistory payment) : base()
        {
            Segments = new List<AbsSegment>() {
                // 基础段
                new DebitInterestBaseSegment(credit.Organization.LoanCardCode),

                // 欠息业务信息段
                new DebitInterestSegment((payment.ScheduledPaymentInterest-payment.ActualPaymentPrincipal).ToString())
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.欠息信息记录;
            }
        }
    }
}
