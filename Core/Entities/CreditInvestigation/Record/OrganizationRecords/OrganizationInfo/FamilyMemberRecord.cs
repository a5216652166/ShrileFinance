namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.OrganizationInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 家族成员信息记录
    /// </summary>
    public class FamilyMemberRecord : AbsRecord
    {
        public FamilyMemberRecord()
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
