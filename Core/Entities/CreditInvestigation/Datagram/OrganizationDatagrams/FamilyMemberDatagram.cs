namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    /// <summary>
    /// 家族成员信息报文
    /// </summary>
    public class FamilyMemberDatagram : OrganizationBaseDatagram
    {
        public FamilyMemberDatagram() : base()
        {
        }

        public override DatagramTypeEnum Type
        {
            get { return DatagramTypeEnum.家族成员信息报文; }
        }
    }
}
