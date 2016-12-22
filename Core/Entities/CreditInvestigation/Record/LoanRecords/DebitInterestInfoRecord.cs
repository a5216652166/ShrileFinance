namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

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
                new DebitInterestSegment(payment)
                ////new DebitInterestSegment((payment.ScheduledPaymentInterest-payment.ActualPaymentPrincipal).ToString())
            };
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.欠息信息记录;
            }
        }
    }
}
