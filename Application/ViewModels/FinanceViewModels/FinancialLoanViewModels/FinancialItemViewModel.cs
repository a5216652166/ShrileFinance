namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;

    /// <summary>
    /// 融资项
    /// </summary>
    public class FinanceItemViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 融资额
        /// </summary>
        public decimal Principal { get; set; }
    }
}
