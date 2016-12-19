namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 关注信息报文
    /// </summary>
    public class ConcernDatagram : AbsDatagram
    {
        public ConcernDatagram()
        {
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.关注信息采集报文;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
