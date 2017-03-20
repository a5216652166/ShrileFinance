namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;
    using System.Collections.Generic;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using Core.Entities.Finance.Financial;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class FinancialLoanViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 放款编号
        /// </summary>
        public string LoanNum { get; set; }

        /// <summary>
        /// 放款日
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
        public StateEnum State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 融资项
        /// </summary>
        public IEnumerable<FinancialItemViewModel> FinancialItem { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public NewProduceViewModel NewProduce { get; set; }
    }
}
