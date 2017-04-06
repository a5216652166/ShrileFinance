namespace Core.Produce
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities;
    using Core.Exceptions;
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
        /// 利率（月）
        /// </summary>
        public decimal RateMonth => Rate / 12;

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

        /// <summary>
        /// 计算月供系数
        /// </summary>
        public void SetPaymentFactor()
        {
            var ratios = PrincipalRatios.OrderBy(m => m.Period);

            if (ratios.Sum(m => m.Ratio) != 1)
            {
                throw new ArgumentOutOfRangeAppException(message: "融资比例合计不等于 100%.");
            }

            var sameRatios = new List<PrincipalRatio>();

            foreach (var currentRatio in ratios)
            {
                var targetRatio = sameRatios.FirstOrDefault();

                if (targetRatio == null)
                {
                    sameRatios.Add(currentRatio);
                    continue;
                }

                if (targetRatio.Ratio == currentRatio.Ratio)
                {
                    sameRatios.Add(currentRatio);
                    continue;
                }

                // Set factor
                var periods = 12 * sameRatios.Count();
                var ratio = targetRatio.Ratio * sameRatios.Count();
                var excludeRatio = ratios
                    .Where(m => m.Period < targetRatio.Period).Sum(m => m.Ratio);

                var factor = CalculatePaymentFactor(periods, ratio, excludeRatio);

                foreach (var sameRatio in sameRatios)
                {
                    sameRatio.Factor = factor;
                }

                sameRatios.Clear();

                sameRatios.Add(currentRatio);
            }
        }

        /// <summary>
        /// 计算月供系数
        /// </summary>
        /// <param name="periods">期数</param>
        /// <param name="currentRatio">当前融资比例</param>
        /// <param name="excludeRatio">排除的融资比例</param>
        /// <returns></returns>
        private decimal CalculatePaymentFactor(int periods, decimal currentRatio, decimal excludeRatio)
        {
            var principal = 10000;
            var pv = principal * (1 - excludeRatio);
            var fv = principal * (1 - excludeRatio - currentRatio);

            var payment = PaymentEqualsCalculator.Payment(RateMonth, periods, pv, fv);

            return payment;
        }
    }
}
