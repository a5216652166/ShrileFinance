namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务合同信息记录
    /// </summary>
    public class LoanContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public CreditBaseSegment Base { get; set; }

        /// <summary>
        /// 合同信息段
        /// </summary>
        public CreditContractSegment ContractInfo { get; set; }

        /// <summary>
        /// 合同金额信息段（可多个）
        /// </summary>
        public ICollection<CreditContractAmountSegment> ContractAmounts { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
