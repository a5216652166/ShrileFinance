﻿namespace Data.ModelConfigurations.CreditInvestigation
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation;

    public class TraceConfiguration : EntityTypeConfiguration<Trace>
    {
        public TraceConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.TraceDate);
            Property(m => m.ReferenceId);
            Property(m => m.Type);
            Property(m => m.Name).HasMaxLength(20);
            Property(m => m.Status);
            Property(m => m.SerialNumber);
            Property(m => m.DatagramFileId);

           // HasOptional(m => m.DatagramFile);

            ToTable("CIDG_Trace");
        }
    }
}