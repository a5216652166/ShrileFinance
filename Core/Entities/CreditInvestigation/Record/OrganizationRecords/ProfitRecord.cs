namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitRecord : AbsRecord
    {
        private FinancialAffairs financial;
        private Profit item;

        public ProfitRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(financial, organization, item.Type.ToString()),

                // 2007版利润及利润分配表信息记录
                new ProfitsParagraph()
            };
        }

        public ProfitRecord(FinancialAffairs financial, Profit item)
        {
            this.financial = financial;
            this.item = item;
        }

        public ProfitRecord(Organization organization, Profit item) : this(organization)
        {
            this.item = item;
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.利润及利润分配表信息记录2007版;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
