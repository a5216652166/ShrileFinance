﻿namespace Data.ModelConfigurations.Finance.Financial
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Financial;

    public class FinancialItemConfiguration : EntityTypeConfiguration<FinancialItem>
    {
        public FinancialItemConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).HasMaxLength(200).IsRequired();
            Property(m => m.Principal).IsOptional();
            Property(m => m.Rate).IsOptional();
            Property(m => m.VATamount).IsOptional();
            Property(m => m.InvoiceAmount).IsOptional();
            Property(m => m.FinancialAmount).IsRequired();

            ToTable("FANC_FinancialItem");
        }
    }
}
