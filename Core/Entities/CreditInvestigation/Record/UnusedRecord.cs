namespace Core.Entities.CreditInvestigation.Record
{
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 未使用信息记录
    /// </summary>
    public class UnusedRecord : AbsRecord
    {
        public UnusedRecord() : base()
        {
            Segments = new List<AbsSegment>();
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.未使用信息记录;
            }
        }
    }
}
