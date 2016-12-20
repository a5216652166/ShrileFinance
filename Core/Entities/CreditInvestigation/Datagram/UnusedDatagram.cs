namespace Core.Entities.CreditInvestigation.Datagram
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 未使用信息采集报文
    /// </summary>
    public class UnusedDatagram : AbsDatagram
    {
        public UnusedDatagram(DatagramTypeEnum type)
        {
            Type = type;
        }

        public override ICollection<AbsRecord> Records { get; protected set; }

        public override DatagramTypeEnum Type { get;}
    }
}
