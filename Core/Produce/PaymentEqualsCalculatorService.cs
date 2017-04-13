namespace Core.Produce
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualBasic;

    public class PaymentEqualsCalculatorService : IPaymentCalculator
    {
        public static decimal Payment(decimal rate, int periods, decimal principal, decimal final = 0)
        {
            var payment = Financial.Pmt((double)rate, periods, -(double)principal, (double)final);

            return (decimal)payment;
        }

        /// <summary>
        /// 计算每年的月供
        /// </summary>
        /// <param name="ratios">月供比例</param>
        /// <param name="principal">融资总额</param>
        /// <param name="rate">利率</param>
        /// <returns></returns>
        public IEnumerable<PrincipalRatio> YearlyPayment(IEnumerable<PrincipalRatio> ratios, decimal principal, decimal rate)
        {
            var ratioGroups = new List<ICollection<PrincipalRatio>>();
            var ratioGroup = default(ICollection<PrincipalRatio>);

            // 提取连续且比例相同的数据分组
            foreach (var ratio in ratios)
            {
                if (ratio.Ratio != ratioGroup?.FirstOrDefault().Ratio)
                {
                    ratioGroups.Add(ratioGroup = new List<PrincipalRatio>());
                }

                ratioGroup.Add(ratio);
            }

            // 分组计算
            foreach (var group in ratioGroups)
            {
                var firstRatio = group.First();
                var periods = 12 * group.Count;
                var ratio = firstRatio.Ratio * group.Count;
                var excludeRatio = ratios
                    .Where(m => m.Period < firstRatio.Period).Sum(m => m.Ratio);

                var pv = principal * (1 - excludeRatio);
                var fv = principal * (1 - excludeRatio - ratio);

                var payment = Payment(rate, periods, pv, fv);

                foreach (var item in group)
                {
                    item.Factor = payment;
                }
            }

            return ratios;
        }
    }
}
