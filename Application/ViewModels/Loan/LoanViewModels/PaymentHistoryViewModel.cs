﻿namespace Application.ViewModels.Loan.LoanViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core.Entities;

    public class PaymentHistoryViewModel
    {
        /// <summary>
        /// 还款记录标识
        /// </summary>
        public Guid? Id { get; set; }

        public HiddenEnum Hidden { get; set; } = HiddenEnum.完成;

        /// <summary>
        /// 应还本金
        /// </summary>
        public decimal ScheduledPaymentPrincipal { get; set; }

        /// <summary>
        /// 应还利息
        /// </summary>
        public decimal ScheduledPaymentInterest { get; set; }

        /// <summary>
        /// 实际偿还本金
        /// </summary>
        public decimal ActualPaymentPrincipal { get; set; }

        /// <summary>
        /// 实际偿还利息
        /// </summary>
        public decimal ActualPaymentInterest { get; set; }

        /// <summary>
        /// 应还款日期
        /// </summary>
        public DateTime ScheduledDatePayment { get; set; }

        /// <summary>
        /// 实际还款日期
        /// </summary>
        public DateTime ActualDatePayment { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        [Required]
        public string PaymentTypes { get; set; }

        /// <summary>
        /// 还款方式描述
        /// </summary>
        public string PaymentTypesDesc
        {
            get
            {
                switch (PaymentTypes)
                {
                    case "01": return "正常收回";
                    case "02": return "资产重组";
                    case "03": return "资产剥离";
                    case "04": return "以资抵债";
                    case "05": return "担保代偿";
                    case "06": return "核损核销";
                    case "07": return "政策性还款";
                    case "08": return "债转股";
                    case "09": return "转出";
                    default: return string.Empty;
                }
            }
        }

        /// <summary>
        /// 所属借据标识
        /// </summary>
        public Guid LoanId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 所属流程Id
        /// </summary>
        public Guid InstanceId { get; set; }
    }
}
