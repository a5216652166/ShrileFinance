namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;

    /// <summary>
    /// 欠息信息采集报文
    /// </summary>
    public class DebitInterestDatagram : AbsDatagram
    {
        public DebitInterestDatagram()
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
