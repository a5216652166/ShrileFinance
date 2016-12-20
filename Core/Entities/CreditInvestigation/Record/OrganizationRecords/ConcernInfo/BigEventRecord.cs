namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.ConcernInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 大事件信息记录
    /// </summary>
    public class BigEventRecord : AbsRecord
    {
        public BigEventRecord()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.大事件信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
