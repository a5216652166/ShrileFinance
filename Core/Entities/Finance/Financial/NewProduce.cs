﻿namespace Core.Entities.Finance.Financial
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
        public int TimeLimit { get; protected set; } = 30;

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
        public string RepayPrincipals { get; protected set; } = "33.4-33.3-33.3";

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        public static NewProduce CreateInstance()
            => new NewProduce();

        public void AllowCreatedDate()
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

        /// <summary>
        /// 计算还款计划表
        /// </summary>
        /// <param name="pV">融资总额</param>
        /// <returns></returns>
        public IEnumerable<RepayTable> CalculateRepayTable(decimal pV)
        {
            // 还款表
            var repayTables = default(ICollection<RepayTable>);

            // 还款表(镜像)
            ////var repaytablesM = default(ICollection<RepayTable>);

            // 每个周期的利率
            var nPerRate = InterestRate * (Interval == 0 ? 1 : Interval) / 12 / 100;

            // 第一年还款金额(四舍五入，保留两位小数)
            var pmt = Math.Round(PMT() * 100, MidpointRounding.AwayFromZero) / 100;

            // 第一年还款金额(镜像)
            var pmtM = PMT();

            // 第一期融资总额(四舍五入，保留两位小数)
            var pv = Math.Round(100 * pV, MidpointRounding.AwayFromZero) / 100;

            // 第一期融资总额(镜像)
            var pvM = pV;

            // 第一期还款计划利息(四舍五入，保留两位小数)
            var planInterest = Math.Round(pv * (100 * nPerRate), MidpointRounding.AwayFromZero) / 100;

            // 第一期还款计划利息(镜像)
            var planInterestM = pvM * nPerRate;

            // 第一期还款计划余额(四舍五入，保留两位小数)
            var planPrincipalBlance = pv - (pmt - planInterest);

            // 第一期还款计划余额(镜像)
            var planPrincipalBlanceM = pvM - (pmtM - planInterestM);

            // 记录第一期还款计划(四舍五入，保留两位小数)
            repayTables = new List<RepayTable>() { RepayTable.CreateInstance(1, pmt - planInterest, planInterest, pv - (pmt - planInterest)) };

            // 记录第一期还款计划(镜像)
            repayTables = new List<RepayTable>() { RepayTable.CreateInstance(1, pmtM - planInterest, planInterest, pv - (pmt - planInterest)) };

            for (int i = 2; i <= Math.Ceiling(GetNPer()); i++)
            {
                var oldPlanAmountBlance = repayTables.Last().PlanAmountBlance;

                planInterest = Math.Round(oldPlanAmountBlance * (100 * nPerRate), MidpointRounding.AwayFromZero) / 100;

                repayTables.Add(RepayTable.CreateInstance(i, pmt - planInterest, planInterest, oldPlanAmountBlance - (pmt - planInterest)));
            }

            // 设置第一期的还款本金和利息
            var error = CalculateError(pv, repayTables.Sum(m => m.PlanAmount), repayTables.Sum(m => m.PlanInterest));

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
            (decimal amountError, decimal interestError) CalculateError(decimal pvvv, decimal planAmounts, decimal planInterests)
            {
                var amountError = 0M;
                var interestError = 0M;

                ////// 还款表
                ////var repays = default(ICollection<RepayTable>);

                ////// 每个周期的利率
                ////var rate = InterestRate * (Interval == 0 ? 1 : Interval) / 12 / 100;

                ////// 每期还款金额(四舍五入，保留两位小数)
                ////var pmt = Math.Round(PMT() * 100, MidpointRounding.AwayFromZero) / 100;

                ////// 第一期还款计划(四舍五入，保留两位小数)
                ////var interest = (pV * (100 * rate)) / 100;
                ////var blance = pV - (pmt - interest);
                ////repays = new List<RepayTable>() { RepayTable.Create(1, pmt - interest, interest, pV - (pmt - interest)) };

                ////for (int i = 2; i <= Math.Ceiling(GetNPer()); i++)
                ////{
                ////    var oldPlanAmountBlance = repays.Last().PlanAmountBlance;

                ////    interest = (oldPlanAmountBlance * (100 * rate)) / 100;

                ////    repays.Add(RepayTable.Create(i, pmt - interest, interest, oldPlanAmountBlance - (pmt - interest)));
                ////}

                ////amountError = repays.Sum(m => m.PlanAmount) - planAmounts;
                ////interestError = repays.Sum(m => m.PlanInterest) - planInterests;

                return (amountError, interestError);
            }
        }

        public IEnumerable<RepayTable> CalculateRepayTable_1(decimal pV)
        {
            ProduceType = ProduceTypeEnum.低息贷;

            var repayTables = default(IEnumerable<RepayTable>);

            // 等额本息
            var dic1 = new HashSet<ProduceTypeEnum>() {
                ProduceTypeEnum.低息贷,
                ProduceTypeEnum.保证金加三期月供提前付,
                ProduceTypeEnum.保证金加分期,
                ProduceTypeEnum.均匀贷,
                ProduceTypeEnum.纯分期
            };

            // 等额本金
            var dic2 = new HashSet<ProduceTypeEnum>() {
                ProduceTypeEnum.低息贷,
                ProduceTypeEnum.保证金加三期月供提前付,
                ProduceTypeEnum.保证金加分期,
                ProduceTypeEnum.均匀贷,
                ProduceTypeEnum.纯分期
            };

            switch (ProduceType)
            {
                case ProduceTypeEnum type when dic1.Contains(type):
                    repayTables = CalculateRepayTablePIW(pV);
                    break;
                case ProduceTypeEnum type when dic2.Contains(type):
                    repayTables = CalculateRepayTableSTD(pV);
                    break;
                default:
                    break;
            }

            return repayTables ?? new HashSet<RepayTable>();
        }

        /// <summary>
        /// 等额本息还款计划表
        /// </summary>
        /// <param name="pV">融资总额</param>
        /// <returns></returns>
        private IEnumerable<RepayTable> CalculateRepayTablePIW(decimal pV)
        {
            // 还款计划表
            var repayTables = default(ICollection<RepayTable>);

            // 还款计划表（镜像）
            var repayTablesM = default(ICollection<RepayTable>);

            // 记录第0期
            repayTables = new HashSet<RepayTable>() { RepayTable.CreateInstance(0, 0, 0, pV) };

            // 记录第0期（镜像）
            repayTablesM = new HashSet<RepayTable>() { RepayTable.CreateInstance(0, 0, 0, pV) };

            // 总期数（恒定）
            var pers = NPers();

            // 每期利率（恒定）
            var perRate = Convert.ToDecimal(NPerRate());

            // 产品
            var repayPrincipals = RepayPrincipals.Split('-').ToList().ConvertAll(m => Convert.ToDecimal(m));

            for (int i = 1; i <= repayPrincipals.Count; i++)
            {
                // 第i年的尾款比例
                var fVrate = 1M;
                for (int k = 0; k < i; k++)
                {
                    fVrate -= repayPrincipals[k] / 100;
                }

                // 第i年尾款
                var fV = pV * fVrate;

                // 第i年融资总额
                var pv = pV - repayTables.Sum(m => m.PlanPrincipal);

                // 第i年期数
                var nPer = NPers() - repayTables.Count + 1;

                // 第i年，每期还款额
                var pmt = Math.Round(PMT(nPer, pv, fV) * 100, MidpointRounding.AwayFromZero) / 100;

                // 第i年，每期还款额(镜像)
                var pmtM = PMT(nPer, pv, fV);

                // 第i年内的总期数
                var npers = (TimeLimit - 12 * i) < 0 ? TimeLimit - 12 * (i - 1) : 12;
                npers = Convert.ToInt32(Math.Ceiling((decimal)npers / Interval));

                // 第i年还款记录
                for (int j = 1; j <= npers; j++)
                {
                    // 上一期的余额
                    var oldBlance = repayTables.Last().PlanAmountBlance;

                    // 本期的利息
                    var interest = Math.Round(oldBlance * (100 * perRate), MidpointRounding.AwayFromZero) / 100;

                    // 本期的利息（镜像）
                    var interestM = oldBlance * perRate;

                    // 还款计划表加入本期还款计划
                    repayTables.Add(RepayTable.CreateInstance(12 * (i - 1) + j, pmt - interest, interest, oldBlance + interest - pmt));

                    // 还款计划表加入本期还款计划（本金）
                    repayTablesM.Add(RepayTable.CreateInstance(12 * (i - 1) + j, pmt - interestM, interestM, oldBlance + interestM - pmt));
                }
            }

            // 移除第0期
            repayTables.Remove(repayTables.First());

            // 移除第0期(镜像)
            repayTablesM.Remove(repayTablesM.First());

            // 误差修正
            var lastRepay = repayTables.Last();
            var error = Error(repayTables, repayTablesM);

            repayTables.First().SetPlanPrincipal(lastRepay.PlanPrincipal + error.principalError);
            repayTables.First().SetPlanInterest(lastRepay.PlanAmountBlance + error.interestError);
            repayTables.Last().SetPlanPrincipalBlance(0);

            return repayTables;

            // 计算总期数
            int NPers()
            {
                var interval = Interval == 0 ? 1.0 : Interval;

                var nPer = Math.Ceiling(TimeLimit / interval);

                return nPer == 0 ? 1 : Convert.ToInt32(nPer);
            }

            // 计算每个周期的利润
            double NPerRate()
                 => Convert.ToDouble((InterestRate == 0 ? 1 : InterestRate) / 100 / 12 * (Interval == 0 ? 1 : Interval));

            // 计算第n年的每期还款额
            decimal PMT(int nper, decimal pv, decimal fv)
            {
                var rate = NPerRate();

                return Convert.ToDecimal(Financial.Pmt(rate, nper, -Convert.ToDouble(pv), Convert.ToDouble(fv)));
            }

            // 计算误差
            (decimal principalError, decimal interestError) Error(IEnumerable<RepayTable> repays, IEnumerable<RepayTable> repaysM)
            {
                var principalError = repaysM.Sum(m => m.PlanPrincipal) + repayTables.Last().PlanAmountBlance - repays.Sum(m => m.PlanPrincipal);

                var interestError = repaysM.Sum(m => m.PlanInterest) - repaysM.Sum(m => m.PlanInterest);

                return (Math.Round(principalError*100)/100, Math.Round(interestError)/100);
            }
        }

        /// <summary>
        /// 等额本金还款计划表
        /// </summary>
        /// <param name="pV">融资总额</param>
        /// <returns></returns>
        private IEnumerable<RepayTable> CalculateRepayTableSTD(decimal pV)
        {
            throw new NotImplementedException();
        }
    }
}