﻿namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.ConcernInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 诉讼信息记录
    /// </summary>
    public class LitigationRecord : AbsRecord
    {
        public LitigationRecord()
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
