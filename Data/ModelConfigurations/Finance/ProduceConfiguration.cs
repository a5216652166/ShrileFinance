﻿namespace Data.ModelConfigurations.Finance
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class ProduceConfiguration : EntityTypeConfiguration<NewProduce>
    {
        public ProduceConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.ProduceType).IsRequired();
            Property(m => m.Code).IsRequired();
            Property(m => m.TimeLimit).IsRequired();
            Property(m => m.Interval).IsRequired();
            Property(m => m.Poundage).IsRequired();
            Property(m => m.MarginRate).IsRequired();
            Property(m => m.MonthRate).IsRequired();
            Property(m => m.ChannelRate).IsRequired();
            Property(m => m.SalesmanRate).IsRequired();
            Property(m => m.InterestRate).IsRequired();
            Property(m => m.LeaseType).IsRequired();
            Property(m => m.RepayPrincipals).IsRequired();
            Property(m => m.CreatedDate).IsRequired();

            ToTable("FANC_Produce");
        }
    }
}