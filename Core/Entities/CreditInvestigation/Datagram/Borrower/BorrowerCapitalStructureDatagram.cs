namespace Core.Entities.CreditInvestigation.Datagram.Borrower
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 借款人资本构成信息报文
    /// </summary>
    public class BorrowerCapitalStructureDatagram : AbsDatagram
    {
        public BorrowerCapitalStructureDatagram()
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
