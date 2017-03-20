using System;
using Core.Interfaces;

namespace Core.Entities.Finance.Financial
{
    /// <summary>
    /// 融资项
    /// </summary>
    public class FinancialItem : Entity, IAggregateRoot
    {
        protected FinancialItem() : base()
        {
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 融资本金
        /// </summary>
        public decimal Principal{ get; protected set; }

        /// <summary>
        /// 税率
        /// </summary>
        public decimal Rate { get; protected set; }

        /// <summary>
        /// 增值税进项税额
        /// </summary>
        public decimal VATamount { get; protected set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal InvoiceAmount { get; protected set; }

        /// <summary>
        /// 融资额
        /// </summary>
        public decimal financialAmount { get; protected set; }
    }
}
