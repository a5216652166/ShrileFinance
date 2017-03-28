namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class PledgeGuarantyContractConfiguration : EntityTypeConfiguration<GuarantyContractPledge>
    {
        public PledgeGuarantyContractConfiguration()
        {
            Property(m => m.PledgeNumber).IsRequired().HasMaxLength(2);
            Property(m => m.CollateralValue).IsOptional();
            Property(m => m.PledgeType).IsOptional();
        }
    }
}
