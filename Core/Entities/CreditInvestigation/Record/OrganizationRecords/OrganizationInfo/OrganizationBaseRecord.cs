namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.Organization;

    /// <summary>
    /// 机构基本信息记录
    /// </summary>
    public class OrganizationBaseRecord : AbsRecord
    {
        public OrganizationBaseRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseSegment(),

                // 基础属性段
                new PropertySegment(),

                // 机构状态段
                new OrganizationStateSegment(),

                // 联络信息段
                new OrganizationContactSegment(),

                // 高管及主要关系人段
                new ManagerSegment(),

                // 重要股东段
                new StockholderSegment(),

                // 主要关联企业段
                new AssociatedEnterpriseSegment(),

                // 上级机构（主管单位）段
                new ParentSegment()
            };
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.机构基本信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
