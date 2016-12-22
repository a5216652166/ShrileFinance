namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务借据信息记录
    /// </summary>
    public class LoanIousInfoRecord : AbsRecord
    {
        public LoanIousInfoRecord(Loan loan, CreditContract credit)
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit),

                // 借据信息段
                new LoanSegment(loan)
            };

            ((CreditBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.贷款业务借据信息记录;
            }
        }
    }
}
