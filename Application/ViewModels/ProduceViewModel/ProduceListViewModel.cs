namespace Application.ViewModels.ProduceViewModel
{
    using System;
    using Core.Entities.Produce;

    public class ProduceListViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 产品代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public OldProduce.RepaymentMethodEnum RepaymentMethod { get; set; }

        public string RepaymentMethodDesc {
            get { return RepaymentMethod.ToString(); }
        }

        /// <summary>
        /// 融资期限
        /// </summary>
        public int FinancingPeriods { get; set; }

        /// <summary>
        /// 融资比例下线
        /// </summary>
        public decimal MinFinancingRatio { get; set; }

        /// <summary>
        /// 融资比例上限
        /// </summary>
        public decimal MaxFinancingRatio { get; set; }

        /// <summary>
        /// 尾款比例
        /// </summary>
        public decimal FinalRatio { get; set; }

        /// <summary>
        /// 名义利率
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// 费率
        /// </summary>
        public decimal CostRate { get; set; }

        /// <summary>
        /// 客户保证金比例
        /// </summary>
        public decimal CustomerBailRatio { get; set; }

        /// <summary>
        /// 数据添加时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
