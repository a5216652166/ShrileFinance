namespace Application.ViewModels.FinanceViewModels.FinancialLoanViewModels
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.Finance.Financial;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class NewProduceViewModel
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProduceTypeEnum ProduceType { get; set; }

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
        /// 月供系数
        /// </summary>
        public decimal MonthCoefficient { get; set; }

        /// <summary>
        /// 月费率
        /// </summary>
        public decimal MonthRate { get; set; }

        /// <summary>
        /// 渠道返点
        /// </summary>
        public decimal ChannelRate { get; set; }

        /// <summary>
        /// 员工提成
        /// </summary>
        public decimal SalesmanRate { get; set; }

        /// <summary>
        /// 偿还本金比例
        /// </summary>
        public IEnumerable<string> RepayPrincipal { get; set; }

        /// <summary>
        /// 偿还本金比例
        /// </summary>
        public string RepayPrincipals { get; set; }

        /// <summary>
        /// 数据录入时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        public void ParseRepayPrincipal()
        {
            if (string.IsNullOrEmpty(RepayPrincipals) == false)
            {
                RepayPrincipal = RepayPrincipals.Split('-');
            }
        }
    }
}
