namespace Application.Mappings
{
    using System;
    using Application.ViewModels.FinanceViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels.ProduceViewModels;
    using AutoMapper;
    using Core.Entities.Finance;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;

    public class FinanceViewModelToDomainMappingProfile : Profile
    {
        public FinanceViewModelToDomainMappingProfile()
        {
            CreateMap<FinanceApplyViewModel, Finance>()
                .ForMember(m => m.Contact, m => m.Ignore())
                .ForMember(m => m.Applicant, m => m.Ignore())
                .ForMember(m => m.FinancialItem, m => m.Ignore())
                .ForMember(m => m.CreateBy, m => m.Ignore())
                .ForMember(m => m.CreateOf, m => m.Ignore())
                .ForMember(m => m.Produce, m => m.Ignore());

            CreateMap<ProduceViewModel, Produce>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
                .ForMember(m => m.CreatedDate, o => o.Ignore());

            CreateMap<FinancialItemViewModel, FinancialItem>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)));

            CreateMap<FinancialLoanViewModel, FinancialLoan>()
                .ForMember(m => m.Id, m => m.MapFrom(o => AllowId(o.Id)))
                .ForMember(m => m.Produce, o => o.Ignore())
                .ForMember(m => m.CreatedDate, o => o.Ignore())
                .ForMember(m => m.FinancialItem, o => o.Ignore());
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
