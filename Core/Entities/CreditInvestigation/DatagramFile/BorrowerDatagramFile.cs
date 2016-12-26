namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    public class BorrowerDatagramFile : AbsDatagramFile
    {
        public BorrowerDatagramFile(int serialNumber) : base(serialNumber)
        {
            // 概况信息采集报文, 资本构成信息采集报文, 财务报表信息报文, 关注信息报文
            Datagrams = new List<AbsDatagram>
            {
                new UnusedDatagram(DatagramTypeEnum.机构基本信息报文),
                new UnusedDatagram(DatagramTypeEnum.家族成员信息报文),
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
