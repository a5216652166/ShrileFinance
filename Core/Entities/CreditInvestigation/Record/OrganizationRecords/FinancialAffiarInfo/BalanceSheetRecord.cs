namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class BalanceSheetRecord : AbsRecord
    {
        public BalanceSheetRecord()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
