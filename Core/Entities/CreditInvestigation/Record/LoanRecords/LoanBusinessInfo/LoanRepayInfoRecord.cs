namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务还款信息记录
    /// </summary>
    public class LoanRepayInfoRecord:AbsRecord
    {
        /// <summary>
        ///  基础段
        /// </summary>
        public CreditBase Base { get; set; }

        /// <summary>
        /// 还款信息段
        /// </summary>
        public Repayment RepayInfo { get; set; }

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
