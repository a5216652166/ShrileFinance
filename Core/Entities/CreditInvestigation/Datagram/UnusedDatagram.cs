namespace Core.Entities.CreditInvestigation.Datagram
{
    using System;
    using System.Collections.Generic;
    using Record;

    public class UnusedDatagram : AbsDatagram
    {
        public override ICollection<AbsRecord> Records { get; protected set; }

        public override DatagramTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
