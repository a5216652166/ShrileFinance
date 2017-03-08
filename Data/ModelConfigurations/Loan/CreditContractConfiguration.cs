namespace Data.ModelConfigurations.Loan
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class CreditContractConfiguration : EntityTypeConfiguration<CreditContract>
    {
        public CreditContractConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.CreditContractCode).HasMaxLength(60);
            Property(m => m.EffectiveDate);
            Property(m => m.ExpirationDate);
            Property(m => m.CreditLimit);
            Property(m => m.EffectiveStatus);

            HasMany(m => m.GuarantyContract).WithOptional()
                .Map(m => m.MapKey("CreditId")).WillCascadeOnDelete();
            HasMany(m => m.Loans).WithOptional()
                .HasForeignKey(m => m.CreditId).WillCascadeOnDelete();

            ToTable("LOAN_CreditContranct");
        }
    }
}
