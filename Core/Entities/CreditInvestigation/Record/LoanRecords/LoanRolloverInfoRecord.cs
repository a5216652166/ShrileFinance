namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core.Entities.CreditInvestigation.Segment;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;
    using Core.Entities.Loan;

    /// <summary>
    /// 展期信息记录
    /// </summary>
    public class LoanRolloverInfoRecord : Record
    {
        public LoanRolloverInfoRecord(CreditContract credit, Loan loan, PaymentHistory payment)
        {
            int time = loan.Payments.ToList().FindIndex(m => m.Id == payment.Id) + 1;

            Segments = new List<Segment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit, payment.ActualDatePayment),

                // 展期信息段
                new RolloverSegment()
            };

            ((CreditBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        public override RecordTypeEnum Type => RecordTypeEnum.贷款业务展期信息记录;
    }
}
