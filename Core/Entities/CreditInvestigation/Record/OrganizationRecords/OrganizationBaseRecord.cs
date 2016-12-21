﻿namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.Organization;

    /// <summary>
    /// 机构基本信息记录
    /// </summary>
    public class OrganizationBaseRecord : AbsRecord
    {
        public OrganizationBaseRecord(Organization organization) : base()
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

                // 上级机构（主管单位）段
                new ParentSegment()
            };

            // 高管及主要关系人段
            foreach (var item in organization.Managers)
            {
                Segments.Add(new ManagerSegment());
            }

            // 重要股东段
            foreach (var item in organization.Shareholders)
            {
                Segments.Add(new StockholderSegment());
            }

            // 主要关联企业段
            foreach (var item in organization.AssociatedEnterprises)
            {
                Segments.Add(new AssociatedEnterpriseSegment(item));
            }
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
