namespace Application.Mappings
{
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using Core.Produce;

    public class BindModelToProduceMappingProfile : Profile
    {
        public BindModelToProduceMappingProfile()
        {
            CreateMap<Application.Produce.ProduceViewModels.ProduceBindModel, Produce>()
                .ForMember(d => d.Rate, opt => opt.MapFrom(s => s.Rate / 100))
                .ForMember(d => d.CustomerCostRatio, opt => opt.MapFrom(s => s.CustomerCostRatio / 100))
                .ForMember(d => d.CustomerBailRatio, opt => opt.MapFrom(s => s.CustomerBailRatio / 100))
                .ForMember(d => d.CostRate, opt => opt.MapFrom(s => s.CostRate / 100))
                .ForMember(d => d.PartnersCommissionRatio, opt => opt.MapFrom(s => s.PartnersCommissionRatio / 100))
                .ForMember(d => d.EmployeeCommissionRatio, opt => opt.MapFrom(s => s.EmployeeCommissionRatio / 100));

            CreateMap<Application.Produce.ProduceViewModels.PrincipalRatioViewModel, PrincipalRatio>()
                .ForMember(d => d.Ratio, opt => opt.MapFrom(s => s.Ratio / 100))
                .EqualityComparison((m, e) => m.Period == e.Period);
        }
    }
}
