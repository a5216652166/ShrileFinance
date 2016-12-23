namespace Core.Entities.CreditInvestigation.Datagram
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 未使用信息采集报文
    /// </summary>
    public class UnusedDatagram : AbsDatagram
    {
        private readonly DatagramTypeEnum type;

        public UnusedDatagram(DatagramTypeEnum type)
        {
            this.type = type;
        }

        protected UnusedDatagram() : base()
        {
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return type;
            }
        }
    }
}
