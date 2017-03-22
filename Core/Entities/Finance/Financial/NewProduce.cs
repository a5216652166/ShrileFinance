namespace Core.Entities.Finance.Financial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces;
    using Microsoft.VisualBasic;

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
        public int TimeLimit { get; protected set; } = 60;

        /// <summary>
        /// 间隔
        /// </summary>
        public int Interval { get; protected set; } = 1;

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
        public decimal InterestRate { get; protected set; } = 4.75M;

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
        /// 计算还款计划表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RepayTable> CalculateRepayTable(decimal pV)
        {
            // 还款表
            var repayTables = default(ICollection<RepayTable>);

            // 每个周期的利率
            var nPerRate = InterestRate * (Interval == 0 ? 1 : Interval) / 12 / 100;

            // 每期还款金额(四舍五入，保留两位小数)
            var pMt = Math.Round(PMT() * 100, MidpointRounding.AwayFromZero) / 100;

            // 第一期还款计划(四舍五入，保留两位小数)
            pV = Math.Round(100 * pV, MidpointRounding.AwayFromZero) / 100;
            var planInterest = Math.Round(pV * (100 * nPerRate), MidpointRounding.AwayFromZero) / 100;
            var planPrincipalBlance = pV - (pMt - planInterest);
            repayTables = new List<RepayTable>() { RepayTable.Create(1, pMt - planInterest, planInterest, pV - (pMt - planInterest)) };

            for (int i = 2; i <= Math.Ceiling(GetNPer()); i++)
            {
                var oldPlanAmountBlance = repayTables.Last().PlanAmountBlance;

                planInterest = Math.Round(oldPlanAmountBlance * (100 * nPerRate), MidpointRounding.AwayFromZero) / 100;

                repayTables.Add(RepayTable.Create(i, pMt - planInterest, planInterest, oldPlanAmountBlance - (pMt - planInterest)));
            }

            // 设置第一期的还款本金和利息
            var error = CalculateError(pV, repayTables.Sum(m => m.PlanAmount), repayTables.Sum(m => m.PlanInterest));

            var firstRepay = repayTables.First();
            repayTables.First().SetPlanPrincipal(Math.Ceiling(100 * (firstRepay.PlanPrincipal + error.amountError)) / 100);
            repayTables.First().SetPlanInterest(Math.Ceiling(100 * (firstRepay.PlanInterest + error.interestError)) / 100);

            // 设置最后一期的还款本金和剩余还款金额
            var lastRepay = repayTables.Last();
            repayTables.Last().SetPlanInterest(lastRepay.PlanInterest + lastRepay.PlanAmountBlance);
            repayTables.Last().SetPlanPrincipalBlance(0);

            return repayTables;

            decimal PMT()
            {
                var rate = GetNPerRate();

                var nPer = GetNPer();

                return Convert.ToDecimal(Financial.Pmt(rate, nPer, -Convert.ToDouble(pV)));
            }

            // 计算总期数
            double GetNPer()
            {
                var interval = Interval == 0 ? 1.0 : Interval;

                var nPer = Math.Ceiling(TimeLimit / interval);

                return nPer == 0 ? 1 : nPer;
            }

            // 计算每个周期的利润
            double GetNPerRate()
                 => Convert.ToDouble((InterestRate == 0 ? 1 : InterestRate) / 100 / 12 * (Interval == 0 ? 1 : Interval));

            // 计算四舍五入引起的误差
            (decimal amountError, decimal interestError) CalculateError(decimal pv, decimal planAmounts, decimal planInterests)
            {
                var amountError = 0M;
                var interestError = 0M;

                // 还款表
                var repays = default(ICollection<RepayTable>);

                // 每个周期的利率
                var rate = InterestRate * (Interval == 0 ? 1 : Interval) / 12 / 100;

                // 每期还款金额(四舍五入，保留两位小数)
                var pmt = Math.Round(PMT() * 100, MidpointRounding.AwayFromZero) / 100;

                // 第一期还款计划(四舍五入，保留两位小数)
                var interest = (pV * (100 * rate)) / 100;
                var blance = pV - (pmt - interest);
                repays = new List<RepayTable>() { RepayTable.Create(1, pmt - interest, interest, pV - (pmt - interest)) };

                for (int i = 2; i <= Math.Ceiling(GetNPer()); i++)
                {
                    var oldPlanAmountBlance = repays.Last().PlanAmountBlance;

                    interest = (oldPlanAmountBlance * (100 * rate)) / 100;

                    repays.Add(RepayTable.Create(i, pmt - interest, interest, oldPlanAmountBlance - (pmt - interest)));
                }

                amountError = repays.Sum(m => m.PlanAmount) - planAmounts;
                interestError = repays.Sum(m => m.PlanInterest) - planInterests;

                return (amountError, interestError);
            }
        }

        public static NewProduce Create()
            => new NewProduce();

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
