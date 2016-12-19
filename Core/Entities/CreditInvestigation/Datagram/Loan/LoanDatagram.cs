namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;

    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class LoanDatagram : AbsDatagram
    {
        public LoanDatagram()
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
