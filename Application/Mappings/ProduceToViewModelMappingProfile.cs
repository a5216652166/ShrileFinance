namespace Application.Mappings
{
    using System;
    using AutoMapper;
    using Core.Produce;

    public class ProduceToViewModelMappingProfile : Profile
    {
        public ProduceToViewModelMappingProfile()
        {
            CreateMap<Produce, Application.Produce.ProduceViewModels.ProduceViewModel>()
                .ForMember(d => d.Rate, opt => opt.MapFrom(s => s.Rate * 100))
                .ForMember(d => d.CustomerCostRatio, opt => opt.MapFrom(s => s.CustomerCostRatio * 100))
                .ForMember(d => d.CustomerBailRatio, opt => opt.MapFrom(s => s.CustomerBailRatio * 100))
                .ForMember(d => d.CostRate, opt => opt.MapFrom(s => s.CostRate * 100))
                .ForMember(d => d.PartnersCommissionRatio, opt => opt.MapFrom(s => s.PartnersCommissionRatio * 100))
                .ForMember(d => d.EmployeeCommissionRatio, opt => opt.MapFrom(s => s.EmployeeCommissionRatio * 100));

            CreateMap<PrincipalRatio, Application.Produce.ProduceViewModels.PrincipalRatioViewModel>()
                .ForMember(d => d.Ratio, opt => opt.MapFrom(s => s.Ratio * 100))
                .ForMember(d => d.Factor, opt => opt.MapFrom(s => Math.Round(s.Factor)));
        }
    }
}
