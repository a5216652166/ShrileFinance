namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using Core.Entities.Finance;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class FinancialLoanViewModel
    {
        public Guid Id { get; set; }

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
        /// 资产类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AssetTypeEnum AssetType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 融资项
        /// </summary>
        public FinancialItemViewModel FinancialItem { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public NewProduceViewModel NewProduce { get; set; }
    }
}
