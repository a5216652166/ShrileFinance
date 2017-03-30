namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.LoanRepositories;
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
        /// <returns>还款记录集合</returns>
        public IEnumerable<PaymentHistory> AddPayments(PaymentViewModel paymentViewModel)
        {
            var payments = new List<PaymentHistory>();

            var loan = loanRepository.Get(paymentViewModel.LoanId);

            var paymentIds = loan.Payments.Select(m => m.Id);

            foreach (var item in paymentViewModel.Payments)
            {
                if (item.Id.HasValue && paymentIds.Contains(item.Id.Value))
                {
                    continue;
                }

                var paymentHistory = Mapper.Map<PaymentHistory>(item);

                paymentHistory.LoanId = paymentViewModel.LoanId;

                paymentHistory.Id = Guid.NewGuid();

                payments.Add(paymentHistory);
            }

            ValidPayments(payments, loan);

            return payments;
        }

        /// <summary>
        /// 新增还款实体
        /// </summary>
        /// <param name="entities">还款实体</param>
        public void AddPayments(IEnumerable<PaymentHistory> entities)
        {
            var loan = loanRepository.Get(entities.First().LoanId);

            ValidPayments(entities, loan);

            var paymentService = new PaymentService();

            foreach (var item in entities)
            {
                item.AllotCreateDate();

                paymentService.Payment(loan, item);

                paymentHistoryRepository.Create(item);

                loan.Payments.Add(item);
            }

            loanRepository.Modify(loan);
        }

        /// <summary>
        /// 验证还款
        /// </summary>
        /// <param name="payments">还款实体</param>
        /// <param name="loan">借据实体</param>
        private void ValidPayments(IEnumerable<PaymentHistory> payments, Loan loan)
        {
            var exception = default(Exception);

            if (payments == null || payments.Count() == 0)
            {
                exception = new ArgumentNullAppException(message: "新增还款为空");
            }
            else
            {
                if (loan.Balance < payments.Sum(m => m.ActualPaymentPrincipal))
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
