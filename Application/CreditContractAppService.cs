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
    using ViewModels.Loan.CreditViewModel;
    using X.PagedList;

    public class CreditContractAppService
    {
        private readonly ICreditContractRepository repository;
        private readonly DatagramAppService messageAppService;

        public CreditContractAppService(ICreditContractRepository repository, DatagramAppService messageAppService)
        {
            this.repository = repository;
            this.messageAppService = messageAppService;
        }

        /// <summary>
        /// 创建授信合同
        /// </summary>
        /// <param name="model">授信合同Model</param>
        public void Create(CreditContractViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "贷款合同数据为空！");
            }

            var credit = Mapper.Map<CreditContract>(model);

            // 贷款合同ViewModel数据对接
            DataConvert_CreditContractVM(model);

            if (model.GuarantyContract != null && model.GuarantyContract.Count > 0)
            {
                new UpdateBind().Bind(credit.GuarantyContract, model.GuarantyContract);
            }

            if (credit.CreditBalance != credit.CalculateCreditBalance())
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "授信余额不正确.");
            }

            credit.ValidateEffective(credit);
            repository.Create(credit);
            repository.Commit();

            ////// 报文追踪(贷款合同信息记录)
            ////messageAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.签订授信合同, defaultName: $"签订授信合同：{credit.CreditContractCode}", specialDate: credit.EffectiveDate);

            //// 报文追踪(担保合同信息记录)
            ////credit.GuarantyContract.ToList().ForEach(m =>
            ////{
            ////    messageAppService.Trace(referenceId: m.Id, traceType: Core.Entities.CreditInvestigation.TraceTypeEnum.签订授信合同, defaultName: "签订担保合同，担保人：" + m.Guarantor.Name);
            ////});
        }

        public void Modify(CreditContractViewModel model)
        {
            if (model == null || model.Id == null)
            {
                return;
            }

            var credit = repository.Get(model.Id.Value);

            if (credit == null)
            {
                return;
            }

            // 贷款合同ViewModel数据对接
            DataConvert_CreditContractVM(model);

            // 担保合同数量
            var creditGuarantyContractCount = credit.GuarantyContract.Count;

            // 抵押合同集合
            var mortgages = credit.GuarantyContract.Where(m => (m is GuarantyContractMortgage));

            Mapper.Map(model, credit);

            if (model.GuarantyContract == null || model.GuarantyContract.Count == 0)
            {
                credit.GuarantyContract.Clear();
            }
            else
            {
                new UpdateBind().Bind(credit.GuarantyContract, model.GuarantyContract);
            }

            repository.Modify(credit);

            repository.Commit();

            ////// 追加担保、解除担保
            ////if (creditGuarantyContractCount == 0 && model.GuarantyContract.Count > 0)
            ////{
            ////    // 报文追踪(追加担保)
            ////    model.GuarantyContract.ToList().ForEach(m =>
            ////    {
            ////        messageAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.合同变更, defaultName: "授信合同：" + credit.CreditContractCode + $"追加担保，担保人：{m.Guarantor.Name}",dateCreated: );
            ////    });

            ////    //// 报文追踪(主业务信息记录)
            ////    ////messageAppService.Trace(referenceId: credit.Id, traceType: Core.Entities.CreditInvestigation.TraceTypeEnum.合同变更, defaultName: "授信合同：" + credit.CreditContractCode + "变更");
            ////}
            ////else if (creditGuarantyContractCount > 0 && model.GuarantyContract.Count == 0)
            ////{
            ////    // 报文追踪(解除担保)
            ////    model.GuarantyContract.ToList().ForEach(m =>
            ////    {
            ////        messageAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.合同变更, defaultName: "授信合同：" + credit.CreditContractCode + $"解除担保，担保人：{m.Guarantor.Name}");
            ////    });

            ////    //// 报文追踪(主业务信息记录)
            ////    ////messageAppService.Trace(referenceId: credit.Id, traceType: Core.Entities.CreditInvestigation.TraceTypeEnum.合同变更, defaultName: "授信合同：" + credit.CreditContractCode + "变更");
            ////}
            ////else if (creditGuarantyContractCount > 0 && credit.GuarantyContract.Count == model.GuarantyContract.Count)
            ////{
            ////    mortgages.ToList().ForEach(m =>
            ////    {
            ////        var mortgage = model.GuarantyContract.First(g => (g.Id.Equals(m.Id) && g is GuarantyContractMortgageViewModel));

            ////        if (mortgage != null && (mortgage as GuarantyContractMortgageViewModel).AssessmentValue.Value != (m as GuarantyContractMortgage).AssessmentValue.Value)
            ////        {
            ////            // 担保物价值等发生变化
            ////            messageAppService.Trace(referenceId: mortgage.Id.Value, traceType: TraceTypeEnum.合同变更, defaultName: "授信合同：" + credit.CreditContractCode + $"解除担保，担保人：{m.Guarantor.Name}");
            ////        }
            ////    });
            ////}
        }

        public CreditContractViewModel Get(Guid id)
        {
            var credit = repository.Get(id);

            var creditViewModel = Mapper.Map<CreditContractViewModel>(credit);

            creditViewModel.GuarantyContract = new List<GuarantyContractViewModel>();
            foreach (var item in credit.GuarantyContract)
            {
                creditViewModel.GuarantyContract.Add(Mapper.Map<GuarantyContractViewModel>(item));
            }

            // 贷款合同Entity数据对接
            DataConvert_CreditContractET(creditViewModel);
            creditViewModel.GuarantyContract.Clear();

            return creditViewModel;
        }

        /// <summary>
        /// 合同编号唯一性校验
        /// </summary>
        /// <param name="creditContractNumber">授信合同编号</param>
        /// <returns></returns>
        public bool CheckCreditContractNumber(string creditContractNumber)
        {
            // 用于记录是否有值
            var result = true;
            var list = repository.GetAll();
            CreditContract creditContract = new CreditContract();
            if (!string.IsNullOrEmpty(creditContractNumber))
            {
                creditContract = list.Where(m => m.CreditContractCode == creditContractNumber).FirstOrDefault();
            }
            else
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "授信合同编号不能为空.");
            }

            if (creditContract != null)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 修改授信金额
        /// </summary>
        /// <param name="limit">金额</param>
        /// <param name="id">标识</param>
        public void ChangeLimit(decimal limit, Guid id)
        {
            var credit = repository.Get(id);

            credit.CreditLimit = limit;
            ChangeEffective(credit);
        }

        /// <summary>
        /// 合同有效期变更
        /// </summary>
        /// <param name="model">授信实体</param>
        public void ChangeExpirationDate(CreditContract model)
        {
            model.ChangeExpirationDate(model.ExpirationDate);
            repository.Modify(model);
            repository.Commit();

            ////// 报文追踪(合同关键数据项有效日期发生变化)
            ////messageAppService.Trace(referenceId: model.Id, traceType: TraceTypeEnum.合同变更, defaultName: $"授信合同：{model.CreditContractCode}有效日期变更", specialDate: model.EffectiveDate);
        }

        /// <summary>
        /// 可否申请贷款
        /// </summary>
        /// <param name="limit">贷款金额</param>
        /// <returns></returns>
        ////public bool CanApplyLoan(decimal limit)
        ////{
        ////    CreditContract credit = new CreditContract();
        ////    return credit.CanApplyLoan(limit);
        ////}

        /// <summary>
        /// 终止授信合同
        /// </summary>
        /// <param name="id">标识</param>
        public void StopStatus(Guid id)
        {
            var credit = repository.Get(id);
            credit.ChangeStutus();
            repository.Modify(credit);
            repository.Commit();

            ////// 报文追踪
            ////messageAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.终止合同, defaultName: "授信合同：" + credit.CreditContractCode + "终止", specialDate: credit.EffectiveDate);
        }

        /// <summary>
        /// 授信合同选项
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CreditContractViewModel> Option()
        {
            var credits = repository.GetAll().AsEnumerable();

            return Mapper.Map<IEnumerable<CreditContractViewModel>>(credits);
        }

        /// <summary>
        /// 根据合同号和机构客户号筛选
        /// </summary>
        /// <param name="serach">筛选条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<CreditContractViewModel> GetPageList(string serach, int page, int size)
        {
            var creditContract = repository.GetAll();
            if (!string.IsNullOrEmpty(serach))
            {
                creditContract = creditContract.Where(m => m.CreditContractCode.Contains(serach) || m.Organization.Property.InstitutionChName.Contains(serach));
            }

            creditContract = creditContract.OrderByDescending(m => m.Id);
            var pageList = creditContract.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<CreditContractViewModel>>(pageList);

            return models;
        }

        public decimal GetCreditBalanc(Guid id, decimal limit)
        {
            var creditContract = repository.Get(id);
            return creditContract.CalculateCreditBalance() + (limit - creditContract.CreditLimit);
        }

        /// <summary>
        /// 贷款合同ViewModel数据对接
        /// </summary>
        /// <param name="model">贷款合同ViewModel</param>
        private void DataConvert_CreditContractVM(CreditContractViewModel model)
        {
            if (model == null || model.GuranteeContract == null)
            {
                return;
            }

            // 担保合同（协调合同）集合
            model.GuarantyContract = new List<GuarantyContractViewModel>();

            // 担保合同（服务页面）集合
            var guranteeConList = model.GuranteeContract.ToList();

            // 遍历 担保合同（服务页面）集合
            for (var i = 0; i < guranteeConList.Count; i++)
            {
                // 区分 保证/质押/抵押
                if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.保证)
                {
                    model.GuarantyContract.Add(guranteeConList[i].GuarantyContractViewModel);
                }
                else if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.抵押)
                {
                    model.GuarantyContract.Add(guranteeConList[i].MortgageGuarantyContractViewModel);
                }
                else if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.质押)
                {
                    model.GuarantyContract.Add(guranteeConList[i].PledgeGuarantyContractViewModel);
                }

                // 区分 机构/自然人
                if (guranteeConList[i].GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.机构)
                {
                    model.GuarantyContract.ToList()[i].Guarantor = guranteeConList[i].GuarantyOrganizationViewModel;
                }
                else if (guranteeConList[i].GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.自然人)
                {
                    model.GuarantyContract.ToList()[i].Guarantor = guranteeConList[i].GuarantyPersonViewModel;
                }
            }
        }

        /// <summary>
        /// 贷款合同Entity数据对接
        /// </summary>
        /// <param name="model">贷款合同ViewModel</param>
        private void DataConvert_CreditContractET(CreditContractViewModel model)
        {
            if (model == null || model.GuarantyContract.Count == 0)
            {
                return;
            }

            // 担保合同（服务页面）集合
            model.GuranteeContract = new List<GuranteeContractViewModel>();

            // 遍历 担保合同（协调后台）集合
            model.GuarantyContract.ToList().ForEach(item =>
            {
                // 担保合同(服务页面)  局部变量 
                var guranteeContractViewModel = new GuranteeContractViewModel();

                // 区分 保证/质押/抵押
                if (item is GuarantyContractPledgeViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.质押;

                    guranteeContractViewModel.PledgeGuarantyContractViewModel = item as GuarantyContractPledgeViewModel;
                }
                else if (item is GuarantyContractMortgageViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.抵押;

                    guranteeContractViewModel.MortgageGuarantyContractViewModel = item as GuarantyContractMortgageViewModel;
                }
                else if (item is GuarantyContractViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.保证;

                    guranteeContractViewModel.GuarantyContractViewModel = item as GuarantyContractViewModel;
                }

                // 区分 机构/自然人
                if (item.Guarantor is GuarantyOrganizationViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.机构;

                    guranteeContractViewModel.GuarantyOrganizationViewModel = item.Guarantor as GuarantyOrganizationViewModel;
                }
                else if (item.Guarantor is GuarantyPersonViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.自然人;

                    guranteeContractViewModel.GuarantyPersonViewModel = item.Guarantor as GuarantyPersonViewModel;
                }

                // 担保合同（服务页面）集合 接收数据
                model.GuranteeContract.Add(guranteeContractViewModel);
            });
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="model">授信实体</param>
        private void ChangeEffective(CreditContract model)
        {
            model.ChangeLimit(model.CreditLimit);
            repository.Modify(model);
            repository.Commit();

            ////// 报文追踪(合同关键数据项金额发生变化)
            ////messageAppService.Trace(referenceId: model.Id, traceType: TraceTypeEnum.合同变更, defaultName: "授信合同：" + model.CreditContractCode + "授信额度变更", specialDate: model.EffectiveDate);
        }
    }
}
