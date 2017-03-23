namespace Core.Entities.Finance.Financial
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
        public int NPerNum { get; protected set; }

        /// <summary>
        /// 计划还款本金
        /// </summary>
        public decimal PlanPrincipal { get; protected set; }

        /// <summary>
        /// 计划还款利息
        /// </summary>
        public decimal PlanInterest { get; protected set; }

        /// <summary>
        /// 计划还款金额
        /// </summary>
        public decimal PlanAmount => PlanPrincipal + PlanInterest;

        /// <summary>
        /// 计划还款余额
        /// </summary>
        public decimal PlanAmountBlance { get; protected set; }

        /// <summary>
        /// 罚息
        /// </summary>
        public decimal PenaltyInterest { get; protected set; }

        /// <summary>
        /// 创建还款计划表实例
        /// </summary>
        /// <param name="nperNum">期数编号（第nPerNum期）</param>
        /// <param name="planPrincipal">计划还款本金</param>
        /// <param name="planInterest">计划还款利息</param>
        /// <param name="planAmountBlance">计划还款本金余额</param>
        /// <returns></returns>
        public static RepayTable Create(int nperNum, decimal planPrincipal, decimal planInterest, decimal planAmountBlance)
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
