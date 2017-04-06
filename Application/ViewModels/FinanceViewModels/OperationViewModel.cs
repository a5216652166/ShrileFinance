namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using Core.Entities.Vehicle;

    /// <summary>
    /// 运营
    /// </summary>
    public class OperationViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 融资产品项
        /// </summary>
        public virtual IEnumerable<FinanceItemViewModel> FinancialItem { get; set; }

        /// <summary>
        /// 选择还款日
        /// </summary>
        [Required(ErrorMessage = "选择还款日 不可为空")]
        public int? RepaymentDate { get; set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        [Required(ErrorMessage = "首次租金支付日期 不可为空")]
        public DateTime? RepayRentDate { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        [Required(ErrorMessage = "保证金 不可为空")]
        public decimal? Bail { get; set; }

        /// <summary>
        /// 先付月供
        /// </summary>
        [Required(ErrorMessage = "先付月供 不可为空")]
        public decimal? PayMonthly { get; set; }

        /// <summary>
        /// 一次性付息
        /// </summary>
        [Required(ErrorMessage = "一次性付息 不可为空")]
        public decimal? OnePayInterest { get; set; }

        /// <summary>
        /// 实际用款额
        /// </summary>
        [Required(ErrorMessage = "实际用款额 不可为空")]
        public decimal? ActualAmount { get; set; }

        /// <summary>
        /// 客户保证金比例
        /// </summary>
        public decimal CustomerBailRatio { get; set; }

        /// <summary>
        /// 放款主体
        /// </summary>
        [Required(ErrorMessage = "放款主体 不可为空")]
        public string LoanPrincipal { get; set; }

        /// <summary>
        /// 放款账户
        /// </summary>
        public string CreditAccountName { get; set; }

        /// <summary>
        /// 放款账户开户行
        /// </summary>
        public string CreditBankName { get; set; }

        /// <summary>
        /// 放款账户卡号
        /// </summary>
        public string CreditBankCard { get; set; }

        /// <summary>
        /// 合同Json
        /// </summary>
        public string ContactJson { get; set; }

        /// <summary>
        /// 还款账户
        /// </summary>
        public string CustomerAccountName { get; set; }

        /// <summary>
        /// 还款账户开户行
        /// </summary>
        public string CustomerBankName { get; set; }

        /// <summary>
        /// 还款账户卡号
        /// </summary>
        public string CustomerBankCard { get; set; }

        /// <summary>
        /// 节点类型（运营/客户）
        /// </summary>
        public string NodeType { get; set; }

        /// <summary>
        /// 注册登记日期
        /// </summary>
        public string RegisterDate { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public int? RunningMiles { get; set; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        public string FactoryDate { get; set; }

        /// <summary>
        /// 业务种类
        /// </summary>
        public Vehicle.BusinessTypeEnum BusinessType { get; set; }

        /// <summary>
        /// 上牌城市
        /// </summary>
        public string RegisterCity { get; set; }

        /// <summary>
        /// 车况
        /// </summary>
        public Vehicle.ConditionEnum Condition { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string FrameNo { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNo { get; set; }
    }
}
