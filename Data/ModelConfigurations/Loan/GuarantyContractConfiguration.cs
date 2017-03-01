namespace Data.ModelConfigurations.Loan
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyContractConfiguration : EntityTypeConfiguration<GuarantyContract>
    {
        public GuarantyContractConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.ContractNumber).IsOptional().HasMaxLength(20);
            Property(m => m.SigningDate).IsOptional();
            Property(m => m.GuaranteeForm).IsOptional();
            Property(m => m.EffectiveState).IsOptional();
            HasOptional(m => m.Guarantor).WithOptionalPrincipal().Map(m => m.MapKey("GuarantyContractId")).WillCascadeOnDelete(false);

            Map<GuarantyContract>(m => m.Requires("Type").HasValue("GuarantyContract"))
                .Map<GuarantyContractMortgage>(t => t.Requires("Type").HasValue("MortgageGuarantyContract"))
                .Map<GuarantyContractPledge>(t => t.Requires("Type").HasValue("PledgeGuarantyContract"));

            ToTable("LOAN_GuarantyContract");
        }
    }
}
