namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System.Collections.Generic;
    using Record;
    using Record.OrganizationRecords;

    /// <summary>
    /// 机构基本信息报文
    /// </summary>
    public class OrganizationBaseDatagram : AbsDatagram
    {
        public OrganizationBaseDatagram() : base()
        {
            ////Records = new List<AbsRecord>()
            ////{
            ////    // 机构基本信息记录
            ////    new OrganizationBaseRecord()
            ////};
        }

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
