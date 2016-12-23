namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.Organization;

    /// <summary>
    /// 家族成员信息记录
    /// </summary>
    public class FamilyMemberRecord : AbsRecord
    {
        public FamilyMemberRecord(Manager manager, FamilyMember familyMember) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new FamilySegment(manager,familyMember)
            };
        }

        public FamilyMemberRecord(Stockholder manager, FamilyMember familyMember) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new FamilySegment(manager,familyMember)
            };
        }

        protected FamilyMemberRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.家族成员信息记录;
            }
        }
    }
}
