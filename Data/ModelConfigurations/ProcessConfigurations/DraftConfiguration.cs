namespace Data.ModelConfigurations.ProcessConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Other;

    public class DraftConfiguration : EntityTypeConfiguration<Draft>
    {
        public DraftConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.PageLink).HasMaxLength(400);
            Property(m => m.PageData).HasMaxLength(null);
            Property(m => m.DateCreated);

            HasRequired(m => m.User).WithMany()
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete();

            ToTable("SYS_Draft");
        }
    }
}
