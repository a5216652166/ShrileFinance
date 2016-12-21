namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;
    using Loan;

    /// <summary>
    /// 自然人抵押合同信息记录
    /// </summary>
    public class NaturalMortgageContractInfoRecord : AbsRecord
    {
        public NaturalMortgageContractInfoRecord(CreditContract credit, GuarantyContractMortgage guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment("自然人抵押",credit),

                // 自然人抵押合同信息段
                new NaturalMortgageSegment(guaranty)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人抵押合同信息记录;
            }
        }
    }
}
