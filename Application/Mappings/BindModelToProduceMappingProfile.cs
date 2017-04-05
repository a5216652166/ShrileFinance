namespace Application.Mappings
{
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using Core.Produce;

    public class BindModelToProduceMappingProfile : Profile
    {
        public BindModelToProduceMappingProfile()
        {
            CreateMap<Application.Produce.ProduceViewModels.ProduceBindModel, Produce>();
            CreateMap<Application.Produce.ProduceViewModels.PrincipalRatioViewModel, PrincipalRatio>()
                .EqualityComparison((m, e) => m.Period == e.Period);
        }
    }
}
