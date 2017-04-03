namespace Application.Mappings
{
    using AutoMapper;
    using Core.Produce;

    public class BindModelToProduceMappingProfile : Profile
    {
        public BindModelToProduceMappingProfile()
        {
            CreateMap<Application.Produce.ProduceViewModels.ProduceViewModel, Produce>();
        }
    }
}
