namespace Application.Mappings
{
    using System;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using ViewModels.FinanceViewModels.PartnerViewModels;

    public class FinanceViewModelToDomainMappingProfile : Profile
    {
        public FinanceViewModelToDomainMappingProfile()
        {
            CreateMap<NewProduceViewModel, NewProduce>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
                .ForMember(m => m.CreatedDate, o => o.Ignore());

            CreateMap<FinancialItemViewModel, FinancialItem>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)));

            CreateMap<FinancialLoanViewModel, FinancialLoan>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
                .ForMember(m => m.NewProduce, o => o.Ignore())
                .ForMember(m => m.CreatedDate, o => o.Ignore())
                .ForMember(m => m.FinancialItem, o => o.Ignore());

            CreateMap<PartnerUserViewModel, PartnerUser>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
                .ForMember(m => m.CreatedDate, m => m.Ignore())
                .ForMember(m => m.AppUser, m => m.Ignore());

            CreateMap<PartnerViewModel, NewPartner>()
               .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
               .ForMember(m => m.CreatedDate, m => m.Ignore())
               .ForMember(m => m.PartnerUsers, m => m.Ignore())
               .ForMember(m => m.Produces, m => m.Ignore());
        }

        private Guid AllowId(Guid? id)
        {
            if (id.HasValue && id != Guid.Empty)
            {
                return id.Value;
            }
            else
            {
                return Guid.NewGuid();
            }
        }
    }
}
