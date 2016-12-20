namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowRecord : AbsRecord
    {
        public CashFlowRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(),

                // 2007版现金流量表段
                new CashFlowParagraph()
            };
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
