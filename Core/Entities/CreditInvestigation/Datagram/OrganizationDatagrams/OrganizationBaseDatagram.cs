namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System.Text;

    /// <summary>
    /// 机构基本信息报文
    /// </summary>
    public class OrganizationBaseDatagram : AbsDatagram
    {
        public OrganizationBaseDatagram() : base()
        {
        }

        public override DatagramTypeEnum Type
        {
            get { return DatagramTypeEnum.机构基本信息报文; }
        }

        protected override StringBuilder GenerateHeader()
        {
            var builder = new StringBuilder();

            builder.Append(HeaderIdentity);
            builder.Append(FormatVersion);
            builder.Append(FinancialOrganizationCode.PadRight(20));
            builder.Append(DateCreated.ToString("yyyyMMddHHmmss"));
            builder.Append(51);
            builder.Append(Type.ToString("D"));
            builder.Append(0);
            builder.Append(string.Empty.PadLeft(30));
            builder.Append(string.Empty.PadLeft(25));
            builder.Append(Reserved.PadLeft(30));

            return builder;
        }
    }
}
