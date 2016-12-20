namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;

    /// <summary>
    /// 未使用信息采集报文文件
    /// </summary>
    public class UnusedDatagramFile : AbsDatagramFile
    {
        public UnusedDatagramFile(string serialNumber) : base(serialNumber)
        {
            Datagrams = new List<AbsDatagram>()
            {
                // 未使用信息采集报文
                new UnusedDatagram()
            };
        }

        public override ICollection<AbsDatagram> Datagrams { get; protected set; }

        public override DatagramFileType Type
        {
            get
            {
                return DatagramFileType.未使用信息采集报文文件;
            }
        }
    }
}
