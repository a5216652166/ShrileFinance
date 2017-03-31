namespace Application.Mappings
{
    using System.Linq;
    using Application.ViewModels.AccountViewModels;
    using Application.ViewModels.FinanceViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels.ProduceViewModels;
    using Application.ViewModels.PartnerViewModels;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;

    public class FinanceDomainToCreditInvestigationProfile : Profile
    {
        public FinanceDomainToCreditInvestigationProfile()
        {
            CreateMap<AppUser, UserViewModel>();

            CreateMap<Partner, PartnerViewModel>()
                .ForMember(m => m.Accounts, m => m.MapFrom(o => o.Accounts))
                .ForMember(m => m.Approvers, m => m.Ignore())
                .ForMember(m => m.Produces, m => m.MapFrom(o => o.Produces.Select(t => new ProduceOptionViewModel() { Id = t.Id, Code = t.Code })));

            CreateMap<Finance, FinanceApplyViewModel>()
               .ForMember(m => m.Contact, m => m.Ignore())
               .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem))
               .ForMember(m => m.CreateBy, m => m.MapFrom(o => o.CreateBy))
               .ForMember(m => m.CreateOf, m => m.MapFrom(o => o.CreateOf))
               .ForMember(m => m.Produce, m => m.MapFrom(o => o.Produce));

            CreateMap<Produce, ProduceViewModel>()
                .ForMember(m => m.RepayPrincipal, m => m.MapFrom(o => o.RepayPrincipals.Split('-')));

            CreateMap<Produce, ProduceListViewModel>()
                .ForMember(m => m.RepayPrincipal, m => m.MapFrom(o => o.RepayPrincipals.Split('-')))
                .ForMember(m => m.YearRate, m => m.MapFrom(o => o.MonthRate * 12));

            CreateMap<RepayTable, RepayTableViewModel>();

            CreateMap<FinancialItem, FinancialItemViewModel>();

            CreateMap<FinancialLoan, FinancialLoanListViewModel>()
                .ForMember(m => m.NewProduceCode, m => m.MapFrom(o => o.NewProduce.Code))
                .ForMember(m => m.NewProduceTimeLimit, m => m.MapFrom(o => o.NewProduce.TimeLimit));

            CreateMap<FinancialLoan, FinancialLoanViewModel>()
                .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem.OrderBy(t => t.Name)));
        }
    }
}
