namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    public class BorrowerDatagramFile : DatagramFile
    {
        public BorrowerDatagramFile(int serialNumber) : base(serialNumber)
        {
            // 概况信息采集报文, 资本构成信息采集报文, 财务报表信息报文, 关注信息报文
            Datagrams = new List<Datagram>
            {
                new UnusedDatagram((DatagramTypeEnum)1),
                new UnusedDatagram((DatagramTypeEnum)2),
                new FinancialStatementsDatagram(),
                new ConcernDatagram()
            };
        }

        protected BorrowerDatagramFile()
        {
        }

        public override DatagramFileType Type
        {
            get { return DatagramFileType.借款人基本信息文件; }
        }
    }
}
