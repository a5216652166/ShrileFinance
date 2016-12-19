namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;

    /// <summary>
    /// 担保业务信息采集报文
    /// </summary>
    public class GuaranteeDatagram : AbsDatagram
    {
        public GuaranteeDatagram()
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
