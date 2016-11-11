﻿namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Produce;

    public class Finance : Entity, IAggregateRoot
    {
        /// <summary>
        /// 融资本金
        /// </summary>
        public decimal Principal { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// 融资期限 (月)
        /// </summary>
        public int Periods { get; set; }

        /// <summary>
        /// 还款间隔 (月)
        /// </summary>
        public int RepaymentInterval { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public int RepaymentDate { get; set; }

        /// <summary>
        /// 还款方案
        /// </summary>
        ////public Scheme RepaymentScheme { get; set; }

        /// <summary>
        /// 借款人
        /// </summary>
        public object Borrower { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Bail { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public FinanceStateEnum State { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime DateEffective { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal AdviceMoney { get; set; }

        /// <summary>
        /// 建议融资比例
        /// </summary>
        public decimal AdviceRatio { get; set; }

        /// <summary>
        /// 审批融资金额
        /// </summary>
        public decimal ApprovalMoney { get; set; }

        /// <summary>
        /// 审批融资比例
        /// </summary>
        public decimal ApprovalRatio { get; set; }

        /// <summary>
        /// 金融手续费
        /// </summary>
        public decimal Poundage { get; set; }

        /// <summary>
        /// 月供额度
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// 融资扩展
        /// </summary>
        public virtual FinanceExtension FinanceExtension { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<Contact> Contact { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Produce Produce { get; set; }

        /// <summary>
        /// 信审报告
        /// </summary>
        public virtual CreditExamine CreditExamine { get; set; }
    }
}
