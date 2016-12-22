namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人质押合同信息记录
    /// </summary>
    public class NaturalPledgeContractInfoRecord : AbsRecord
    {
        public NaturalPledgeContractInfoRecord(CreditContract credit, GuarantyContractPledge guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人质押合同信息段
                new NaturalPledgeSegment(guaranty)
            };
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人质押合同信息记录;
            }
        }
    }
}
