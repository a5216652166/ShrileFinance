﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 质押合同信息记录
    /// </summary>
    public class PledgeContractInfoRecord : AbsRecord
    {
        public PledgeContractInfoRecord()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(),

                // 自然人质押合同信息段
                new GuaranteePledgeSegment()
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.质押合同信息记录;
            }
        }
    }
}
