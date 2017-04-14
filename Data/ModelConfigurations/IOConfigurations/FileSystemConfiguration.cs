namespace Data.ModelConfigurations.IOConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.IO;

    public class FileSystemConfiguration : EntityTypeConfiguration<FileSystem>
    {
        public FileSystemConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.OldName).HasColumnName("Name").IsRequired().HasMaxLength(200);
            Property(m => m.Path).IsRequired().HasMaxLength(400);
            Property(m => m.DateOfCreate).IsRequired();

            Property(m => m.ReferenceId).IsOptional();
            Property(m => m.ReferenceSid).IsOptional();
            Property(m => m.ReferenceType).IsOptional();

            Ignore(m => m.Name);
            Ignore(m => m.Extension);
            Ignore(m => m.Stream);
            Ignore(m => m.IsTemp);

            ToTable("SYS_File");
        }
    }
}
