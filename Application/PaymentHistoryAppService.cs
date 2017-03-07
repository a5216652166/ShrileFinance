namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Exceptions;
    using Core.Interfaces.Repositories;
    using Core.Services.Loan;
    using ViewModels.Loan.LoanViewModels;

    public class PaymentHistoryAppService
    {
        private readonly IPaymentHistoryRepository paymentHistoryRepository;
        private readonly ILoanRepository loanRepository;

        public PaymentHistoryAppService(
            IPaymentHistoryRepository paymentHistoryRepository,
            ILoanRepository loanRepository)
        {
            this.paymentHistoryRepository = paymentHistoryRepository;
            this.loanRepository = loanRepository;
        }

        /// <summary>
        /// 新增还款
        /// </summary>
        /// <param name="paymentViewModel">还款视图</param>
        /// <returns>新增还款</returns>
        public IEnumerable<PaymentHistory> AddPayments(PaymentViewModel paymentViewModel)
        {
            var payments = new List<PaymentHistory>();

            var loan = loanRepository.Get(paymentViewModel.LoanId);

            var paymentService = new PaymentService();

            foreach (var item in paymentViewModel.Payments)
            {
                payments.Add(Mapper.Map<PaymentHistory>(item));

                paymentService.Payment(loan, payments.Last());
            }

            ValidPayments(payments,loan);

            return payments;
        }

        private void ValidPayments(IEnumerable<PaymentHistory> payments,Loan loan)
        {
            var exception = default(Exception);

            if (payments == null || payments.Count() == 0)
            {
                exception = new ArgumentNullAppException(message: "还款为空");
            }
            else
            {
                if (loan.Balance < payments.Sum(m=>m.ActualPaymentPrincipal))
                {
                    exception = new ArgumentAppException("该借据余额已不足.");
                }
            }

            if (exception != default(Exception))
            {
                throw exception;
            }
        }
    }
}
