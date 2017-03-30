namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.ViewModels;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Loan;
    using Core.Entities.Process;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.Loan.LoanViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.ProcessViewModels;

    public class ProcessAppService
    {
        private readonly IInstanceRepository instanceReopsitory;
        private readonly IProcessTempDataRepository processTempDataRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ICreditContractRepository creditContractRepository;
        private readonly ILoanRepository loanRepository;
        private readonly ProcessTempDataAppService processTempDataAppService;
        private readonly OrganizationAppService organizationAppService;
        private readonly CreditContractAppService creditContractAppService;
        private readonly LoanAppService loanAppService;
        private readonly PaymentHistoryAppService paymentHistoryAppService;

        public ProcessAppService(
            IInstanceRepository instanceReopsitory,
            IProcessTempDataRepository processTempDataRepository,
            IOrganizationRepository organizationRepository,
            ICreditContractRepository creditContractRepository,
            ILoanRepository loanRepository,
            ProcessTempDataAppService processTempDataAppService,
            OrganizationAppService organizationAppService,
            CreditContractAppService creditContractAppService,
            LoanAppService loanAppService,
            PaymentHistoryAppService paymentHistoryAppService)
        {
            this.instanceReopsitory = instanceReopsitory;
            this.processTempDataRepository = processTempDataRepository;
            this.organizationRepository = organizationRepository;
            this.creditContractRepository = creditContractRepository;
            this.loanRepository = loanRepository;
            this.processTempDataAppService = processTempDataAppService;
            this.organizationAppService = organizationAppService;
            this.creditContractAppService = creditContractAppService;
            this.loanAppService = loanAppService;
            this.paymentHistoryAppService = paymentHistoryAppService;
        }

        /// <summary>
        /// 获取流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public ProcessDataViewModel GetProcessData(Guid instanceId)
        {
            var processData = new ProcessDataViewModel() { InstanceId = instanceId };

            var processType = instanceReopsitory.Get(instanceId)?.ProcessType;

            switch (processType)
            {
                default:
                    throw new ArgumentException("该流程实例的类型不存在");
                case ProcessTypeEnum.融资:
                    GetProcessDataForFinance(instanceId, processData);
                    break;
                case ProcessTypeEnum.添加机构:
                    GetProcessDataForOrganization(instanceId, processData);
                    break;
                case ProcessTypeEnum.授信:
                    GetProcessDataForCreditContract(instanceId, processData);
                    break;
                case ProcessTypeEnum.借据:
                    GetProcessDataForLoan(instanceId, processData);
                    break;
                case ProcessTypeEnum.还款:
                    GetProcessDataForPaymentHistory(instanceId, processData);
                    break;
                case ProcessTypeEnum.机构变更:
                    GetProcessDataForOrganizationModify(instanceId, processData);
                    break;
            }

            return processData;
        }

        /// <summary>
        /// 创建临时数据
        /// </summary>
        /// <typeparam name="TViewModel">视图类型</typeparam>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="viewModel">视图</param>
        /// <param name="instanceId">流程实例标识</param>
        /// <returns>实体</returns>
        public TEntity CreateProcessData<TViewModel, TEntity>(TViewModel viewModel, Guid instanceId) where TViewModel : class where TEntity : class
        {
            var entity = default(TEntity);

            if (viewModel is OrganizationViewModel)
            {
                var organization = organizationAppService.Create(viewModel as OrganizationViewModel);

                var processTempDataViewModel = new ProcessTempDataViewModel<Organization>()
                {
                    InstanceId = instanceId,
                    ObjData = organization
                };

                processTempDataAppService.Create(processTempDataViewModel);

                entity = organization as TEntity;
            }
            else if (viewModel is CreditContractViewModel)
            {
                var creditContract = creditContractAppService.Create(viewModel as CreditContractViewModel);
                
                CreateProcessTempData(creditContract, instanceId);

                entity = creditContract as TEntity;
            }
            else if (viewModel is LoanViewModel)
            {
                var loan = loanAppService.ApplyLoan(viewModel as LoanViewModel);

                ////var processTempDataViewModel = new ProcessTempDataViewModel<Loan>()
                ////{
                ////    InstanceId = instanceId,
                ////    ObjData = loan
                ////};

                ////processTempDataAppService.Create(processTempDataViewModel);

                CreateProcessTempData(loan, instanceId);

                entity = loan as TEntity;
            }
            else if (viewModel is PaymentViewModel)
            {
                var payments = paymentHistoryAppService.AddPayments(viewModel as PaymentViewModel);

                CreateProcessTempData(payments, instanceId);

                entity = payments as TEntity;
            }
            else if (viewModel is OrganizationChangeViewModel)
            {
                var organizationChange = viewModel as OrganizationChangeViewModel;

                CreateProcessTempData(organizationChange, instanceId);
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(message: $"{typeof(TEntity).Name}类型错误或为Null");
            }

            return entity;
        }

        public TEntity SubmitProcessData<TEntity>(Guid instanceId) where TEntity : class
        {
            var entity = default(TEntity);

            var entityType = typeof(TEntity);

            if (entityType == typeof(Organization))
            {
                // 获取机构实体
                var processTempDataViewModel = processTempDataAppService.GetByInstanceId<TEntity>(instanceId);

                // 从流程临时数据中提取数据
                entity = processTempDataViewModel.ObjData;

                organizationAppService.Create(entity as Organization);
            }
            else if (entityType == typeof(CreditContract))
            {
                var processTempDataViewModel = processTempDataAppService.GetByInstanceId<TEntity>(instanceId);

                // 从流程临时数据中提取数据
                entity = processTempDataViewModel.ObjData;

                creditContractAppService.Create(entity as CreditContract);
            }
            else if (entityType == typeof(Loan))
            {
                var processTempDataViewModel = processTempDataAppService.GetByInstanceId<TEntity>(instanceId);

                // 从流程临时数据中提取数据
                entity = processTempDataViewModel.ObjData;

                loanAppService.Create(entity as Loan);
            }
            else if (entityType == typeof(IEnumerable<PaymentHistory>))
            {
                var processTempDataViewModel = processTempDataAppService.GetByInstanceId<TEntity>(instanceId);

                // 从流程临时数据中提取数据
                entity = processTempDataViewModel.ObjData;

                paymentHistoryAppService.AddPayments(entity as IEnumerable<PaymentHistory>);
            }
            else if (entityType == typeof(OrganizationChangeViewModel))
            {
                var processTempDataViewModel = processTempDataAppService.GetByInstanceId<TEntity>(instanceId);

                // 从流程临时数据中提取数据
                entity = processTempDataViewModel.ObjData;

                organizationAppService.ModifyPeriods(entity as OrganizationChangeViewModel);
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(message: $"{entityType.Name}类型错误");
            }

            return entity;
        }

        private void GetProcessDataForFinance(Guid instanceId, ProcessDataViewModel processData)
        {
            return;
        }

        /// <summary>
        /// 获取新增机构的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForOrganization(Guid instanceId, ProcessDataViewModel processData)
        {
            var organization = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<Organization>();

            processData.Organization = Mapper.Map<OrganizationViewModel>(organization);
            processData.Organization.Base = Mapper.Map<BaseViewModel>(organization);
        }

        /// <summary>
        /// 获取贷款合同的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForCreditContract(Guid instanceId, ProcessDataViewModel processData)
        {
            var creditContract = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<CreditContract>();

            var creditContractViewModel = Mapper.Map<CreditContractViewModel>(creditContract);

            creditContractViewModel.GuarantyContract = new List<GuarantyContractViewModel>();

            foreach (var item in creditContract.GuarantyContract)
            {
                creditContractViewModel.GuarantyContract.Add(Mapper.Map<GuarantyContractViewModel>(item));
            }

            // 贷款合同ViewModel数据对接(服务页面)
            creditContractViewModel.DataConvertForGuranteeContract();
            creditContractViewModel.GuarantyContract.Clear();

            // 修正机构名称
            creditContractViewModel.OrganizationName = organizationRepository.Get(creditContractViewModel.OrganizationId).Property.InstitutionChName;

            processData.CreditContract = creditContractViewModel;
        }

        /// <summary>
        /// 获取借据的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForLoan(Guid instanceId, ProcessDataViewModel processData)
        {
            var loan = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<Loan>();

            processData.Loan = Mapper.Map<LoanViewModel>(loan);

            var creditContract = creditContractRepository.Get(loan.CreditId);

            // 修正贷款合同编码和机构名称
            processData.Loan.CreditContractCode = creditContract.CreditContractCode;
            processData.Loan.OrganizateName = organizationRepository.Get(creditContract.OrganizationId).Property.InstitutionChName;
        }

        /// <summary>
        /// 获取还款的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForPaymentHistory(Guid instanceId, ProcessDataViewModel processData)
        {
            var paymentHistoryViewModels = new List<PaymentHistoryViewModel>();

            var payments = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<IEnumerable<PaymentHistory>>();

            var loan = loanRepository.Get(payments.First().LoanId);

            // 记录数据库中已有的还款记录
            foreach (var item in loan.Payments)
            {
                var paymentHistoryViewModel = Mapper.Map<PaymentHistoryViewModel>(item);

                paymentHistoryViewModels.Add(paymentHistoryViewModel);
            }

            // 记录当前流程中的还款记录
            var paymentIds = loan.Payments.Select(m => m.Id);
            foreach (var item in payments)
            {
                if (paymentIds.Contains(item.Id))
                {
                    continue;
                }

                var paymentHistoryViewModel = Mapper.Map<PaymentHistoryViewModel>(item);

                paymentHistoryViewModel.Hidden = HiddenEnum.审核中;

                paymentHistoryViewModels.Add(paymentHistoryViewModel);
            }

            processData.Payments = new PaymentViewModel()
            {
                LoanId = loan.Id,
                Loan = Mapper.Map<LoanViewModel>(loan),
                Payments = paymentHistoryViewModels
            };
        }

        /// <summary>
        /// 获取机构变更的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForOrganizationModify(Guid instanceId, ProcessDataViewModel processData)
            => processData.OrganizationChange = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<OrganizationChangeViewModel>();

        /// <summary>
        /// 创建临时数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="instanceId">流程实例标识</param>
        private void CreateProcessTempData<T>(T obj, Guid instanceId) where T : class
        {
            var processTempDataViewModel = new ProcessTempDataViewModel<T>()
            {
                InstanceId = instanceId,
                ObjData = obj
            };

            processTempDataAppService.Create(processTempDataViewModel);
        }
    }
}
