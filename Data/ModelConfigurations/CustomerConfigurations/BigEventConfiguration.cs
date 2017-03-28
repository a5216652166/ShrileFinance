namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 大事件
    /// </summary>
    public class BigEventConfiguration : EntityTypeConfiguration<BigEvent>
    {
        public BigEventConfiguration() : base()
        {
            Property(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.BigEventDescription).IsRequired().HasMaxLength(60);
            Property(m => m.BigEventDescription).IsRequired().HasMaxLength(250);

            ToTable("CUST_BigEvent");
        }
    }
}
