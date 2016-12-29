namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : Record
    {
        public DebitInterestInfoRecord(CreditContract credit, PaymentHistory payment) : base()
        {
            Segments = new List<Segment>() {
                // 基础段
                new DebitInterestBaseSegment(credit.Organization.LoanCardCode),

                // 欠息业务信息段
                new DebitInterestSegment(payment)
                ////new DebitInterestSegment((payment.ScheduledPaymentInterest-payment.ActualPaymentPrincipal).ToString())
            };
            ((DebitInterestBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected DebitInterestInfoRecord() : base()
        {
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
