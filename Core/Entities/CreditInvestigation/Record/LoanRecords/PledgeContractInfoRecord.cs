namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 质押合同信息记录
    /// </summary>
    public class PledgeContractInfoRecord : AbsRecord
    {
        public PledgeContractInfoRecord(CreditContract credit, GuarantyContractPledge guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人质押合同信息段
                new GuaranteePledgeSegment(guaranty, credit)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.质押合同信息记录;
            }
        }
    }
}
