namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Loan;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories;
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

        public ProcessAppService(
            IInstanceRepository instanceReopsitory,
            IProcessTempDataRepository processTempDataRepository,
            IOrganizationRepository organizationRepository,
            ICreditContractRepository creditContractRepository,
            ILoanRepository loanRepository)
        {
            this.instanceReopsitory = instanceReopsitory;
            this.processTempDataRepository = processTempDataRepository;
            this.organizationRepository = organizationRepository;
            this.creditContractRepository = creditContractRepository;
            this.loanRepository = loanRepository;
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
            processData.Payments = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<ICollection<PaymentHistoryViewModel>>();

            var loan = loanRepository.Get(processData.Payments.First().LoanId);

            foreach (var item in loan.Payments)
            {
                processData.Payments.Add(Mapper.Map<PaymentHistoryViewModel>(item));
            }
        }

        /// <summary>
        /// 获取机构变更的流程数据
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="processData">流程数据</param>
        private void GetProcessDataForOrganizationModify(Guid instanceId, ProcessDataViewModel processData)
            => processData.OrganizationChange = processTempDataRepository.GetByInstanceId(instanceId)?.ConvertToObject<OrganizationChangeViewModel>();
    }
}
