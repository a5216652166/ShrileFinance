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
        public LoanContractInfoRecord()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new CreditBaseSegment(),

                // 合同信息段
                new CreditContractSegment(),

                // 合同金额信息段（可多个）
            };
        }

        /// <summary>
        /// 合同金额信息段（可多个）
        /// </summary>
        public ICollection<CreditContractAmountSegment> ContractAmounts { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.贷款业务合同信息记录;
            }
        }
    }
}
