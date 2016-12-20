namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;


    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : AbsRecord
    {
        public DebitInterestInfoRecord() : base()
        {
            Segments = new List<AbsSegment>() {
                // 基础段

                // 欠息业务信息段
            };
        }

        /// <summary>
        /// 基础段
        /// </summary>
        public int Base { get; set; }

        /// <summary>
        /// 欠息业务信息段
        /// </summary>
        public int MyProperty { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
