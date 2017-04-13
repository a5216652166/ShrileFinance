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

            Ignore(m => m.Name);
            Property(m => m.OldName).IsRequired().HasMaxLength(60); ;
            Ignore(m => m.Extension);
            Property(m => m.Path).IsRequired().HasMaxLength(100);
            Property(m => m.IsTemp).IsRequired();
            Property(m => m.DateOfCreate).IsRequired();
            Ignore(m => m.Stream);
            Property(m => m.ReferenceId).IsRequired();
            Property(m => m.ReferencedSid).IsRequired();
            Property(m=>m.TableName).IsRequired();

            ToTable("SYS_FileSystem");
        }
    }
}
