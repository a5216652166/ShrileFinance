namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.ConcernInfo
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.BorrowMessage.Concern;

    /// <summary>
    /// 诉讼信息记录
    /// </summary>
    public class LitigationRecord : AbsRecord
    {
        public LitigationRecord(CreditContract credit) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new ConcernBaseSegment(Type, credit)
            };

            // 诉讼信息段
            foreach (var item in credit.Organization.BigEvent)
            {
                Segments.Add(new BigEventSegment());
            }
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
