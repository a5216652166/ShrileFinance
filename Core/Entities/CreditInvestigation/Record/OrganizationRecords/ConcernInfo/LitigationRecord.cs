namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.ConcernInfo
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.Concern;

    /// <summary>
    /// 诉讼信息记录
    /// </summary>
    public class LitigationRecord : AbsRecord
    {
        public LitigationRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new ConcernBaseSegment(),

                // 诉讼信息记录
                new LitigationSegment()
            };
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.诉讼信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
