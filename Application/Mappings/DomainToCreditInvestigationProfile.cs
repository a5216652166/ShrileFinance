namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Loan;

    public class DomainToCreditInvestigationProfile : Profile
    {
        public DomainToCreditInvestigationProfile()
        {
            //// 关注
            CreateMap<BigEvent, BigEventSegment>();
            CreateMap<Litigation, LitigationSegment>();
            //// 机构
            CreateMap<AssociatedEnterprise, AssociatedEnterpriseSegment>();
            CreateMap<Organization, BaseSegment>();
            CreateMap<FamilyMember, FamilySegment>();
            CreateMap<Manager, ManagerSegment>();
            CreateMap<OrganizationContact, OrganizationContactSegment>();
            CreateMap<OrganizationState, OrganizationStateSegment>();
            CreateMap<OrganizationParent, ParentSegment>();
            CreateMap<OrganizationProperties, PropertySegment>();
            CreateMap<Stockholder, StockholderSegment>();
            ////贷款和担保
            CreateMap<CreditContract, CreditContractSegment>();
            CreateMap<CreditContract, CreditContractAmountSegment>();
            CreateMap<Loan, LoanSegment>();
            CreateMap<PaymentHistory, RepaymentSegment>();
            CreateMap<Guarantor, GuaranteeSegment>();
            CreateMap<GuarantyContract, GuaranteeSegment>();
            CreateMap<Guarantor, GuaranteeMortgageSegment>();
            CreateMap<GuarantyContractMortgage, GuaranteeMortgageSegment>();
            CreateMap<Guarantor, GuaranteePledgeSegment>();
            CreateMap<GuarantyContractPledge, GuaranteePledgeSegment>();
            CreateMap<GuarantorPerson, NaturalGuaranteeSegment>();
            CreateMap<GuarantyContract, NaturalGuaranteeSegment>();
            CreateMap<GuarantorPerson, NaturalMortgageSegment>();
            CreateMap<GuarantyContractMortgage, NaturalMortgageSegment>();
            CreateMap<GuarantorPerson, NaturalPledgeSegment>();
            CreateMap<GuarantyContractPledge, NaturalPledgeSegment>();
        }
    }
}
