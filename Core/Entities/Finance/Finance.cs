namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using Core.Produce;
    using Interfaces;

    public class Finance : Entity, IAggregateRoot, IProcessable
    {
        public Finance()
        {
            DateEffective = DateTime.Now;
            Applicant = new HashSet<Applicant>();
            Contact = new HashSet<Contract>();
            BailPaid = 0;
        }

        public enum RepaymentSchemeEnum : byte
        {
            /// <summary>
            /// 等额本息
            /// </summary>
            等额本息 = 1,

            /// <summary>
            /// 月供提前付
            /// </summary>
            月供提前付 = 2,

            /// <summary>
            /// 一次性付息
            /// </summary>
            一次性付息 = 3
        }

        /// <summary>
        /// 实际用款额(融资本金)
        /// </summary>
        public decimal? Principal { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public int? RepaymentDate { get; set; }

        /// <summary>
        /// 还款方案
        /// </summary>
        public RepaymentSchemeEnum RepaymentScheme { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Bail { get; set; }

        /// <summary>
        /// 一次性付息
        /// </summary>
        public decimal? OnePayInterest { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime? DateEffective { get; set; }

        /// <summary>
        /// 融资金额
        /// </summary>
        public decimal? Financing { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Poundage { get; set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int? OncePayMonths { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 已付保证金
        /// </summary>
        public decimal BailPaid { get; private set; }

        /// <summary>
        /// 审批金额
        /// </summary>
        public decimal? ApprovalMoney { get; set; }

        /// <summary>
        /// 月供金额
        /// </summary>
        public decimal? Payment { get; set; }

        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SelfPrincipal { get; private set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        public DateTime? RepayRentDate { get; set; }

        /// <summary>
        /// 合作商
        /// </summary>
        public virtual Partner CreateOf { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual AppUser CreateBy { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual ICollection<Applicant> Applicant { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual Vehicle.Vehicle Vehicle { get; set; }

        /// <summary>
        /// 融资扩展
        /// </summary>
        public virtual FinanceExtension FinanceExtension { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<Contract> Contact { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Produce Produce { get; set; }

        /// <summary>
        /// 融资对应产品的融资项
        /// </summary>
        public virtual ICollection<FinanceItem> FinanceItems { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// 保证金缴费
        /// </summary>
        public void PayBail()
        {
            // 表示已还清[伪逻辑]
            BailPaid = (ApprovalMoney ?? 0) * (Margin ?? 0);
        }

        /// <summary>
        /// 撤销已缴保证金
        /// </summary>
        public void RevertBail()
        {
            // 清空已缴金额。
            BailPaid = 0;
        }
    }
}
