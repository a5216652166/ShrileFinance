﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务借据信息记录
    /// </summary>
    public class LoanIousInfoRecord:AbsRecord
    {
        /// <summary>
        ///  基础段
        /// </summary>
        public CreditBase Base { get; set; }

        /// <summary>
        /// 借据信息段
        /// </summary>
        public Loan IousInfo { get; set; }
    }
}
