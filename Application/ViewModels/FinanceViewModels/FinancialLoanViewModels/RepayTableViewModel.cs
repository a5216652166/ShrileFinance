﻿namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    public class RepayTableViewModel
    {
        /// <summary>
        /// 期数编号（第nPerNum期）
        /// </summary>
        public int? NPerNum { get; set; }

        /// <summary>
        /// 计划还款本金
        /// </summary>
        public decimal? PlanPrincipal { get; set; }

        /// <summary>
        /// 实际还款本金
        /// </summary>
        public decimal? Principal { get; set; }

        /// <summary>
        /// 计划还款利息
        /// </summary>
        public decimal? PlanInterest { get; set; }

        /// <summary>
        /// 实际还款利息
        /// </summary>
        public decimal? Interest { get; set; }

        /// <summary>
        /// 计划还款金额
        /// </summary>
        public decimal? PlanAmount { get; set; }

        /// <summary>
        /// 实际还款金额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 计划还款余额
        /// </summary>
        public decimal? PlanAmountBlance { get; set; }

        /// <summary>
        /// 实际还款余额
        /// </summary>
        public decimal? AmountBlance { get; set; }

        /// <summary>
        /// 罚息
        /// </summary>
        public decimal? PenaltyInterest { get; set; }
    }
}
