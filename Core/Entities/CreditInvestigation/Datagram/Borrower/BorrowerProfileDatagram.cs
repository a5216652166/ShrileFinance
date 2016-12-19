namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;

    /// <summary>
    /// 借款人概况信息报文
    /// </summary>
    public class BorrowerProfileDatagram : AbsDatagram
    {
        public BorrowerProfileDatagram()
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
