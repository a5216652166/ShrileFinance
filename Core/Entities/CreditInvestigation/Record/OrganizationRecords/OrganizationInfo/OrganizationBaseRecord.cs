namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 机构基本信息记录
    /// </summary>
    public class OrganizationBaseRecord : AbsRecord
    {
        public OrganizationBaseRecord()
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
