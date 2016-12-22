namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 家族成员信息报文
    /// </summary>
    public class FamilyMemberDatagram : AbsDatagram
    {
        public FamilyMemberDatagram() : base()
        {
            ////Records = new List<AbsRecord>()
            ////{
            ////    // 家族成员信息记录
            ////    new FamilyMemberRecord()
            ////};
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.家族成员信息报文;
            }
        }
    }
}
