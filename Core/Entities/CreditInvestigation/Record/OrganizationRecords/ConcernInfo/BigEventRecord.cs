namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.ConcernInfo
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.Concern;

    /// <summary>
    /// 大事信息记录
    /// </summary>
    public class BigEventRecord : AbsRecord
    {
        public BigEventRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new ConcernBaseSegment(),

                // 其他大事信息段
                new BigEventSegment()
            };
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.大事信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
