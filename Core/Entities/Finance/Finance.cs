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

        public enum LeaseModeEnum : byte
        {
            直租 = 1,

            回租 = 2,
        }

        public enum VehicleClauseEnum : byte
        {
            有 = 1,

            无 = 2,
        }

        public enum MortgageRequirementsEnum : byte
        {
            无 = 1,

            晟融 = 2,

            东海银行 = 3,
        }

        /// <summary>
        /// 租赁方式
        /// </summary>
        public LeaseModeEnum LeaseMode { get; set; }

        /// <summary>
        /// 有无还车条款
        /// </summary>
        public VehicleClauseEnum VehicleClause { get; set; }

        /// <summary>
        /// 车辆抵押要求
        /// </summary>
        public MortgageRequirementsEnum MortgageRequirements { get; set; }

        /// <summary>
        /// 融资租赁合同编号
        /// </summary>
        public string LeaseNo { get; set; }

        /// <summary>
        /// 车辆抵押合同编号
        /// </summary>
        public string VehicleMortgageContractNo { get; set; }

        /// <summary>
        /// 客户应付租金起始日期
        /// </summary>
        public DateTime? RentPayableStartDate { get; set; }

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
        /// 审批手续费
        /// </summary>
        public decimal? ApprovalPoundage { get; set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int? OncePayMonths { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 审批保证金
        /// </summary>
        public decimal? ApprovalMargin { get; set; }

        /// <summary>
        /// 审批融资金额
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
    }
}
