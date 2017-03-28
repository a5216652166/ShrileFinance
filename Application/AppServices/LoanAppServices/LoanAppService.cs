namespace Application
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using Core.Services.Loan;
    using ViewModels.Loan.LoanViewModels;
    using X.PagedList;

    public class LoanAppService
    {
        private readonly ICreditContractRepository creditContractRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IPaymentHistoryRepository paymentHistoryRepository;
        private readonly IProcessTempDataRepository processTempDataRepository;
        private readonly LoanService loanService;
        private readonly PaymentService paymentService;
        private readonly DatagramAppService datagramAppService;

        public LoanAppService(
            ICreditContractRepository creditContractRepository,
            ILoanRepository loanRepository,
            IPaymentHistoryRepository paymentHistoryRepository,
            IProcessTempDataRepository processTempDataRepository,
            LoanService loanService,
            PaymentService paymentService,
            DatagramAppService datagramAppService)
        {
            this.loanService = loanService;
            this.paymentService = paymentService;
            this.loanRepository = loanRepository;
            this.creditContractRepository = creditContractRepository;
            this.datagramAppService = datagramAppService;
            this.paymentHistoryRepository = paymentHistoryRepository;
            this.processTempDataRepository = processTempDataRepository;
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

        /// <summary>
        /// 申请借据
        /// </summary>
        /// <param name="model">借据视图模型</param>
        /// <returns>借据实体</returns>
        public Loan ApplyLoan(LoanViewModel model)
        {
            var loan = Mapper.Map<Loan>(model);

            // 修正新借据的状态
            loan.Status = loan.Status == 0 ? LoanStatusEnum.正常 : loan.Status;

            // 验证新借据
            ValidLoan(loan);

            loan.Id = Guid.NewGuid();

            return loan;
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

        /////// <summary>
        /////// 还款
        /////// </summary>
        /////// <param name="model">还款实体</param>
        ////public void Payment(PaymentViewModel model)
        ////{
        ////    if (model.Payments.Count() == 0)
        ////    {
        ////        throw new ArgumentAppException("还款记录不可为空.");
        ////    }

        ////    decimal paymentCount = 0;
        ////    var loan = loanRepository.Get(model.LoanId);
        ////    var modelPaymentIds = from item in model.Payments.Where(m => m.Id != null) select item.Id.Value;
        ////    var removeItem = new List<PaymentHistory>();
        ////    foreach (var item in loan.Payments.Where(m => m.Hidden == HiddenEnum.审核中 && m.InstanceId == model.Payments.First().InstanceId))
        ////    {
        ////        if (modelPaymentIds.Contains(item.Id) == false)
        ////        {
        ////            removeItem.Add(item);
        ////        }
        ////    }

        ////    removeItem.ForEach(m =>
        ////    {
        ////        loan.Payments.Remove(m);
        ////        paymentHistoryRepository.Remove(m);
        ////    });

        ////    foreach (var payment in model.Payments)
        ////    {
        ////        if (payment.Id != null)
        ////        {
        ////            var payments = loan.Payments.Where(m => m.Hidden == HiddenEnum.审核中 && m.Id == payment.Id.Value);
        ////            if (payments.Count() > 0)
        ////            {
        ////                // 修改
        ////                Mapper.Map(payment, payments.Single());
        ////            }
        ////        }
        ////        else
        ////        {
        ////            // 新增
        ////            loan.AddPaymentHistory(Mapper.Map<PaymentHistory>(payment));
        ////        }
        ////    }

        ////    foreach (var payment in loan.Payments)
        ////    {
        ////        paymentCount += payment.ActualPaymentPrincipal;

        ////        paymentService.Payment(loan, payment);
        ////    }

        ////    if (loan.Balance < paymentCount)
        ////    {
        ////        throw new ArgumentAppException("该借据余额已不足.");
        ////    }

        ////    loanRepository.Modify(loan);
        ////}

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
            var credits = creditContractRepository.GetAll(m => creditIds.Contains(m.Id)).ToListAsync().Result;

            foreach (var model in models)
            {
                var credit = credits.Single(m => m.Id == model.CreditId);

                model.CreditContractCode = credit.CreditContractCode;
                model.OrganizateName = credit.Organization.Property.InstitutionChName;
            }

            return models;
        }

        public void Create(Loan entity)
        {
            ValidLoan(entity);

            loanRepository.Create(entity);
        }

        /// <summary>
        /// 验证借据
        /// </summary>
        /// <param name="loan">借据实体</param>
        private void ValidLoan(Loan loan)
        {
            var exception = default(Exception);

            var creditContract = creditContractRepository.Get(loan.CreditId);

            if (creditContract.Loans.Select(m => m.ContractNumber).Contains(loan.ContractNumber))
            {
                exception = new ArgumentOutOfRangeAppException(message: $"借据编号{loan.ContractNumber}已存在");
            }

            if (!creditContract.CanApplyLoan(loan.Principle, loan.SpecialDate))
            {
                exception = new InvalidOperationAppException(message: "申请贷款失败, 请确认授信合同是否有效、授信余额是否充足借据放款时间是否在合同有效期内.");
            }

            if (exception != default(Exception))
            {
                throw exception;
            }
        }
    }
}
