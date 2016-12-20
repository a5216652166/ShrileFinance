namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;
    using Core.Entities.Loan;

    public class DomainToCreditInvestigationProfile : Profile
    {
        public DomainToCreditInvestigationProfile()
        {
            CreateMap<CreditBaseSegment, CreditContract>();
            CreateMap<CreditContractSegment, CreditContract>();
            CreateMap<CreditContractAmountSegment, CreditContract>();
        }
    }
}
