﻿namespace Core.Entities.Finance.Financial
{
    using Core.Interfaces;

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
        public string Name { get; set; }

        /// <summary>
        /// 融资额
        /// </summary>
        public decimal FinancialAmount { get; set; }

        /// <summary>
        /// 融资本金
        /// </summary>
        public decimal? Principal { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// 增值税进项税额
        /// </summary>
        public decimal? VATamount { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? InvoiceAmount { get; set; }
    }
}