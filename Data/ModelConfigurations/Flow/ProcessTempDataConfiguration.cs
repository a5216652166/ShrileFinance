﻿namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities;

    public class ProcessTempDataConfiguration : EntityTypeConfiguration<ProcessTempData>
    {
        public ProcessTempDataConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.InstanceId).IsRequired();

            Property(m => m.JsonData).IsRequired().HasMaxLength(400);

            HasRequired(m => m.Instance);

            ToTable("Process_ProcessTempData");
        }
    }
}