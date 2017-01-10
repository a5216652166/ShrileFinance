namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.Loan;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.Loan.LoanViewModels;

    public class LoanViewModelToDomianProfile : Profile
    {
        public LoanViewModelToDomianProfile()
        {
            CreateMap<LoanViewModel, Loan>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PaymentHistoryViewModel, PaymentHistory>()
                .ForMember(m => m.Hidden, o => o.Ignore());
            ////.IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<CreditContractViewModel, CreditContract>()
                .ForMember(d => d.GuarantyContract, o => o.Ignore());

            CreateMap<GuarantyContractViewModel, GuarantyContract>()
                .Include<GuarantyContractPledgeViewModel, GuarantyContractPledge>()
                .Include<GuarantyContractMortgageViewModel, GuarantyContractMortgage>()
                .ForMember(d => d.Guarantor, o => o.MapFrom(t => t.Guarantor))
                .ConstructUsing(m =>
                {
                    if (m is GuarantyContractPledgeViewModel)
                    {
                        return new GuarantyContractPledge();
                    }
                    else if (m is GuarantyContractMortgageViewModel)
                    {
                        return new GuarantyContractMortgage();
                    }
                    else
                    {
                        return new GuarantyContract();
                    }
                });
            CreateMap<GuarantyContractPledgeViewModel, GuarantyContractPledge>();
            CreateMap<GuarantyContractMortgageViewModel, GuarantyContractMortgage>();

            CreateMap<GuarantorViewModel, Guarantor>()
                .Include<GuarantyOrganizationViewModel, GuarantorOrganization>()
                .Include<GuarantyPersonViewModel, GuarantorPerson>()
                .ConstructUsing(m =>
                {
                    if (m is GuarantyOrganizationViewModel)
                    {
                        return new GuarantorOrganization();
                    }
                    else if (m is GuarantyPersonViewModel)
                    {
                        return new GuarantorPerson();
                    }
                    else
                    {
                        return null;
                    }
                });
            CreateMap<GuarantyOrganizationViewModel, GuarantorOrganization>();
            CreateMap<GuarantyPersonViewModel, GuarantorPerson>();
        }
    }
}
