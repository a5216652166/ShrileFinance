namespace Application.ViewModels.FinanceViewModels.PartnerViewModels
{
    using System;
    using System.Collections.Generic;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;

    public class PartnerViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string PrincipalPerson { get; set; }

        /// <summary>
        /// 合作时间(开始)
        /// </summary>
        public DateTime CooperationTimeStart { get; set; }

        /// <summary>
        /// 合作时间（结束）
        /// </summary>
        public DateTime CooperationTimeEnd { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<PartnerUserViewModel> PartnerUsers { get; set; } = new HashSet<PartnerUserViewModel>();

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<NewProduceViewModel> Produces { get; set; } = new HashSet<NewProduceViewModel>();
    }
}
