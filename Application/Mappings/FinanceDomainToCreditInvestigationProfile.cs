namespace Application.Mappings
{
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using AutoMapper;
    using Core.Entities.Finance;
    using ViewModels.FinanceViewModels.ProduceViewModels;

    public class FinanceDomainToCreditInvestigationProfile : Profile
    {
        public FinanceDomainToCreditInvestigationProfile()
        {
            CreateMap<NewProduce, NewProduceViewModel>();
            CreateMap<NewProduce, NewProduceListViewModel>();

            CreateMap<FinancialItem, FinancialItemViewModel>();
            CreateMap<FinancialLoan, FinancialLoanListViewModel>()
                .ForMember(m => m.FinancialItemName, m => m.MapFrom(o => o.FinancialItem.Name))
                .ForMember(m => m.FinancialAmount, m => m.MapFrom(o => o.FinancialItem.financialAmount))
                .ForMember(m => m.NewProduceCode, m => m.MapFrom(o => o.NewProduce.Code))
                .ForMember(m => m.NewProduceTimeLimit, m => m.MapFrom(o => o.NewProduce.TimeLimit));

            CreateMap<FinancialLoan, FinancialLoanViewModel>()
                .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem));
        }
    }
}
