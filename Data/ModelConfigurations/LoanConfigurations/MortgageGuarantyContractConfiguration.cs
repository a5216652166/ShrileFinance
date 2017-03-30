namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class MortgageGuarantyContractConfiguration : EntityTypeConfiguration<GuarantyContractMortgage>
    {
        public MortgageGuarantyContractConfiguration()
        {
            Property(m => m.MortgageNumber).IsRequired().HasMaxLength(2);
            Property(m => m.AssessmentValue).IsOptional();
            Property(m => m.AssessmentDate).IsOptional();
            Property(m => m.AssessmentName).IsOptional().HasMaxLength(80);
            Property(m => m.AssessmentOrganizationCode).IsOptional().HasMaxLength(10);
            Property(m => m.CollateralType).IsOptional();
            Property(m => m.RegistrateAuthorit).IsRequired().HasMaxLength(80);
            Property(m => m.RegistrateDate).IsOptional();
            Property(m => m.CollateralInstruction).IsRequired().HasMaxLength(400);
        }
    }
}
