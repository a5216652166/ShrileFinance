namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using Segment.CreditMessage;

    /// <summary>
    /// 保证合同信息记录
    /// </summary>
    public class EnsureContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

        /// <summary>
        /// 保证合同信息段
        /// </summary>
        public Guarantee GuaranteeInfo { get; set; }
    }
}
