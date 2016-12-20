namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 质押合同信息记录
    /// </summary>
    public class PledgeContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBaseSegment Base { get; set; }

        /// <summary>
        /// 质押合同信息段
        /// </summary>
        public GuaranteePledgeSegment GuaranteePledgeInfo { get; set; }

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
