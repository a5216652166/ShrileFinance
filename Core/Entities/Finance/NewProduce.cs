namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using Core.Interfaces;

    public enum ProductStateEnum : byte
    {
        正常 = 1,
        失效 = 2,
        暂未启用 = 3
    }

    public enum LeaseTypeEnum : byte
    {
        回租 = 1,
        直租 = 2
    }

    public class NewProduce : Entity, IAggregateRoot
    {
        protected NewProduce() : base()
        {
        }

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

        public static NewProduce CreateNewEntity(
            string code,
            int timeLimit,
            int interval,
            decimal interestRate,
            decimal margin,
            LeaseTypeEnum leaseType,
            decimal monthCoefficient,
            decimal poundage,
            decimal channelRate,
            decimal salesmanRate,
            DateTime createdDate,
            ProductStateEnum effectiveState = ProductStateEnum.正常)
                => new NewProduce()
                {
                    Code = code,
                    TimeLimit = timeLimit,
                    Interval = interval,
                    InterestRate = interestRate,
                    Margin = margin,
                    LeaseType = leaseType,
                    MonthCoefficient = monthCoefficient,
                    Poundage = poundage,
                    ChannelRate = channelRate,
                    SalesmanRate = salesmanRate,
                    EffectiveState = effectiveState,
                    CreatedDate = createdDate
                };

        /// <summary>
        /// 设置产品状态
        /// </summary>
        /// <param name="state">状态</param>
        public void SetState(ProductStateEnum state)
            => EffectiveState = state;

        /// <summary>
        /// 计算还款计算表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> CalculateRepayTable()
        {
            throw new NotImplementedException();
        }
    }
}
