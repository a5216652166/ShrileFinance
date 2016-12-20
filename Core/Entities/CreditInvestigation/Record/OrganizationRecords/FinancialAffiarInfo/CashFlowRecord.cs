namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowRecord : AbsRecord
    {
        public CashFlowRecord()
        {
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
