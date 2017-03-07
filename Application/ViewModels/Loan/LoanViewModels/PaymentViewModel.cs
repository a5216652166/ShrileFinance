namespace Application.ViewModels.Loan.LoanViewModels
{
    using System;
    using System.Collections.Generic;

    public class PaymentViewModel
    {
        /// <summary>
        /// 借据标识
        /// </summary>
        public Guid LoanId { get; set; }

        public LoanViewModel Loan { get; set; }

        /// <summary>
        /// 还款记录
        /// </summary>
        public IEnumerable<PaymentHistoryViewModel> Payments { get; set; }
    }
}
