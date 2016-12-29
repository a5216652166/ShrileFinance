namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    /// <summary>
    /// 机构基本信息采集报文文件
    /// </summary>
    public class OrganizationDatagramFile : DatagramFile
    {
        public OrganizationDatagramFile(int serialNumber) : base(serialNumber)
        {
            // 机构基本信息报文, 家族成员信息报文
            Datagrams = new List<Datagram>
            {
                new OrganizationBaseDatagram(),
                new FamilyMemberDatagram()
            };
        }

        protected OrganizationDatagramFile()
        {
        }

        public override DatagramFileType Type
        {
            get { return DatagramFileType.机构基本信息采集报文文件; }
        }

        public override string FinancialOrganizationCode
        {
            get { return base.FinancialOrganizationCode.PadLeft(20, '0'); }
        }
    }
}
