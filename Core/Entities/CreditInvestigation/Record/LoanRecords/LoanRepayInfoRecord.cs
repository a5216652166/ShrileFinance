namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务还款信息记录
    /// </summary>
    public class LoanRepayInfoRecord : AbsRecord
    {
        public LoanRepayInfoRecord(CreditContract credit,Loan loan, PaymentHistory payment)
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit),

                // 还款信息段
                new RepaymentSegment(loan,payment)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.贷款业务还款信息记录;
            }
        }
    }
}
