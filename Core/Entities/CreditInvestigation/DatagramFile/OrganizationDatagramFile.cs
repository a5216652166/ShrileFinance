using System;
using System.Collections.Generic;
using Core.Entities.CreditInvestigation.Datagram;

namespace Core.Entities.CreditInvestigation.DatagramFile
{
    /// <summary>
    /// 机构基本信息采集报文文件
    /// </summary>
    public class OrganizationDatagramFile : AbsDatagramFile
    {
        public OrganizationDatagramFile(string serialNumber) : base(serialNumber)
        {
            Datagrams = new List<AbsDatagram>
            {
                new Datagram.OrganizationDatagrams.FinancialStatementsDatagram(),
                new Datagram.OrganizationDatagrams.FamilyMemberDatagram(),
                new Datagram.OrganizationDatagrams.OrganizationBaseDatagram(),
                new Datagram.OrganizationDatagrams.ConcernDatagram()
            };
        }

        public override DatagramFileType Type
        {
            get
            {
                return DatagramFileType.机构基本信息采集报文文件;
            }
        }

        public override ICollection<AbsDatagram> Datagrams { get; protected set; }
    }
}
