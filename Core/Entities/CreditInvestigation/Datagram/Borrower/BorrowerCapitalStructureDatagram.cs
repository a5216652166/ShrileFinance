namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;

    /// <summary>
    /// 借款人资本构成信息报文
    /// </summary>
    public class BorrowerCapitalStructureDatagram : AbsDatagram
    {
        public BorrowerCapitalStructureDatagram()
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
