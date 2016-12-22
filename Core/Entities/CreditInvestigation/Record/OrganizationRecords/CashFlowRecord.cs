namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
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
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(financial, organization, item.ToString()),

                // 2007版现金流量表段
                new CashFlowParagraph(item)
            };
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

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.现金流量表信息记录2007版;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
