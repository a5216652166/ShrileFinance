namespace Application.Mappings
{
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using Core.Entities.Process;
    using Core.Entities.Produce;
    using Core.Entities.Vehicle;
    using ViewModels.AccountViewModels;
    using ViewModels.CreditInvesitigation.TraceViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.PartnerViewModels;
    using ViewModels.VehicleViewModel;
    using X.PagedList;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap(typeof(IPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PagedListTypeConverter<,>));

            CreateMap<Core.Entities.AppUser, UserViewModel>()
                ////.ForMember(d => d.Role, opt => opt.ResolveUsing(s => Infrastructure.Helper.RoleIdToName(s.RoleId)))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.PhoneNumber));

            CreateMap<Instance, ViewModels.ProcessViewModels.InstanceViewModel>()
                .ConvertUsing(s => new ViewModels.ProcessViewModels.InstanceViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Flow = s.Flow.Name,
                    CurrentNode = s.CurrentNode?.Name,
                    CurrentUser = s.CurrentUser?.Name,
                    ProcessUser = s.ProcessUser?.Name,
                    ProcessTime = s.ProcessTime,
                    StartUser = s.StartUser.Name,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Status = s.Status
                });
            CreateMap<FAction, ViewModels.ProcessViewModels.ActionViewModel>();

            CreateMap<Partner, PartnerViewModel>()
                .ForMember(d => d.Approvers, opt => opt.ResolveUsing(s => s.Approvers.Select(m => m.Id)));
            CreateMap<Produce, ProduceOptionViewModel>();

            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<AssociatedEnterprise, AssociatedEnterpriseViewModel>();
            CreateMap<OrganizationParent, ParentViewModel>();
            CreateMap<OrganizationProperties, PropertiesViewModel>();
            CreateMap<OrganizationState, StateViewModel>();
            CreateMap<Manager, ManagerViewModel>();
            CreateMap<FinancialAffairs, FinancialAffairsViewModel>();
            CreateMap<Organization, BaseViewModel>();
            CreateMap<Stockholder, StockholderViewModel>();
            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationContact, ContactViewModel>();
            CreateMap<FamilyMember, FamilyMemberViewModel>();
            CreateMap<OrganizateComboViewModel, BaseViewModel>();
            CreateMap<CashFlow, CashFlowViewModel>();
            CreateMap<Liabilities, LiabilitiesViewModel>();
            CreateMap<Litigation, LitigationViewModel>();
            CreateMap<BigEvent, BigEventViewModel>();
            CreateMap<Profit, ProfitViewModel>();
            CreateMap<InstitutionIncomeExpenditure, InstitutionIncomeExpenditureViewModel>();
            CreateMap<InstitutionLiabilities, InstitutionLiabilitiesViewModel>();

            CreateMap<OldProduce, ViewModels.ProduceViewModel.ProduceViewModel>();
            CreateMap<OldProduce, ViewModels.ProduceViewModel.ProduceListViewModel>();
            CreateMap<FinancingItem, ViewModels.ProduceViewModel.FinancingItemViewModel>();
            CreateMap<FinancingProject, ViewModels.ProduceViewModel.FinancingProjectViewModel>();
            CreateMap<Finance, FinanceApplyViewModel>();
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<Applicant, ApplicationViewModel>();
            CreateMap<Contract, ContractViewModel>();
            CreateMap<Finance, LoanViewModel>();
            CreateMap<CreditExamine, CreditExamineViewModel>();
            CreateMap<FinanceExtension, OperationViewModel>();
            CreateMap<FinanceProduce, FinanceProduceViewModel>();

            // 征信报文
            CreateMap<Trace, TraceViewModel>();
        }
    }
}
