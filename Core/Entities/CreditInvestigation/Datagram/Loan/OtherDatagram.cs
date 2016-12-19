namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;

    /// <summary>
    /// 其他报文
    /// </summary>
    public class OtherDatagram : AbsDatagram
    {
        public OtherDatagram()
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
