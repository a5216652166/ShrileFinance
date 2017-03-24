namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    /// <summary>
    /// 合同
    /// </summary>
    public class ContactConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContactConfiguration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Number).HasMaxLength(100);

            Property(m => m.Date);
            Property(m => m.Name).HasMaxLength(100);
            Property(m => m.Path).HasMaxLength(200);

            ToTable("FANC_Contact");
        }
    }
}
