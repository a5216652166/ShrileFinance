using System;
using System.Collections.Generic;
using Core.Entities.CreditInvestigation.Datagram;

namespace Core.Entities.CreditInvestigation.DatagramFile
{
    /// <summary>
    /// 借款人基本信息文件
    /// </summary>
    public class BorrowerDatagramFile : AbsDatagramFile
    {
        public BorrowerDatagramFile(string serialNumber) : base(serialNumber)
        {
        }

        public override DatagramFileType Type
        {
            get
            {
                return DatagramFileType.借款人基本信息文件;
            }
        }

        public override ICollection<AbsDatagram> Datagrams { get; protected set; }
    }
}
