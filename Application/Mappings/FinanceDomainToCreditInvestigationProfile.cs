namespace Application.Mappings
{
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using ViewModels.FinanceViewModels.PartnerViewModels;

    public class FinanceDomainToCreditInvestigationProfile : Profile
    {
        public FinanceDomainToCreditInvestigationProfile()
        {
            CreateMap<Produce, NewProduceViewModel>();

            CreateMap<Produce, NewProduceListViewModel>()
                .ForMember(m => m.YearRate, m => m.MapFrom(o => o.MonthRate * 12));

            CreateMap<RepayTable, RepayTableViewModel>();

            CreateMap<FinancialItem, FinancialItemViewModel>();

            CreateMap<FinancialLoan, FinancialLoanListViewModel>()
                .ForMember(m => m.NewProduceCode, m => m.MapFrom(o => o.NewProduce.Code))
                .ForMember(m => m.NewProduceTimeLimit, m => m.MapFrom(o => o.NewProduce.TimeLimit));

            CreateMap<FinancialLoan, FinancialLoanViewModel>()
                .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem.OrderBy(t => t.Name)));

            CreateMap<PartnerUser, PartnerUserViewModel>();

            CreateMap<NewPartner, PartnerViewModel>()
                .ForMember(m => m.PartnerUsers, m => m.MapFrom(o => o.PartnerUsers))
                .ForMember(m => m.Produces, m => m.MapFrom(o => o.Produces));
        }
    }
}
