namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System;
    using System.Collections.Generic;
    using Datagram;
    using Datagram.OrganizationDatagrams;

    /// <summary>
    /// 机构基本信息采集报文文件
    /// </summary>
    public class OrganizationDatagramFile : DatagramFile
    {
        ////public OrganizationDatagramFile(int serialNumber) : base(serialNumber)
        ////{
        ////    // 机构基本信息报文, 家族成员信息报文
        ////    Datagrams = new List<Datagram>
        ////    {
        ////        new OrganizationBaseDatagram(),
        ////        new FamilyMemberDatagram()
        ////    };
        ////}

        protected OrganizationDatagramFile()
        {
        }

        public override DatagramFileType Type => DatagramFileType.机构基本信息采集报文文件;

        public override string FinancialOrganizationCode => base.FinancialOrganizationCode.PadLeft(20, '0');

        public static OrganizationDatagramFile Create() =>
            new OrganizationDatagramFile()
            {
                DateCreated = DateTime.Now,
                Datagrams = new List<Datagram>
                {
                    // 机构基本信息报文, 家族成员信息报文
                    new OrganizationBaseDatagram(),
                    new FamilyMemberDatagram()
                }
            };
    }
}
