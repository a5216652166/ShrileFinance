namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.Collections.Generic;

    public class OrganizationViewModel
    {
        public OrganizationViewModel()
        {
            Managers = new HashSet<ManagerViewModel>();
            Shareholders = new HashSet<StockholderViewModel>();
            AssociatedEnterprises = new HashSet<AssociatedEnterpriseViewModel>();
            Litigation = new HashSet<LitigationViewModel>();
            BigEvent = new HashSet<BigEventViewModel>();
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 机构基础
        /// </summary>
        public BaseViewModel Base { get; set; }

        /// <summary>
        /// 机构属性
        /// </summary>
        public PropertiesViewModel Property { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public StateViewModel State { get; set; }

        /// <summary>
        /// 机构联络
        /// </summary>
        public ContactViewModel Contact { get; set; }

        /// <summary>
        /// 高级主管
        /// </summary>
        public IEnumerable<ManagerViewModel> Managers { get; set; }

        /// <summary>
        /// 重要股东
        /// </summary>
        public IEnumerable<StockholderViewModel> Shareholders { get; set; }

        /// <summary>
        /// 主要关联企业
        /// </summary>
        public IEnumerable<AssociatedEnterpriseViewModel> AssociatedEnterprises { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public ParentViewModel Parent { get; set; }

        /// <summary>
        /// 财务
        /// </summary>
        public FinancialAffairsViewModel FinancialAffairs { get; set; }

        /// <summary>
        /// 诉讼事件
        /// </summary>
        public IEnumerable<LitigationViewModel> Litigation { get; set; }

        /// <summary>
        /// 大事件
        /// </summary>
        public IEnumerable<BigEventViewModel> BigEvent { get; set; }
    }
}
