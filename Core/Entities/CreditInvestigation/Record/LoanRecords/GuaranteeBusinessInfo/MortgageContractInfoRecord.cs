namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using Segment.CreditMessage;

    /// <summary>
    /// 抵押合同信息记录
    /// </summary>
    public class MortgageContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

        /// <summary>
        /// 抵押合同信息段
        /// </summary>
        //public Guarantee GuaranteeInfo { get; set; }
    }
}
