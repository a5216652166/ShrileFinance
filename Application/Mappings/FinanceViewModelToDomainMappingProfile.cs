namespace Application.Mappings
{
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using AutoMapper;
    using Core.Entities.Finance;

    public class FinanceViewModelToDomainMappingProfile : Profile
    {
        public FinanceViewModelToDomainMappingProfile()
        {
            CreateMap<NewProduceViewModel, NewProduce>();
        }
    }
}
