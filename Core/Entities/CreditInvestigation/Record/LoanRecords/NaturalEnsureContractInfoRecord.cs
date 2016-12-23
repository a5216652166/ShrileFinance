namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人保证合同信息记录
    /// </summary>
    public class NaturalEnsureContractInfoRecord : AbsRecord
    {
        public NaturalEnsureContractInfoRecord(CreditContract credit, GuarantyContract guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人保证合同信息段
                new NaturalGuaranteeSegment(guaranty)
            };
            ((GuaranteeBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected NaturalEnsureContractInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人保证合同信息记录;
            }
        }
    }
}
