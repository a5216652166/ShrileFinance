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
        public CreditBase Base { get; set; }

        /// <summary>
        /// 合同信息段
        /// </summary>
        public CreditContract ContractInfo { get; set; }

        /// <summary>
        /// 合同金额信息段（可多个）
        /// </summary>
        public ICollection<CreditContractAmount> ContractAmounts { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
