namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class BalanceSheetRecord : AbsRecord
    {
        public BalanceSheetRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(),

                // 2007版资产负债表段
                new LiabilitiesParagraph()
            };
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
