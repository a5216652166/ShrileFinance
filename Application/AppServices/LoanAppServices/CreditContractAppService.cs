﻿namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Loan;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.LoanRepositories;
    using ViewModels.Loan.CreditViewModel;
    using X.PagedList;

    public class CreditContractAppService
    {
        private readonly ICreditContractRepository creditContractRepository;
        private readonly DatagramAppService messageAppService;

        public CreditContractAppService(
            ICreditContractRepository creditContractRepository,
             DatagramAppService messageAppService)
        {
            this.creditContractRepository = creditContractRepository;
            this.messageAppService = messageAppService;
        }

        /// <summary>
        /// 创建授信合同
        /// </summary>
        /// <param name="model">授信合同Model</param>
        /// <returns>授信合同实体</returns>
        public CreditContract Create(CreditContractViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "贷款合同数据为空！");
            }

            var creditContract = Mapper.Map<CreditContract>(model);

            // 贷款合同ViewModel数据对接（协调后台）
            model.DataConvertForGurantyContract();

            if (model.GuarantyContract != null && model.GuarantyContract.Count > 0)
            {
                new UpdateBind().Bind(creditContract.GuarantyContract, model.GuarantyContract);
            }

            // 贷款合同校验
            ValidCreditContract(creditContract);

            // 修正担保合同的担保金额和编号
            creditContract.AmentGuarantyContractMargin();
            creditContract.AmentGuarantyContractNumber();

            creditContract.Id = Guid.NewGuid();

            return creditContract;
        }

        public void Create(CreditContract entity)
            => creditContractRepository.Create(entity);

        public void Modify(CreditContractViewModel model)
        {
            if (model == null || model.Id.HasValue == false)
            {
                return;
            }

            var creditContract = creditContractRepository.Get(model.Id.Value);

            if (creditContract == null)
            {
                return;
            }

            // 贷款合同ViewModel数据对接（协调后台）
            model.DataConvertForGurantyContract();

            // 担保合同数量
            var creditGuarantyContractCount = creditContract.GuarantyContract.Count;

            // 抵押合同集合
            var mortgages = creditContract.GuarantyContract.Where(m => (m is GuarantyContractMortgage));

            // 防止授信开始日期和结束日期被修改
            model.ExpirationDate = creditContract.ExpirationDate;
            model.EffectiveDate = creditContract.EffectiveDate;

            Mapper.Map(model, creditContract);

            if (model.GuarantyContract == null || model.GuarantyContract.Count == 0)
            {
                creditContract.GuarantyContract.Clear();
            }
            else
            {
                new UpdateBind().Bind(creditContract.GuarantyContract, model.GuarantyContract);
            }

            // 设置担保合同的担保金额
            foreach (var item in creditContract.GuarantyContract)
            {
                item.Margin = creditContract.CreditLimit;
            }

            creditContract.AmentGuarantyContractMargin();

            creditContractRepository.Modify(creditContract);
            ////repository.Commit();
        }

        public CreditContractViewModel Get(Guid id)
        {
            var creditContract = creditContractRepository.Get(id);

            var creditViewModel = Mapper.Map<CreditContractViewModel>(creditContract);

            creditViewModel.GuarantyContract = new List<GuarantyContractViewModel>();
            foreach (var item in creditContract.GuarantyContract)
            {
                creditViewModel.GuarantyContract.Add(Mapper.Map<GuarantyContractViewModel>(item));
            }

            // 贷款合同ViewModel数据对接(服务页面)
            creditViewModel.DataConvertForGuranteeContract();
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
            ////// 用于记录是否有值
            ////var result = true;
            ////var list = repository.GetAll();
            ////CreditContract creditContract = new CreditContract();
            ////if (!string.IsNullOrEmpty(creditContractNumber))
            ////{
            ////    creditContract = list.Where(m => m.CreditContractCode == creditContractNumber).FirstOrDefault();
            ////}
            ////else
            ////{
            ////    throw new ArgumentOutOfRangeAppException(string.Empty, "授信合同编号不能为空.");
            ////}

            ////if (creditContract != null)
            ////{
            ////    result = false;
            ////}

            ////return result;

            if (string.IsNullOrEmpty(creditContractNumber))
            {
                throw new ArgumentOutOfRangeAppException(string.Empty, "授信合同编号不能为空.");
            }

            var creditContracts = creditContractRepository.GetAll(m => m.CreditContractCode == creditContractNumber);

            return creditContracts.Count() == 0;
        }

        /// <summary>
        /// 修改授信金额
        /// </summary>
        /// <param name="limit">金额</param>
        /// <param name="id">标识</param>
        public void ChangeLimit(decimal limit, Guid id)
        {
            var credit = creditContractRepository.Get(id);

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
            creditContractRepository.Modify(model);
            creditContractRepository.Commit();

            // 报文追踪(合同关键数据项有效日期发生变化)
            messageAppService.Trace(referenceId: model.Id, traceType: TraceTypeEnum.合同变更, defaultName: $"授信合同：{model.CreditContractCode}有效日期变更", specialDate: model.EffectiveDate, organizateName: model.Organization.Property.InstitutionChName);
        }

        /// <summary>
        /// 终止授信合同
        /// </summary>
        /// <param name="id">标识</param>
        public void StopStatus(Guid id)
        {
            var creditContract = creditContractRepository.Get(id);

            creditContract.ChangeStutus();

            creditContractRepository.Modify(creditContract);
            creditContractRepository.Commit();

            // 报文追踪
            messageAppService.Trace(referenceId: creditContract.Id, traceType: TraceTypeEnum.终止合同, defaultName: "授信合同：" + creditContract.CreditContractCode + "终止", specialDate: creditContract.EffectiveDate, organizateName: creditContract.Organization.Property.InstitutionChName);
        }

        /// <summary>
        /// 授信合同选项
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CreditContractViewModel> Option()
        {
            var creditContracts = creditContractRepository.GetAll().AsEnumerable();

            var creditContractViewModels = Mapper.Map<IEnumerable<CreditContractViewModel>>(creditContracts);

            foreach (var item in creditContractViewModels)
            {
                item.OrganizationName = creditContracts.Single(m => m.Id == item.Id.Value).Organization.Property.InstitutionChName;
            }

            return creditContractViewModels;
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
            var creditContract = default(IQueryable<CreditContract>);

            if (string.IsNullOrEmpty(serach))
            {
                creditContract = creditContractRepository.GetAll();
            }
            else
            {
                creditContract = creditContractRepository.GetAll(m => m.CreditContractCode.Contains(serach) || m.Organization.Property.InstitutionChName.Contains(serach));
            }

            var pageList = creditContract.OrderByDescending(m => m.Id).ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<CreditContractViewModel>>(pageList);

            foreach (var model in models)
            {
                var entity = pageList.Single(m => m.Id == model.Id.Value);

                model.OrganizationName = entity.Organization.Property.InstitutionChName;
            }

            return models;
        }

        public decimal GetCreditBalanc(Guid id, decimal limit)
        {
            var creditContract = creditContractRepository.Get(id);

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

                    guranteeContractViewModel.PledgeGuarantyContractViewModel = (GuarantyContractPledgeViewModel)item;
                }
                else if (item is GuarantyContractMortgageViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.抵押;

                    guranteeContractViewModel.MortgageGuarantyContractViewModel = (GuarantyContractMortgageViewModel)item;
                }
                else if (item is GuarantyContractViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.保证;

                    guranteeContractViewModel.GuarantyContractViewModel = item;
                }

                // 区分 机构/自然人
                if (item.Guarantor is GuarantyOrganizationViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.机构;

                    guranteeContractViewModel.GuarantyOrganizationViewModel = (GuarantyOrganizationViewModel)item.Guarantor;
                }
                else if (item.Guarantor is GuarantyPersonViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.自然人;

                    guranteeContractViewModel.GuarantyPersonViewModel = (GuarantyPersonViewModel)item.Guarantor;
                }

                // 担保合同（服务页面）集合 接收数据
                model.GuranteeContract.Add(guranteeContractViewModel);
            });
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="entity">授信实体</param>
        private void ChangeEffective(CreditContract entity)
        {
            entity.ChangeLimit(entity.CreditLimit);
            creditContractRepository.Modify(entity);
            creditContractRepository.Commit();

            // 报文追踪(合同关键数据项金额发生变化)
            messageAppService.Trace(referenceId: entity.Id, traceType: TraceTypeEnum.合同变更, defaultName: "授信合同：" + entity.CreditContractCode + "授信额度变更", specialDate: entity.EffectiveDate, organizateName: entity.Organization.Property.InstitutionChName);
        }

        private void ValidCreditContract(CreditContract entity)
        {
            var isExist = creditContractRepository.GetAll(m => m.CreditContractCode == entity.CreditContractCode).Count() > 0;

            if (isExist)
            {
                throw new ArgumentOutOfRangeAppException(message: $"借据编号{entity.CreditContractCode}已存在");
            }

            entity.ValidateEffective();
        }
    }
}
