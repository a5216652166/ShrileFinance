namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;


    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public int Base { get; set; }

        /// <summary>
        /// 欠息业务信息段
        /// </summary>
        public int MyProperty { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
