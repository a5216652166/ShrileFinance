namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人抵押合同信息记录
    /// </summary>
    public class NaturalMortgageContractInfoRecord : Record
    {
        public NaturalMortgageContractInfoRecord(CreditContract credit, GuarantyContractMortgage guaranty) : base()
        {
            Segments = new List<Segment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人抵押合同信息段
                new NaturalMortgageSegment(guaranty)
            };

            ((GuaranteeBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected NaturalMortgageContractInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人抵押合同信息记录;
            }
        }
    }
}
