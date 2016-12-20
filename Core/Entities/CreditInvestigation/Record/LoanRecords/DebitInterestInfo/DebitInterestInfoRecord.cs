namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;


    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : AbsRecord
    {
        public DebitInterestInfoRecord() : base()
        {
            Segments = new List<AbsSegment>() {
                // 基础段
                new DebitInterestBaseSegment(),

                // 欠息业务信息段
                new DebitInterestSegment()
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.欠息信息记录;
            }
        }
    }
}
