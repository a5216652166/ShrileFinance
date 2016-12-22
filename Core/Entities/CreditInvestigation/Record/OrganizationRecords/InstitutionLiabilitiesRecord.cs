namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位资产负债表信息记录
    /// </summary>
    public class InstitutionLiabilitiesRecord : AbsRecord
    {
        private FinancialAffairs financial;
        private InstitutionLiabilities item;

        public InstitutionLiabilitiesRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(financial, organization, item.Type.ToString()),

                // 事业单位资产负债表信息记录
                new InstitutionLiabilitiesParagraph()
            };
        }

        public InstitutionLiabilitiesRecord(FinancialAffairs financial, InstitutionLiabilities item)
        {
            this.financial = financial;
            this.item = item;
        }

        public InstitutionLiabilitiesRecord(Organization organization, InstitutionLiabilities item) : this(organization)
        {
            this.item = item;
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.事业单位资产负债表信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
