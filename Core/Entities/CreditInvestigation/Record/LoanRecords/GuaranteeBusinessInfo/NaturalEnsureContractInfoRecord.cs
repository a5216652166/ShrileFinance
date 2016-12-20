namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;


    /// <summary>
    /// 自然人保证合同信息记录
    /// </summary>
    public class NaturalEnsureContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

        /// <summary>
        /// 自然人保证合同信息段
        /// </summary>
        public NaturalGuarantee NaturalGuaranteeInfo { get; set; }

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
