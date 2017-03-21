namespace Core.Entities.CreditInvestigation.Datagram
{
    /// <summary>
    /// 未使用信息采集报文
    /// </summary>
    public class UnusedDatagram : Datagram
    {
        public UnusedDatagram(DatagramTypeEnum type)
        {
            UnusedType = type;
        }

        protected UnusedDatagram() : base()
        {
        }

        public DatagramTypeEnum UnusedType { get; private set; }

        public override DatagramTypeEnum Type => UnusedType;
    }
}
