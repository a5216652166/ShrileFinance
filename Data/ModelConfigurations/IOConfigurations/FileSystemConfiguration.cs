namespace Data.ModelConfigurations.IOConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.IO;

    public class FileSystemConfiguration : EntityTypeConfiguration<FileSystem>
    {
        public FileSystemConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(36);
            Property(m => m.OldName).IsRequired().HasMaxLength(100);
            Property(m => m.Extension).IsRequired().HasMaxLength(20);
            Property(m => m.Path).IsRequired().HasMaxLength(200);
            Property(m => m.IsTemp).IsRequired();
            Ignore(m => m.Stream);

            ToTable("SYS_FileSystem");
        }
    }
}
