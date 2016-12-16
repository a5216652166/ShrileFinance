namespace Core.Entities.Loan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces;
    using Customers.Enterprise;
    using Exceptions;

    public enum CreditContractStatusEnum : byte
    {
        生效 = 0,
        失效 = 1,
        未结清 = 2
    }

    public class CreditContract : Entity, IAggregateRoot
    {
        public CreditContract()
        {
            GuarantyContract = new HashSet<GuarantyContract>();
            Loans = new HashSet<Loan>();
        }

        public CreditContract(DateTime effectiveDate, DateTime expirationDate, decimal creditLimit, CreditContractStatusEnum status)
        {
            Loans = new HashSet<Loan>();

            if (effectiveDate > expirationDate)
            {
                throw new ArgumentOutOfRangeAppException(nameof(ExpirationDate), "合同终止日期必须小于等于生效日期.");
            }

            if (CreditBalance > creditLimit)
            {
                throw new ArgumentOutOfRangeAppException(nameof(CreditBalance), "授信余额不能大于授信额度.");
            }

            EffectiveDate = effectiveDate;
            ExpirationDate = expirationDate;
            CreditLimit = creditLimit;
            EffectiveStatus = status;
        }

        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public string CreditContractCode { get; set; }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 授信额度
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 授信余额
        /// </summary>
        public decimal CreditBalance
        {
            get
            {
                return CalculateCreditBalance();
            }
        }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public CreditContractStatusEnum EffectiveStatus { get; set; }

        /// <summary>
        /// 是否有担保
        /// </summary>
        public bool HasGuarantee
        {
            get
            {
                return GuarantyContract.Count > 0;
            }
        }

        /// <summary>
        /// 担保合同
        /// </summary>
        public virtual ICollection<GuarantyContract> GuarantyContract { get; set; }

        /// <summary>
        /// 借据信息
        /// </summary>
        public virtual ICollection<Loan> Loans { get; set; }

        /// <summary>
        /// 组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }

        public void ValidateEffective(CreditContract creditContract)
        {
            if (creditContract.EffectiveDate > creditContract.ExpirationDate)
            {
                throw new ArgumentOutOfRangeAppException(nameof(ExpirationDate), "合同终止日期必须小于等于生效日期.");
            }

            if (creditContract.CreditBalance > creditContract.CreditLimit)
            {
                throw new ArgumentOutOfRangeAppException(nameof(CreditBalance), "授信余额不能大于授信额度.");
            }
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="limit">新授信额度</param>
        public void ChangeLimit(decimal limit)
        {
            if (EffectiveStatus != CreditContractStatusEnum.失效)
            {
                CreditLimit = limit;
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(nameof(EffectiveStatus), "合同已失效不允许额度变更.");
            }
        }

        /// <summary>
        /// 合同有效期变更
        /// </summary>
        /// <param name="expirationDate">终止日期</param>
        public void ChangeExpirationDate(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
        }

        /// <summary>
        /// 可否申请贷款
        /// </summary>
        /// <param name="limit">金额</param>
        /// <returns></returns>
        public bool CanApplyLoan(decimal limit)
        {
            var result = true;

            result &= CanCredit(limit);
            result &= IsEffectiveDate();
            result &= IsEffective();
            return result;
        }

        /// <summary>
        /// 终止授信协议
        /// </summary>
        public void ChangeStutus()
        {
            EffectiveStatus = CreditContractStatusEnum.失效;
        }

        /// <summary>
        /// 计算授信余额
        /// </summary>
        /// <returns></returns>
        public decimal CalculateCreditBalance()
        {
            return CreditLimit - Loans.Sum(m => m.Balance);
        }

        /// <summary>
        ///  融资额度是否充足
        /// </summary>
        /// <param name="amount">贷款金额</param>
        /// <returns></returns>
        private bool CanCredit(decimal amount)
        {
            if (CreditBalance < amount)
            {
                throw new ArgumentOutOfRangeAppException(nameof(CreditBalance), "融资余额已不足.");
            }

            return true;
        }

        /// <summary>
        /// 合同是否在有效期内
        /// </summary>
        /// <returns></returns>
        private bool IsEffectiveDate()
        {
            var today = DateTime.Now.Date;

            return (EffectiveDate <= today)
                && (today <= ExpirationDate);
        }

        /// <summary>
        /// 判断合同状态是否有效
        /// </summary>
        /// <returns></returns>
        private bool IsEffectiveContract()
        {
            var result = true;

            if (EffectiveStatus == CreditContractStatusEnum.失效)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 授信协议是否有效
        /// </summary>
        /// <returns></returns>
        private bool IsEffective()
        {
            var result = true;

            // 不在有效期内并且状态为失效
            if (IsEffectiveDate() == false && IsEffectiveContract() == false)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 更改合同有效状态
        /// </summary>
        /// <param name="status">合同状态</param>
        private void ChangeEffective(CreditContractStatusEnum status)
        {
            EffectiveStatus = status;
        }
    }
}
