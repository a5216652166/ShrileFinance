namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;

    /// <summary>
    /// 借款人财务报表信息报文
    /// </summary>
    public class BorrowerFinancialStatementsDatagram : AbsDatagram
    {
        public BorrowerFinancialStatementsDatagram()
        {
        }

        public override byte Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
