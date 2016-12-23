namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowRecord : AbsRecord
    {
        private FinancialAffairs financial;
        private CashFlow item;

        public CashFlowRecord(Organization organization) : base()
        {
            var baseParagraph = new BaseParagraph(financial, organization, item.Type.ToString());

            Segments = new List<AbsSegment>()
            {
                // 基础段
                baseParagraph,

                // 2007版现金流量表段
                new CashFlowParagraph(item)
            };

            ((BaseParagraph)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        public CashFlowRecord(FinancialAffairs financial, CashFlow item)
        {
            this.financial = financial;
            this.item = item;
        }

        public CashFlowRecord(Organization organization, CashFlow item) : this(organization)
        {
            this.item = item;
        }

        protected CashFlowRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.现金流量表信息记录2007版;
            }
        }
    }
}
