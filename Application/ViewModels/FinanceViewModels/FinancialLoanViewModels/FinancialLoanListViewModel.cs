namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;
    using Core.Entities.Finance.Financial;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class FinancialLoanListViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 放款编号
        /// </summary>
        public string LoanNum { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LoanDateEnum RepayDate { get; set; }

        /// <summary>
        /// 放款状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StateEnum State { get; set; } = StateEnum.正常运营;

        /// <summary>
        /// 融资总额
        /// </summary>
        public decimal FinancialAmounts { get; set; }

        /// <summary>
        /// 产品代码
        /// </summary>
        public string NewProduceCode { get; set; }

        /// <summary>
        /// 产品期限
        /// </summary>
        public int NewProduceTimeLimit { get; set; }
    }
}
