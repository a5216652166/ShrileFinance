namespace Application.Mappings
{
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using AutoMapper;
    using Core.Entities.Finance.Financial;

    public class FinanceViewModelToDomainMappingProfile : Profile
    {
        public FinanceViewModelToDomainMappingProfile()
        {
            CreateMap<NewProduceViewModel, NewProduce>()
                .ForMember(m => m.CreatedDate, o => o.Ignore());

            CreateMap<FinancialItemViewModel, FinancialItem>()
                .ForMember(m => m.Id, o => o.Ignore());

            CreateMap<FinancialLoanViewModel, FinancialLoan>()
                .ForMember(m => m.Id, o => o.Ignore())
                .ForMember(m => m.NewProduce, o => o.Ignore())
                .ForMember(m => m.CreatedDate, o => o.Ignore())
                .ForMember(m => m.FinancialItem, m => m.MapFrom(o => o.FinancialItem));
        }
    }
}
