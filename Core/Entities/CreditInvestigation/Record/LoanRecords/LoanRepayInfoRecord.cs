﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Loan;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 贷款业务还款信息记录
    /// </summary>
    public class LoanRepayInfoRecord : Record
    {
        public LoanRepayInfoRecord(CreditContract credit, Loan loan, PaymentHistory payment)
        {
            int time = loan.Payments.OrderBy(m => m.CreateDate).ToList().FindIndex(m => m.Id == payment.Id) + 1;

            Segments = new List<Segment>()
            {
                // 基础段
                new CreditBaseSegment(Type, credit, payment.ActualDatePayment),

                // 还款信息段
                new RepaymentSegment(time, payment)
            };

            ((CreditBaseSegment)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected LoanRepayInfoRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.贷款业务还款信息记录;
            }
        }
    }
}
