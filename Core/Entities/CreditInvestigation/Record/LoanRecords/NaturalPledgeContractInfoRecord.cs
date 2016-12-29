namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人质押合同信息记录
    /// </summary>
    public class NaturalPledgeContractInfoRecord : Record
    {
        public NaturalPledgeContractInfoRecord(CreditContract credit, GuarantyContractPledge guaranty) : base()
        {
            Segments = new List<Segment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人质押合同信息段
                new NaturalPledgeSegment(guaranty)
            };

            ((GuaranteeBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected NaturalPledgeContractInfoRecord() : base()
        {
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
