namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 诉讼
    /// </summary>
    public class LitigationConfigruation : EntityTypeConfiguration<Litigation>
    {
        public LitigationConfigruation() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.ChargedSerialNumber).IsRequired().HasMaxLength(60);
            Property(m => m.DateTime).IsRequired();
            Property(m => m.Money).IsRequired().HasPrecision(18, 2);
            Property(m => m.ProsecuteName).IsRequired().HasMaxLength(80);
            Property(m => m.Reason).IsRequired().HasMaxLength(300);
            Property(m => m.Result).IsRequired().HasMaxLength(100);

            ToTable("CUST_Litigation");
        }
    }
}
