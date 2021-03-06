﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 质押合同信息记录
    /// </summary>
    public class PledgeContractInfoRecord : Record
    {
        public PledgeContractInfoRecord(CreditContract credit, GuarantyContractPledge guaranty) : base()
        {
            Segments = new List<Segment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 自然人质押合同信息段
                new GuaranteePledgeSegment(guaranty, credit)
            };

            ((GuaranteeBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected PledgeContractInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.质押合同信息记录;
            }
        }
    }
}
