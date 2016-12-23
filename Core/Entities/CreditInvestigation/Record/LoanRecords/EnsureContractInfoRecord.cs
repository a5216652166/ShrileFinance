﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 保证合同信息记录
    /// </summary>
    public class EnsureContractInfoRecord : AbsRecord
    {
        public EnsureContractInfoRecord(CreditContract credit, GuarantyContract guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment(Type, credit),

                // 保证合同信息段
                new GuaranteeSegment(credit, guaranty)
            };
            ((GuaranteeBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.保证合同信息记录;
            }
        }
    }
}
