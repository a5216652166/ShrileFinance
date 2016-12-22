namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 抵押合同信息记录
    /// </summary>
    public class MortgageContractInfoRecord : AbsRecord
    {
        public MortgageContractInfoRecord(CreditContract credit, GuarantyContractMortgage guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 抵押合同信息段
                new GuaranteeMortgageSegment(guaranty, credit)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.抵押合同信息记录;
            }
        }
    }
}
