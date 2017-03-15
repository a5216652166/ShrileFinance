namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using Core.Entities.Finance;

    public class NewProduceListViewModel
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// 期限
        /// </summary>
        public int TimeLimit { get; protected set; }

        /// <summary>
        /// 间隔
        /// </summary>
        public int Interval { get; protected set; }

        /// <summary>
        /// 名义利率
        /// </summary>
        public decimal InterestRate { get; protected set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Margin { get; protected set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Poundage { get; protected set; }

        /// <summary>
        /// 租赁方式
        /// </summary>
        public LeaseTypeEnum LeaseType { get; protected set; }

        /// <summary>
        /// 月供系数
        /// </summary>
        public decimal MonthCoefficient { get; protected set; }

        /// <summary>
        /// 费率
        /// </summary>
        public decimal Rate { get; protected set; }

        /// <summary>
        /// 渠道返点
        /// </summary>
        public decimal ChannelRate { get; protected set; }

        /// <summary>
        /// 员工提成
        /// </summary>
        public decimal SalesmanRate { get; protected set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ProductStateEnum EffectiveState { get; protected set; }
    }
}
