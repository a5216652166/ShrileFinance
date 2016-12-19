namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 家族成员信息报文
    /// </summary>
    public class FamilyMemberDatagram : AbsDatagram
    {
        public override DatagramTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
