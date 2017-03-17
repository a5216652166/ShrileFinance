namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces;

    public enum ProduceTypeEnum : byte
    {
        纯分期 = 1,
        保证金加三期月供提前付 = 2,
        均匀贷 = 3,
        低息贷 = 4,
        保证金加分期 = 5,
    }

    public enum LeaseTypeEnum : byte
    {
        回租 = 1,
        直租 = 2
    }

    /// <summary>
    /// 产品
    /// </summary>
    public class NewProduce : Entity, IAggregateRoot
    {
        protected NewProduce() : base()
        {
        }

        /// <summary>
        /// 产品类型
        /// </summary>
        public ProduceTypeEnum ProduceType { get; protected set; }

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
        /// 手续费
        /// </summary>
        public decimal Poundage { get; protected set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal MarginRate { get; protected set; }

        /// <summary>
        /// 月费率
        /// </summary>
        public decimal MonthRate { get; protected set; }

        /// <summary>
        /// 渠道返点
        /// </summary>
        public decimal ChannelRate { get; protected set; }

        /// <summary>
        /// 员工提成
        /// </summary>
        public decimal SalesmanRate { get; protected set; }

        /// <summary>
        /// 名义利率
        /// </summary>
        public decimal InterestRate { get; protected set; }

        /// <summary>
        /// 租赁方式
        /// </summary>
        public LeaseTypeEnum LeaseType { get; protected set; }

        /// <summary>
        /// 偿还本金比例
        /// </summary>
        public string RepayPrincipals { get; protected set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// 计算还款计算表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> CalculateRepayTable()
        {
            throw new NotImplementedException();
        }

        public void SetCreatedDate()
            => CreatedDate = DateTime.Now;

        public void Valid()
        {
            var exception = default(Exception);

            var array = RepayPrincipals.Split('-').ToList();

            if (array.Sum(m => decimal.Parse(m)) != 100)
            {
                exception = new ArgumentException(message: "偿还本金比例之和应为100%");
            }

            if (exception != default(Exception))
            {
                throw exception;
            }
        }
    }
}
