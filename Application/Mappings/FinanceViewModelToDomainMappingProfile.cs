namespace Application.Mappings
{
    using Application.ViewModels.FinanceViewModels;
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
