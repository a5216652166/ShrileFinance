namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    public class BorrowerDatagramFile : AbsDatagramFile
    {
        public BorrowerDatagramFile(int serialNumber) : base(serialNumber)
        {
            // 财务报表信息报文, 关注信息报文
            Datagrams = new List<AbsDatagram>
            {
                new FinancialStatementsDatagram(),
                new ConcernDatagram()
            };
        }

        public override DatagramFileType Type
        {
            get { return DatagramFileType.借款人基本信息文件; }
        }
    }
}
