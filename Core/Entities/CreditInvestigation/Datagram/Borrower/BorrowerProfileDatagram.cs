namespace Core.Entities.CreditInvestigation.Datagram.Loan
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 借款人概况信息报文
    /// </summary>
    public class BorrowerProfileDatagram : AbsDatagram
    {
        public BorrowerProfileDatagram()
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
