namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.Finance;
    using ViewModels.FinanceViewModels;

    public class FinanceDomainToCreditInvestigationProfile : Profile
    {
        public FinanceDomainToCreditInvestigationProfile()
        {
            CreateMap<NewProduce, NewProduceViewModel>();
            CreateMap<NewProduce, NewProduceListViewModel>();
        }
    }
}
