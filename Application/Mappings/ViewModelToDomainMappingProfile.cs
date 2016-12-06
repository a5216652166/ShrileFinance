﻿namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Loan;
    using Core.Entities.Produce;
    using Core.Entities.Vehicle;
    using ViewModels.AccountViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.OrganizationViewModels;
    using ViewModels.PartnerViewModels;
    using ViewModels.ProduceViewModel;
    using ViewModels.VehicleViewModel;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, AppUser>()
                .ForMember(d => d.Id, opt => opt.Condition(s => !string.IsNullOrEmpty(s.Id)))
                .ForMember(d => d.UserName, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Phone));
            CreateMap<UserInfoViewModel, AppUser>()
                .ForMember(d => d.UserName, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Phone));

            CreateMap<PartnerViewModel, Core.Entities.Partner.Partner>()
                .ForMember(d => d.Produces, opt => opt.Ignore())
                .ForMember(d => d.Accounts, opt => opt.Ignore())
                .ForMember(d => d.Approvers, opt => opt.Ignore());

            CreateMap<AssociatedEnterpriseViewModel, AssociatedEnterprise>();
            CreateMap<ParentViewModel, OrganizationParent>();
            CreateMap<PropertiesViewModel, OrganizationProperties>();
            CreateMap<StateViewModel, OrganizationState>();
            CreateMap<ManagerViewModel, Manager>();
            CreateMap<BaseViewModel, Organization>();
            CreateMap<FinancialAffairsViewModel, FinancialAffairs>();
            CreateMap<StockholderViewModel, Stockholder>();
            CreateMap<OrganizationViewModel, Organization>();
            CreateMap<ContactViewModel, OrganizationContact>();
            CreateMap<FamilyMemberViewModel, FamilyMember>();
            CreateMap<CashFlowViewModel, CashFlow>();
            CreateMap<LiabilitiesViewModel, Liabilities>();
            CreateMap<LitigationViewModel, Litigation>();
            CreateMap<BigEventViewModel, BigEvent>();
            CreateMap<ProfitViewModel, Profit>();
            CreateMap<InstitutionIncomeExpenditureViewModel, InstitutionIncomeExpenditure>();
            CreateMap<InstitutionLiabilitiesViewModel, InstitutionLiabilities>();

            CreateMap<ViewModels.ProduceViewModel.ProduceViewModel, Produce>()
                .ForMember(d => d.FinancingItems, opt => opt.Ignore());
            CreateMap<FinancingItemViewModel, FinancingItem>();
            CreateMap<FinancingProjectViewModel, FinancingProject>();

            // 信审报告
            CreateMap<CreditExamineViewModel, CreditExamine>();
            CreateMap<FinanceAuidtViewModel, Finance>();
            CreateMap<ContractViewModel, Contract>();
            CreateMap<ApplicationViewModel, Applicant>();
            CreateMap<VehicleViewModel, Vehicle>();
            CreateMap<FinanceApplyViewModel, Finance>()
                .ForMember(d => d.Produce, opt => opt.Ignore())
                .ForMember(d => d.FinanceProduce, opt => opt.Ignore())
                .ForMember(d => d.Applicant, opt => opt.Ignore());
            CreateMap<FinanceProduceViewModel, FinanceProduce>();

            // Loan
            CreateMap<ViewModels.Loan.LoanViewModels.LoanViewModel, Loan>()
                .ForMember(m => m.Status, opts => opts.Ignore());
            CreateMap<ViewModels.Loan.LoanViewModels.PaymentHistoryViewModel, PaymentHistory>()
                .ConstructUsing(m => new PaymentHistory(
                    m.ScheduledPaymentPrincipal,
                    m.ScheduledPaymentInterest,
                    m.ActualPaymentPrincipal,
                    m.ActualPaymentInterest))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GuarantyContractViewModel, GuarantyContract>();
            CreateMap<GuarantyContractMortgageViewModel, GuarantyContractMortgage>();
            CreateMap<GuarantyContractPledgeViewModel, GuarantyContractPledge>();
            CreateMap<GuarantyPersonViewModel, GuarantorPerson>();
            CreateMap<GuarantyOrganizationViewModel, GuarantorOrganization>();
            CreateMap<CreditContractViewModel, CreditContract>();
            CreateMap<CreditExamineViewModel, CreditContract>();
        }
    }
}
