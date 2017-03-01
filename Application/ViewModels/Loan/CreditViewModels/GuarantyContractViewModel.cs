namespace Application.ViewModels.Loan.CreditViewModel
{
    using System;
    using Core.Entities.Loan;

    /// <summary>
    /// 担保合同(协调后台)
    /// </summary>
    public class GuarantyContractViewModel : IEntityViewModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime? SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        public GuaranteeFormEnum? GuaranteeForm { get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public EffectiveStateEnum? EffectiveState { get; set; }

        /// <summary>
        /// 保证金额
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 担保人
        /// </summary>
        public GuarantorViewModel Guarantor { get; set; }
    }
}
