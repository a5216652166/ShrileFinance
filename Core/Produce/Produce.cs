namespace Core.Produce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities;
    using Core.Interfaces;

    public class Produce : Entity, IAggregateRoot
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProduceType { get; private set; }

        /// <summary>
        /// 利率（年）
        /// </summary>
        public decimal Rate { get; private set; }

        /// <summary>
        /// 期数
        /// </summary>
        public int Periods { get; private set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int PeriodsPerpayment { get; private set; }

        /// <summary>
        /// 手续费比例
        /// </summary>
        public decimal CustomerCostRatio { get; private set; }

        /// <summary>
        /// 保证金比例
        /// </summary>
        public decimal CustomerBailRatio { get; private set; }

        /// <summary>
        /// 费率（月）
        /// </summary>
        public decimal CostRate { get; private set; }

        /// <summary>
        /// 渠道返点比例
        /// </summary>
        public decimal PartnersCommissionRatio { get; private set; }

        /// <summary>
        /// 员工提成比例
        /// </summary>
        public decimal EmployeeCommissionRatio { get; private set; }

        /// <summary>
        /// 本金比例
        /// </summary>
        public virtual ICollection<PrincipalRatio> PrincipalRatios { get; private set; }

        private void Temp()
        {
            var sum = PrincipalRatios.Sum(m => m.Ratio);

            throw new NotImplementedException();
        }
    }
}
