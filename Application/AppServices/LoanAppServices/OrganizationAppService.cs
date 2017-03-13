namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;
    using ViewModels;
    using ViewModels.OrganizationViewModels;
    using X.PagedList;

    public class OrganizationAppService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IProcessTempDataRepository processTempDataRepository;
        private readonly DatagramAppService datagramAppService;

        public OrganizationAppService(
            IOrganizationRepository organizationRepository,
            IProcessTempDataRepository processTempDataRepository,
            DatagramAppService datagramAppService)
        {
            this.organizationRepository = organizationRepository;
            this.processTempDataRepository = processTempDataRepository;
            this.datagramAppService = datagramAppService;
        }

        /// <summary>
        /// 创建机构
        /// </summary>
        /// <param name="model">机构视图</param>
        /// <returns>机构实体</returns>
        public Organization Create(OrganizationViewModel model)
        {
            var organization = Mapper.Map<Organization>(model.Base);
            organization = Mapper.Map(model, organization);

            organization.AssociatedEnterprises = Mapper.Map<ICollection<AssociatedEnterprise>>(model.AssociatedEnterprises);
            organization.BigEvent = Mapper.Map<ICollection<BigEvent>>(model.BigEvent);
            organization.Litigation = Mapper.Map<ICollection<Litigation>>(model.Litigation);
            organization.Managers = Mapper.Map<ICollection<Manager>>(model.Managers);
            organization.Shareholders = Mapper.Map<ICollection<Stockholder>>(model.Shareholders);

            if (model.FinancialAffairs != null)
            {
                organization.FinancialAffairs = new FinancialAffairs()
                {
                    Id = Guid.Empty,
                    Year = model.FinancialAffairs.Year,
                    TypeSubdivision = model.FinancialAffairs.TypeSubdivision,
                    AuditFirm = model.FinancialAffairs.AuditFirm,
                    AuditorDate = model.FinancialAffairs.AuditorDate,
                    AuditorName = model.FinancialAffairs.AuditorName
                };

                organization.FinancialAffairs.IncomeExpenditur = Mapper.Map<ICollection<InstitutionIncomeExpenditure>>(model.FinancialAffairs.IncomeExpenditur);
                organization.FinancialAffairs.InstitutionLiabilities = Mapper.Map<ICollection<InstitutionLiabilities>>(model.FinancialAffairs.InstitutionLiabilities);
                organization.FinancialAffairs.Liabilities = Mapper.Map<ICollection<Liabilities>>(model.FinancialAffairs.Liabilities);
                organization.FinancialAffairs.Profit = Mapper.Map<ICollection<Profit>>(model.FinancialAffairs.Profit);
                organization.FinancialAffairs.CashFlow = Mapper.Map<ICollection<CashFlow>>(model.FinancialAffairs.CashFlow);
            }

            // 移除已存在的机构
            var oldEntity = organizationRepository.Get(model.Id.HasValue ? model.Id.Value : Guid.Empty);
            if (oldEntity != default(Organization))
            {
                organizationRepository.Remove(oldEntity);
            }

            organization.Id = Guid.NewGuid();

            return organization;

            //// 报文追踪转移至流程处理
        }

        public void Create(Organization entity)
            => organizationRepository.Create(entity);

        public void Modify(OrganizationViewModel model)
        {
            var customer = organizationRepository.Get(model.Base.Id.Value);
            Mapper.Map(model.Base, customer);
            Mapper.Map(model, customer);

            // 映射财务
            if (model.FinancialAffairs != null)
            {
                new UpdateBind().Bind(customer.FinancialAffairs.Liabilities, model.FinancialAffairs.Liabilities);
                new UpdateBind().Bind(customer.FinancialAffairs.CashFlow, model.FinancialAffairs.CashFlow);
                new UpdateBind().Bind(customer.FinancialAffairs.IncomeExpenditur, model.FinancialAffairs.IncomeExpenditur);
                new UpdateBind().Bind(customer.FinancialAffairs.InstitutionLiabilities, model.FinancialAffairs.InstitutionLiabilities);
                new UpdateBind().Bind(customer.FinancialAffairs.Profit, model.FinancialAffairs.Profit);
            }

            new UpdateBind().Bind(customer.BigEvent, model.BigEvent);
            new UpdateBind().Bind(customer.Litigation, model.Litigation);
            new UpdateBind().Bind(customer.Managers, model.Managers);

            model.Managers.ToList().ForEach(m =>
            {
                var familyMembersEntity = customer.Managers.ToList().Find(c => c.Id == m.Id && c.Id != Guid.Empty);
                if (familyMembersEntity != null)
                {
                    familyMembersEntity.FamilyMembers.Clear();
                    new UpdateBind().Bind(familyMembersEntity.FamilyMembers, m.FamilyMembers);
                }
            });
            new UpdateBind().Bind(customer.Shareholders, model.Shareholders);

            model.Shareholders.ToList().ForEach(m =>
            {
                var shareholders = customer.Shareholders.ToList().Find(c => c.Id == m.Id && c.Id != Guid.Empty);
                if (shareholders != null)
                {
                    shareholders.FamilyMembers.Clear();
                    new UpdateBind().Bind(shareholders.FamilyMembers, m.FamilyMembers);
                }
            });

            new UpdateBind().Bind(customer.AssociatedEnterprises, model.AssociatedEnterprises);

            organizationRepository.Modify(customer);
            organizationRepository.Commit();
        }

        public void ModifyPeriods(OrganizationChangeViewModel model)
        {
            var organizate = organizationRepository.Get(model.Base.Id.Value);

            // 映射基础信息
            Mapper.Map(model.Base, organizate);

            organizate.CustomerNumber = model.Base.CustomerNumber;
            organizate.ManagementerCode = model.Base.ManagementerCode;

            if (model.Periods.Contains("Property"))
            {
                Mapper.Map(model.Property, organizate.Property);
            }

            if (model.Periods.Contains("State"))
            {
                Mapper.Map(model.State, organizate.State);
            }

            if (model.Periods.Contains("Contact"))
            {
                Mapper.Map(model.Contact, organizate.Contact);
            }

            if (model.Periods.Contains("Managers"))
            {
                new UpdateBind().Bind(organizate.Managers, model.Managers);
                model.Managers.ToList().ForEach(m =>
                {
                    var familyMembersEntity = organizate.Managers.ToList().Find(c => c.Id == m.Id && c.Id != Guid.Empty);
                    if (familyMembersEntity != null)
                    {
                        familyMembersEntity.FamilyMembers.Clear();
                        new UpdateBind().Bind(familyMembersEntity.FamilyMembers, m.FamilyMembers);
                    }
                });
            }

            if (model.Periods.Contains("Shareholders"))
            {
                new UpdateBind().Bind(organizate.Shareholders, model.Shareholders);
                model.Shareholders.ToList().ForEach(m =>
                {
                    var shareholders = organizate.Shareholders.ToList().Find(c => c.Id == m.Id && c.Id != Guid.Empty);
                    if (shareholders != null)
                    {
                        shareholders.FamilyMembers.Clear();
                        new UpdateBind().Bind(shareholders.FamilyMembers, m.FamilyMembers);
                    }
                });
            }

            if (model.Periods.Contains("AssociatedEnterprises"))
            {
                new UpdateBind().Bind(organizate.AssociatedEnterprises, model.AssociatedEnterprises);
            }

            if (model.Periods.Contains("Parent"))
            {
                Mapper.Map(model.Contact, organizate.Contact);
            }

            if (model.Periods.Contains("FinancialAffairs"))
            {
                new UpdateBind().Bind(organizate.FinancialAffairs.Liabilities, model.FinancialAffairs.Liabilities);
                new UpdateBind().Bind(organizate.FinancialAffairs.CashFlow, model.FinancialAffairs.CashFlow);
                new UpdateBind().Bind(organizate.FinancialAffairs.IncomeExpenditur, model.FinancialAffairs.IncomeExpenditur);
                new UpdateBind().Bind(organizate.FinancialAffairs.InstitutionLiabilities, model.FinancialAffairs.InstitutionLiabilities);
                new UpdateBind().Bind(organizate.FinancialAffairs.Profit, model.FinancialAffairs.Profit);
            }

            if (model.Periods.Contains("Litigation"))
            {
                new UpdateBind().Bind(organizate.Litigation, model.Litigation);
            }

            if (model.Periods.Contains("BigEvent"))
            {
                new UpdateBind().Bind(organizate.BigEvent, model.BigEvent);
            }

            organizationRepository.Modify(organizate);
        }

        public OrganizationViewModel Get(Guid id)
        {
            var customer = organizationRepository.Get(id);

            var model = Mapper.Map<OrganizationViewModel>(customer);
            model.Base = Mapper.Map<BaseViewModel>(customer);

            return model;
        }

        public CreditOraganizateViewModel GetCreditOrganizate(Guid id)
        {
            Organization customer = organizationRepository.Get(id);
            CreditOraganizateViewModel model = new CreditOraganizateViewModel()
            {
                CustomerNumber = customer.CustomerNumber,
                LoanCardCode = customer.LoanCardCode,
                InstitutionChName = customer.Property.InstitutionChName,
                ManagementerCode = customer.ManagementerCode,
                RegisterAddress = customer.Property.RegisterAddress,
                RegisterCapital = customer.Property.RegisterCapital,
                SetupDate = customer.Property.SetupDate
            };

            return model;
        }

        public List<OrganizateComboViewModel> GetAll()
        {
            var customer = organizationRepository.GetAll();
            List<OrganizateComboViewModel> custviewmodelList = new List<OrganizateComboViewModel>();
            if (customer != null)
            {
                foreach (var item in customer)
                {
                    custviewmodelList.Add(new OrganizateComboViewModel()
                    {
                        InstitutionChName = item.Property.InstitutionChName,
                        Id = item.Id
                    });
                }
            }

            return custviewmodelList;
        }

        public List<OriganizateOptions> GetOptions()
        {
            var list = from item in organizationRepository.GetAll()
                       select new OriganizateOptions() { Value = item.Id, Text = item.Property.InstitutionChName };

            return list.ToListAsync().Result;
        }

        /// <summary>
        /// 带分页查询
        /// </summary>
        /// yand    16.10.30
        /// <param name="serach">查询条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <returns></returns>
        public PagedListViewModel<OragnizateListItemViewModel> GetPageList(string serach, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(serach))
            {
                serach = string.Empty;
            }

            var pagedlist =
                organizationRepository
                .PagedList(m => m.Property.InstitutionChName.Contains(serach), pageNumber, pageSize);

            var list = pagedlist.Select(m =>
                new OragnizateListItemViewModel
                {
                    Id = m.Id,
                    CustomerNumber = m.CustomerNumber,
                    InstitutionChName = m.Property.InstitutionChName,
                    InstitutionCreditCode = m.InstitutionCreditCode,
                    LoanCardCode = m.LoanCardCode,
                    ManagementerCode = m.ManagementerCode,
                    CreatedDate = m.CreatedDate
                });

            return new PagedListViewModel<OragnizateListItemViewModel>(new PagedList<OragnizateListItemViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}
