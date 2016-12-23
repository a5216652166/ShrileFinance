namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    /// <summary>
    /// 机构基本信息采集报文文件
    /// </summary>
    public class OrganizationDatagramFile : AbsDatagramFile
    {
        public OrganizationDatagramFile(int serialNumber) : base(serialNumber)
        {
            Datagrams = new List<AbsDatagram>
            {
                // 机构基本信息报文
                new OrganizationBaseDatagram(),

                // 家族成员信息报文
                new FamilyMemberDatagram(),

                // 财务报表信息报文
                new FinancialStatementsDatagram(),

                // 关注信息报文
                new ConcernDatagram()
            };
        }

        public override string FinancialOrganizationCode
        {
            get { return base.FinancialOrganizationCode.PadLeft(20, '0'); }
        }

        public override DatagramFileType Type
        {
            get { return DatagramFileType.机构基本信息采集报文文件; }
        }
    }
}
