namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitRecord : AbsRecord
    {
        public ProfitRecord()
        {
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
