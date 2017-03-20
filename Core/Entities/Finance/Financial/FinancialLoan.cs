namespace Core.Entities.Finance.Financial
{
    using System;
    using Core.Interfaces;
    using Core.Exceptions;
    using System.Collections.Generic;

    public enum LoanDateEnum : byte
    {
        每月10号 = 1,
        每月20号 = 2
    }

    public enum StateEnum : byte
    {
        正常运营 = 1,
        主动结清 = 2,
        根本违约 = 3,
        资产转让 = 4
    }

    /// <summary>
    /// 财务放款
    /// </summary>
    public class FinancialLoan : Entity, IAggregateRoot
    {
        protected FinancialLoan() : base()
        {
        }

        /// <summary>
        /// 放款编号
        /// </summary>
        public string LoanNum { get; protected set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime LoanDate { get; protected set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public LoanDateEnum RepayDate { get; protected set; }

        /// <summary>
        /// 放款状态
        /// </summary>
        public StateEnum State { get; protected set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// 融资项
        /// </summary>
        public virtual ICollection<FinancialItem> FinancialItem { get; protected set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual NewProduce NewProduce { get; protected set; }

        public void SetProduce(NewProduce produce)
            => NewProduce = produce;

        public void SetCreatedDate()
            => CreatedDate = DateTime.Now;

        public void Valid()
        {
            var exception = default(Exception);

            if (NewProduce == null)
            {
                exception = new ArgumentNullAppException(message: "产品引用为空！");
            }
            else if (FinancialItem == null || FinancialItem.Count == 0)
            {
                exception = new ArgumentNullAppException(message: "融资项为空！");
            }

            if (exception != default(Exception))
            {
                throw exception;
            }
        }
    }
}
