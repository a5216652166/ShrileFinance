namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;
    using Core.Entities.Finance;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class FinancialLoanListViewModel
    {
        public Guid Id { get; set; }

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
        /// 资产类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AssetTypeEnum AssetType { get; set; } = AssetTypeEnum.默认;

        /// <summary>
        /// 融资项名称
        /// </summary>
        public string FinancialItemName { get; set; }

        /// <summary>
        /// 融资额
        /// </summary>
        public decimal FinancialAmount { get; set; }

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
