﻿namespace Core.Entities.Loan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// 借据状态枚举
    /// </summary>
    public enum LoanStatusEnum
    {
        正常 = 1,
        已还清 = 2,
        逾期 = 3
    }

    /// <summary>
    /// 四级分类枚举
    /// </summary>
    public enum FourCategoryAssetsClassificationEnum
    {
        正常 = 10,
        逾期 = 20,
        逾期天数在30天及以下 = 21,
        逾期天数在90天及以下 = 22,
        逾期天数在180天及以下 = 23,
        呆滞 = 30,
        呆帐 = 40
    }

    /// <summary>
    /// 五级分类枚举
    /// </summary>
    public enum FiveCategoryAssetsClassificationEnum
    {
        正常 = 1,
        关注 = 2,
        次级 = 3,
        可疑 = 4,
        损失 = 5
    }

    /// <summary>
    /// 贷款 / 借据
    /// </summary>
    public class Loan : Entity, IAggregateRoot
    {
        public Loan()
        {
            Payments = new HashSet<PaymentHistory>();
        }

        /// <summary>
        /// 借据金额
        /// </summary>
        public decimal Principle { get; private set; }

        /// <summary>
        /// 借据余额
        /// </summary>
        public decimal Balance
        {
            get { return CalculateBalance(); }
        }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime SpecialDate { get; private set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime MatureDate { get; private set; }

        /// <summary>
        /// 日利率
        /// </summary>
        public decimal InterestRate { get; private set; }

        /// <summary>
        /// 四级分类
        /// </summary>
        public FourCategoryAssetsClassificationEnum? FourCategoryAssetsClassification { get; private set; }

        /// <summary>
        /// 五级分类
        /// </summary>
        public FiveCategoryAssetsClassificationEnum FiveCategoryAssetsClassification { get; private set; }

        /// <summary>
        /// 借据编号
        /// </summary>
        public string ContractNumber { get; private set; }

        /// <summary>
        /// 借据状态
        /// </summary>
        public LoanStatusEnum Status { get; private set; }

        /// <summary>
        /// 贷款业务种类
        /// </summary>
        public string LoanBusinessTypes { get; private set; }

        /// <summary>
        /// 贷款形式
        /// </summary>
        public string LoanForm { get; private set; }

        /// <summary>
        /// 贷款性质
        /// </summary>
        public string LoanNature { get; private set; }

        /// <summary>
        /// 贷款投向
        /// </summary>
        public string LoansTo { get; private set; }

        /// <summary>
        /// 贷款种类
        /// </summary>
        public string LoanTypes { get; private set; }

        /// <summary>
        /// 还款记录
        /// </summary>
        public ICollection<PaymentHistory> Payments { get; set; }

        /// <summary>
        /// 新增还款记录
        /// </summary>
        /// <param name="payment">还款记录</param>
        public void AddPaymentHistory(PaymentHistory payment)
        {
            if (payment.ActualPaymentPrincipal > Balance)
            {
                throw new ArgumentOutOfRangeAppException(nameof(payment.ActualPaymentPrincipal), "实际偿还本金必须少于借据余额.");
            }

            var lastPayment = Payments.LastOrDefault();
            if (lastPayment != null && payment.DatePayment > lastPayment.DatePayment)
            {
                throw new ArgumentOutOfRangeAppException(nameof(payment.ActualPaymentPrincipal), "还款日期必须晚于最后一次还款的日期.");
            }

            Payments.Add(payment);

            ChangeStatus();
        }

        /// <summary>
        /// 设置四级分类
        /// </summary>
        /// <param name="fourCategoryAssetsClassification">四级分类</param>
        public void SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum fourCategoryAssetsClassification)
        {
            FourCategoryAssetsClassification = fourCategoryAssetsClassification;
            Status = LoanStatusEnum.逾期;

            switch (fourCategoryAssetsClassification)
            {
                case FourCategoryAssetsClassificationEnum.正常:
                    FiveCategoryAssetsClassification = FiveCategoryAssetsClassificationEnum.正常;
                    Status = LoanStatusEnum.正常;
                    break;
                case FourCategoryAssetsClassificationEnum.逾期:
                case FourCategoryAssetsClassificationEnum.逾期天数在30天及以下:
                    FiveCategoryAssetsClassification = FiveCategoryAssetsClassificationEnum.关注;
                    break;
                case FourCategoryAssetsClassificationEnum.逾期天数在90天及以下:
                    FiveCategoryAssetsClassification = FiveCategoryAssetsClassificationEnum.次级;
                    break;
                case FourCategoryAssetsClassificationEnum.逾期天数在180天及以下:
                    FiveCategoryAssetsClassification = FiveCategoryAssetsClassificationEnum.可疑;
                    break;
                case FourCategoryAssetsClassificationEnum.呆滞:
                case FourCategoryAssetsClassificationEnum.呆帐:
                    FiveCategoryAssetsClassification = FiveCategoryAssetsClassificationEnum.损失;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 计算余额
        /// </summary>
        /// <returns></returns>
        private decimal CalculateBalance()
        {
            // 借据余额 = 借据金额 - Sum(实际偿还本金)
            var balance = Principle - Payments.Sum(m => m.ActualPaymentPrincipal);

            return balance;
        }

        /// <summary>
        /// 变更借据状态
        /// </summary>
        private void ChangeStatus()
        {
            if (Balance > 0)
            {
                if (Status != LoanStatusEnum.逾期)
                {
                    Status = LoanStatusEnum.正常;
                }
            }
            else
            {
                Status = LoanStatusEnum.已还清;
            }
        }
    }
}