namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 借款人财务报表信息报文
    /// </summary>
    public class BorrowerFinancialStatementsDatagram : AbsDatagram
    {
        public BorrowerFinancialStatementsDatagram()
        {
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
