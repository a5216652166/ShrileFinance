namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.Concern;

    /// <summary>
    /// 诉讼信息记录
    /// </summary>
    public class LitigationRecord : AbsRecord
    {
        public LitigationRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new ConcernBaseSegment(Type, organization)
            };

            // 诉讼信息段
            foreach (var item in organization.Litigation)
            {
                Segments.Add(new LitigationSegment(item));
            }

            ((ConcernBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.诉讼信息记录;
            }
        }
    }
}
