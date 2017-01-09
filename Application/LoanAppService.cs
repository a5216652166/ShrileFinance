namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Loan;
    using Core.Exceptions;
    using Core.Interfaces.Repositories;
    using Core.Services.Loan;
    using ViewModels.Loan.LoanViewModels;
    using X.PagedList;

    public class LoanAppService
    {
        private readonly ICreditContractRepository creditRepository;
        private readonly LoanService loanService;
        private readonly PaymentService paymentService;
        private readonly ILoanRepository repository;
        private readonly DatagramAppService messageAppService;

        public LoanAppService(
            LoanService loanService,
            PaymentService paymentService,
            ILoanRepository repository,
            ICreditContractRepository creditRepository,
            DatagramAppService messageAppService)
        {
            this.loanService = loanService;
            this.paymentService = paymentService;
            this.repository = repository;
            this.creditRepository = creditRepository;
            this.messageAppService = messageAppService;
        }

        /// <summary>
        /// 获取借据实例
        /// </summary>
        /// <param name="id">借据标识</param>
        /// <returns></returns>
        public LoanViewModel Get(Guid id)
        {
            var loan = repository.Get(id);

            var model = Mapper.Map<LoanViewModel>(loan);

            return model;
        }

        public bool CheckLoanNumber(string loanNumber)
        {
            var result = true;

            var list = repository.GetAll();
            if (!string.IsNullOrEmpty(loanNumber))
            {
                var loan = list.Where(m => m.ContractNumber == loanNumber).FirstOrDefault();
                if (loan != null)
                {
                    result = false;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "借据编号不能为空.");
            }

            return result;
        }

        /// <summary>
        /// 申请借据
        /// </summary>
        /// <param name="model">借据视图模型</param>
        public void ApplyLoan(LoanViewModel model)
        {
            var credit = creditRepository.Get(model.CreditId);
            var loan = Mapper.Map<Loan>(model);

            loanService.Loan(loan, credit);

            repository.Create(loan);

            repository.Commit();
            model.Id = loan.Id;
            ////// 报文追踪（放款）
            ////messageAppService.Trace(referenceId: loan.Id, traceType: TraceTypeEnum.借款, defaultName: $"申请借据，贷款合同编号：{credit.CreditContractCode}", specialDate: loan.SpecialDate);
        }

        /// <summary>
        /// 修改借据
        /// </summary>
        /// <param name="model">借据视图模型</param>
        public void ModifyLoan(LoanViewModel model)
        {
            if (!model.Id.HasValue)
            {
                throw new ArgumentNullAppException(nameof(model.Id), "借据标识不可为空.");
            }

            var loan = repository.Get(model.Id.Value);
            loan.InterestRate = model.InterestRate;
            loan.LoanBusinessTypes = model.LoanBusinessTypes;
            loan.LoanForm = model.LoanForm;
            loan.LoanNature = model.LoanNature;
            loan.LoansTo = model.LoansTo;
            loan.LoanTypes = model.LoanTypes;

            repository.Modify(loan);

            repository.Commit();
        }

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="model">还款记录视图模型</param>
        public void Payment(PaymentViewModel model)
        {
            if (model.Payments == null)
            {
                throw new ArgumentAppException("还款记录不可为空.");
            }

            var loan = repository.Get(model.LoanId);

            model.Payments.Where(m => m.Hidden).ToList().ForEach(payment=> {
                if (payment.Id != null)
                {
                    // 修改
                    Mapper.Map(payment, loan.Payments.Where(m=>m.Hidden).Single(m => m.Id == payment.Id.Value));
                }
                else
                {
                    // 新增
                    loan.AddPaymentHistory(Mapper.Map<PaymentHistory>(payment));
                }
            });

           
           
            //var payments = Mapper.Map<IEnumerable<PaymentHistory>>(model.Payments);
            //new UpdateBind().Bind(loan.Payments, model.Payments);

            foreach (var payment in loan.Payments)
            {
               // payment.LoanId = model.LoanId;
                paymentService.Payment(loan, payment);
            }

            repository.Modify(loan);
            repository.Commit();
            //// 报文追踪转移至流程处理
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchString">借据编号</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="status">借据状态</param>
        /// <returns></returns>
        public IPagedList<LoanViewModel> PagedList(string searchString, int page, int size, LoanStatusEnum? status)
        {
            var loans = repository.PagedList(searchString, page, size, status);

            var models = Mapper.Map<IPagedList<LoanViewModel>>(loans);

            return models;
        }
    }
}
