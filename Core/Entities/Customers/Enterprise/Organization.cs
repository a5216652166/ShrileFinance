﻿namespace Core.Entities.Customers.Enterprise
{
    using System;
    using System.Collections.Generic;

    public class Organization : Customer, IEnterprise
    {
        public Organization()
        {
            Managers = new List<Manager>();
            Shareholders = new List<Stockholder>();
            AssociatedEnterprises = new List<AssociatedEnterprise>();

            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        public string TaxpayerIdentifyLandNumber { get; set; }

        /// <summary>
        /// 中征码
        /// </summary>
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 是否有上级机构
        /// </summary>
        public bool HasParent
        {
            get { return Parent != null; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 机构属性
        /// </summary>
        public OrganizationProperties Property { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public OrganizationState State { get; set; }

        /// <summary>
        /// 联络信息
        /// </summary>
        public OrganizationContact Contact { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public OrganizationParent Parent { get; set; }

        /// <summary>
        /// 高级主管
        /// </summary>
        public List<Manager> Managers { get; set; }

        /// <summary>
        /// 重要股东
        /// </summary>
        public List<Stockholder> Shareholders { get; set; }

        /// <summary>
        /// 关联企业
        /// </summary>
        public List<AssociatedEnterprise> AssociatedEnterprises { get; set; }
    }
}
