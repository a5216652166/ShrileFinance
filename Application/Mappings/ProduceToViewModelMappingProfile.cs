namespace Application.Mappings
{
    using AutoMapper;
    using Core.Produce;

    public class ProduceToViewModelMappingProfile : Profile
    {
        public ProduceToViewModelMappingProfile()
        {
            CreateMap<Produce, Application.Produce.ProduceViewModels.ProduceViewModel>();
            CreateMap<PrincipalRatio, Application.Produce.ProduceViewModels.PrincipalRatioViewModel>();
        }
    }
}
