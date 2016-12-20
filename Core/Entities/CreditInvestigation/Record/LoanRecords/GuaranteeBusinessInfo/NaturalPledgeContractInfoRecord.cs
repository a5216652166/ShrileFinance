﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人质押合同信息记录
    /// </summary>
    public class NaturalPledgeContractInfoRecord : AbsRecord
    {
        public NaturalPledgeContractInfoRecord()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(),

                // 自然人质押合同信息段
                new NaturalPledgeSegment()
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.自然人质押合同信息记录;
            }
        }
    }
}
