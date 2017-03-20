namespace Application.ViewModels.FinanceViewModels.ProduceViewModels
{
    using System;
    using Core.Entities.Finance.Financial;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class NewProduceListViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 期限
        /// </summary>
        public int TimeLimit { get; set; }

        /// <summary>
        /// 间隔
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 名义利率
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal MarginRate { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Poundage { get; set; }

        /// <summary>
        /// 租赁方式
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LeaseTypeEnum LeaseType { get; set; }

        /// <summary>
        /// 月费率
        /// </summary>
        public decimal MonthRate { get; set; }

        /// <summary>
        /// 年费率
        /// </summary>
        public decimal YearRate { get; set; }

        /// <summary>
        /// 渠道返点
        /// </summary>
        public decimal ChannelRate { get; set; }

        /// <summary>
        /// 员工提成
        /// </summary>
        public decimal SalesmanRate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
