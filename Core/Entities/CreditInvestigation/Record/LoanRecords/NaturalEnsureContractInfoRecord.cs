namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;
    using Loan;


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
                new GuaranteeBaseSegment("自然人保证",credit),

                // 自然人保证合同信息段
                new NaturalGuaranteeSegment(guaranty)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人保证合同信息记录;
            }
        }
    }
}
