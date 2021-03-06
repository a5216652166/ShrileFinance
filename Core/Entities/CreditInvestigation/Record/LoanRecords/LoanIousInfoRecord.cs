﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务借据信息记录
    /// </summary>
    public class LoanIousInfoRecord : Record
    {
        public LoanIousInfoRecord(Loan loan, CreditContract credit, DateTime datetime)
        {
            var balance = loan.Principle - loan.Payments.Where(m => m.ActualDatePayment <= datetime).Sum(m => m.ActualPaymentPrincipal);

            Segments = new List<Segment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit, datetime),

                // 借据信息段
                new LoanSegment(loan, balance)
            };

            ((CreditBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected LoanIousInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type => RecordTypeEnum.贷款业务借据信息记录;
    }
}
