namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务合同信息记录
    /// </summary>
    public class LoanContractInfoRecord : Record
    {
        public LoanContractInfoRecord(CreditContract credit, DateTime datetime)
        {
            Segments = new List<Segment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit, datetime),

                // 合同信息段
                new CreditContractSegment(credit),

                // 合同金额信息段（币种CNY）
                new CreditContractAmountSegment(credit)
            };

            ((CreditBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected LoanContractInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type => RecordTypeEnum.贷款业务合同信息记录;
    }
}
