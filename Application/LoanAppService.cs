namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
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
        private readonly ILoanRepository loanRepository;
        private readonly DatagramAppService messageAppService;
        private readonly IPaymentHistoryRepository paymentRepository;

        public LoanAppService(
            LoanService loanService,
            PaymentService paymentService,
            ILoanRepository loanRepository,
            ICreditContractRepository creditRepository,
            DatagramAppService messageAppService,
            IPaymentHistoryRepository paymentRepository)
        {
            this.loanService = loanService;
            this.paymentService = paymentService;
            this.loanRepository = loanRepository;
            this.creditRepository = creditRepository;
            this.messageAppService = messageAppService;
            this.paymentRepository = paymentRepository;
        }

        /// <summary>
        /// 获取借据实例
        /// </summary>
        /// <param name="id">借据标识</param>
        /// <returns></returns>
        public LoanViewModel Get(Guid id)
        {
            var loan = loanRepository.Get(id);

            if (loan != null)
            {
                return Mapper.Map<LoanViewModel>(loan);
            }

            throw new ArgumentAppException("借据标识错误！");
        }

        public bool CheckLoanNumber(string loanNumber)
        {
            if (!string.IsNullOrEmpty(loanNumber))
            {
                return loanRepository.GetAll(m => m.ContractNumber == loanNumber).Count() == 0;
            }

            throw new ArgumentOutOfRangeAppException(string.Empty, "借据编号不能为空.");
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

            // 从数据库中删除旧实体
            loanRepository.RemoveOldEntity(loan.Id);

            loanRepository.Create(loan);

            model.Id = loan.Id;
            ////// 报文追踪（放款）
            ////messageAppService.Trace(referenceId: loan.Id, traceType: TraceTypeEnum.借款, defaultName: $"申请借据，贷款合同编号：{credit.CreditContractCode}", specialDate: loan.SpecialDate);
        }

        public decimal GetBalance(Guid id, decimal principle)
        {
            var loan = loanRepository.Get(id);

            return loan.Balance + (principle - loan.Principle);
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

            var loan = loanRepository.Get(model.Id.Value);
            loan.InterestRate = model.InterestRate;
            loan.LoanBusinessTypes = model.LoanBusinessTypes;
            loan.LoanForm = model.LoanForm;
            loan.LoanNature = model.LoanNature;
            loan.LoansTo = model.LoansTo;
            loan.LoanTypes = model.LoanTypes;

            loanRepository.Modify(loan);

            loanRepository.Commit();
        }

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="model">还款实体</param>
        public void Payment(PaymentViewModel model)
        {
            if (model.Payments.Count() == 0)
            {
                throw new ArgumentAppException("还款记录不可为空.");
            }

            decimal paymentCount = 0;
            var loan = loanRepository.Get(model.LoanId);
            var modelPaymentIds = from item in model.Payments.Where(m => m.Id != null) select item.Id.Value;
            var removeItem = new List<PaymentHistory>();
            foreach (var item in loan.Payments.Where(m => m.Hidden == HiddenEnum.审核中 && m.InstanceId == model.Payments.First().InstanceId))
            {
                if (modelPaymentIds.Contains(item.Id) == false)
                {
                    removeItem.Add(item);
                }
            }

            removeItem.ForEach(m =>
            {
                loan.Payments.Remove(m);
                paymentRepository.Remove(m);
            });

            foreach (var payment in model.Payments)
            {
                if (payment.Id != null)
                {
                    var payments = loan.Payments.Where(m => m.Hidden == HiddenEnum.审核中 && m.Id == payment.Id.Value);
                    if (payments.Count() > 0)
                    {
                        // 修改
                        Mapper.Map(payment, payments.Single());
                    }
                }
                else
                {
                    // 新增
                    loan.AddPaymentHistory(Mapper.Map<PaymentHistory>(payment));
                }
            }

            foreach (var payment in loan.Payments)
            {
                paymentCount += payment.ActualPaymentPrincipal;

                paymentService.Payment(loan, payment);
            }

            if (loan.Balance < paymentCount)
            {
                throw new ArgumentAppException("该借据余额已不足.");
            }

            loanRepository.Modify(loan);
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
            var loans = loanRepository.PagedList(searchString, page, size, status);

            var models = Mapper.Map<IPagedList<LoanViewModel>>(loans);

            var creditIds = (from item in models select item.CreditId).ToListAsync().Result;
            var credits = creditRepository.GetAll(m => creditIds.Contains(m.Id)).ToListAsync().Result;

            foreach (var model in models)
            {
                var credit = credits.Single(m => m.Id == model.CreditId);

                model.CreditContractCode = credit.CreditContractCode;
                model.OrganizateName = credit.Organization.Property.InstitutionChName;
            }

            return models;
        }
    }
}
