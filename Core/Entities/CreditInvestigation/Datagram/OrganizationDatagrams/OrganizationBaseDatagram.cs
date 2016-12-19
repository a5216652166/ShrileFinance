namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 机构基本信息报文
    /// </summary>
    public class OrganizationBaseDatagram : AbsDatagram
    {
        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.机构基本信息报文;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
