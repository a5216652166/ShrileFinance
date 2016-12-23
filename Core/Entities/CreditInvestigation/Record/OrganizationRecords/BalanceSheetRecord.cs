namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class BalanceSheetRecord : AbsRecord
    {
        public BalanceSheetRecord(Organization organization, Liabilities item)
        {
            var baseParagraph = new BaseParagraph(organization.FinancialAffairs, organization, item.Type.ToString());

            Segments = new List<AbsSegment>()
            {
                // 基础段
                baseParagraph,
                // 2007版资产负债表段
                new LiabilitiesParagraph(item)
            };

            ((BaseParagraph)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected BalanceSheetRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.资产负债表信息记录2007版;
            }
        }
    }
}
