namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位资产负债表信息记录
    /// </summary>
    public class InstitutionLiabilitiesRecord : Record
    {
        public InstitutionLiabilitiesRecord(Organization organization, InstitutionLiabilities item) : base()
        {
            var baseParagraph = new BaseParagraph(organization.FinancialAffairs, organization, item.Type.ToString(), Type);

            Segments = new List<Segment>()
            {
                // 基础段
               baseParagraph,

                // 事业单位资产负债表信息记录
                new InstitutionLiabilitiesParagraph(item)
            };

            ((BaseParagraph)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected InstitutionLiabilitiesRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.事业单位资产负债表信息记录;
            }
        }
    }
}
