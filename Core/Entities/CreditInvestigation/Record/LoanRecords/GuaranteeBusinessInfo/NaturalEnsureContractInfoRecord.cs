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
        public NaturalEnsureContractInfoRecord()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(),

                // 自然人保证合同信息段
                new NaturalGuaranteeSegment()
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人保证合同信息记录;
            }
        }
    }
}
