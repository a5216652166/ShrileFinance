namespace Core.Entities.CreditInvestigation.Datagram
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 未使用信息采集报文
    /// </summary>
    public class UnusedDatagram : AbsDatagram
    {
        public UnusedDatagram()
        {
            Records = new List<AbsRecord>() {
                new UnusedRecord()
            };
        }

        public override ICollection<AbsRecord> Records { get; protected set; }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.未使用信息采集报文;
            }
        }
    }
}
