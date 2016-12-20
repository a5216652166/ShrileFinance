namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人质押合同信息记录
    /// </summary>
    public class NaturalPledgeContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBaseSegment Base { get; set; }

        /// <summary>
        /// 自然人质押合同信息段
        /// </summary>
        public NaturalPledgeSegment NaturalPledgeInfo { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
