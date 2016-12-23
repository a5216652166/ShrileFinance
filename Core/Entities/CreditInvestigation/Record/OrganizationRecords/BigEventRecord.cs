namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.Concern;

    /// <summary>
    /// 大事信息记录
    /// </summary>
    public class BigEventRecord : AbsRecord
    {
        public BigEventRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new ConcernBaseSegment(Type, organization)
            };

            // 其他大事信息段
            foreach (var item in organization.BigEvent)
            {
                Segments.Add(new BigEventSegment(item));
            }
            ((ConcernBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected BigEventRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.大事信息记录;
            }
        }
    }
}
