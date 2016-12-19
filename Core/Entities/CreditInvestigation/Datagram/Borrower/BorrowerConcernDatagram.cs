namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 借款人关注信息报文
    /// </summary>
    public class BorrowerConcernDatagram : AbsDatagram
    {
        public BorrowerConcernDatagram()
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
