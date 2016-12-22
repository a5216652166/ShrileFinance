namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class BalanceSheetRecord : AbsRecord
    {
        private FinancialAffairs financial;
        private Liabilities item;

        public BalanceSheetRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(financial, organization, item.Type.ToString()),

                // 2007版资产负债表段
                new LiabilitiesParagraph()
            };
        }

        public BalanceSheetRecord(FinancialAffairs financial, Liabilities item)
        {
            this.financial = financial;
            this.item = item;
        }

        public BalanceSheetRecord(Organization organization, Liabilities item) : this(organization)
        {
            this.item = item;
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.资产负债表信息记录2007版;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
