namespace Application.Mappings
{
    using System.Linq;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using ViewModels.FinanceViewModels.ProduceViewModels;

    public class FinanceDomainToCreditInvestigationProfile : Profile
    {
        public FinanceDomainToCreditInvestigationProfile()
        {
            CreateMap<NewProduce, NewProduceViewModel>();

            CreateMap<NewProduce, NewProduceListViewModel>()
                .ForMember(m => m.YearRate, m => m.MapFrom(o => o.MonthRate * 12));

            CreateMap<FinancialItem, FinancialItemViewModel>();

            CreateMap<FinancialLoan, FinancialLoanListViewModel>()
                .ForMember(m => m.FinancialAmounts, m => m.MapFrom(o => o.FinancialItem.Sum(t => t.financialAmount)))
                .ForMember(m => m.NewProduceCode, m => m.MapFrom(o => o.NewProduce.Code))
                .ForMember(m => m.NewProduceTimeLimit, m => m.MapFrom(o => o.NewProduce.TimeLimit));

            CreateMap<FinancialLoan, FinancialLoanViewModel>()
                .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem.OrderBy(t => t.Name)));
        }
    }
}
