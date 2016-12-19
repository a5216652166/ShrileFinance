namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;

    /// <summary>
    /// 借款人关注信息报文
    /// </summary>
    public class BorrowerConcernDatagram : AbsDatagram
    {
        public BorrowerConcernDatagram()
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
