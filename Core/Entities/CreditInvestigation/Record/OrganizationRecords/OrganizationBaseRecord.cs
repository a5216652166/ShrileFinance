namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.Organization;

    /// <summary>
    /// 机构基本信息记录
    /// </summary>
    public class OrganizationBaseRecord : Record
    {
        public OrganizationBaseRecord(Organization organization) : base()
        {
            Segments = new List<Segment>()
            {
                // 基础段
                new BaseSegment(organization),
            };

            if (organization.Property != null)
            {
                // 基础属性段
                Segments.Add(new PropertySegment(organization.Property));
            }

            if (organization.State != null)
            {
                // 机构状态段
                Segments.Add(new OrganizationStateSegment(organization.State));
            }

            if (organization.Contact != null)
            {
                // 联络信息段
                Segments.Add(new OrganizationContactSegment(organization.Contact));
            }

            if (organization.Parent != null)
            {
                // 上级机构（主管单位）段
                Segments.Add(new ParentSegment(organization.Parent));
            }

            // 高管及主要关系人段
            foreach (var item in organization.Managers)
            {
                Segments.Add(new ManagerSegment(item));
            }

            // 重要股东段
            foreach (var item in organization.Shareholders)
            {
                Segments.Add(new StockholderSegment(item));
            }

            // 主要关联企业段
            foreach (var item in organization.AssociatedEnterprises)
            {
                Segments.Add(new AssociatedEnterpriseSegment(item));
            }
        }

        protected OrganizationBaseRecord() : base()
        {
        }

        public override RecordTypeEnum Type => RecordTypeEnum.机构基本信息记录;
    }
}
