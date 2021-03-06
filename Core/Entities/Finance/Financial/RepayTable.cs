﻿namespace Core.Entities.Finance.Financial
{
    using System;
    using Core.Interfaces;

    public class RepayTable : Entity, IAggregateRoot
    {
        protected RepayTable()
        {
        }

        /// <summary>
        /// 期数编号（第nPerNum期）
        /// </summary>
        public int NPerNum { get; set; }

        /// <summary>
        /// 计划还款本金
        /// </summary>
        public decimal PlanPrincipal { get; set; }

        /// <summary>
        /// 实际还款本金
        /// </summary>
        public decimal? Principal { get; set; }

        /// <summary>
        /// 计划还款利息
        /// </summary>
        public decimal PlanInterest { get; set; }

        /// <summary>
        /// 实际还款利息
        /// </summary>
        public decimal? Interest { get; set; }

        /// <summary>
        /// 计划还款金额(本金+利息)
        /// </summary>
        public decimal PlanAmount => PlanPrincipal + PlanInterest;

        /// <summary>
        /// 实际还款金额
        /// </summary>
        public decimal? Amount => null; // (Principal.HasValue && Interest.HasValue) ? Principal.Value + Interest.Value : null; //(Principal.HasValue?Principal.Value:0) + (Interest.HasValue?Interest.Value:0);

        /// <summary>
        /// 计划还款余额
        /// </summary>
        public decimal PlanAmountBlance { get; set; }

        /// <summary>
        /// 实际还款余额
        /// </summary>
        public decimal? AmountBlance { get; set; }

        /// <summary>
        /// 罚息
        /// </summary>
        public decimal? PenaltyInterest { get; set; }

        /// <summary>
        /// 创建还款计划表实例
        /// </summary>
        /// <param name="nperNum">期数编号（第nPerNum期）</param>
        /// <param name="planPrincipal">计划还款本金</param>
        /// <param name="planInterest">计划还款利息</param>
        /// <param name="planAmountBlance">计划还款本金余额</param>
        /// <returns></returns>
        public static RepayTable CreateInstance(int nperNum, decimal planPrincipal, decimal planInterest, decimal planAmountBlance)
            => new RepayTable()
            {
                Id = Guid.NewGuid(),
                NPerNum = nperNum,
                PlanPrincipal = planPrincipal,
                PlanInterest = planInterest,
                PlanAmountBlance = planAmountBlance
            };

        public void SetPlanPrincipal(decimal amount)
            => PlanPrincipal = amount;

        public void SetPlanInterest(decimal amount)
            => PlanInterest = amount;

        public void SetPlanPrincipalBlance(decimal amount)
            => PlanAmountBlance = amount;
    }
}
