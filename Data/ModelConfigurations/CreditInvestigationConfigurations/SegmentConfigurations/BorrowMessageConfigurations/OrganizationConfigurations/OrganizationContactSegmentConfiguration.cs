namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.OrganizationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    /// <summary>
    /// 联络
    /// </summary>
    public class OrganizationContactSegmentConfiguration : EntityTypeConfiguration<OrganizationContactSegment>
    {
        public OrganizationContactSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 联络
            Property(m => m.OfficeAddress).HasMaxLength(80);
            Property(m => m.ContactPhone).HasMaxLength(35);
            Property(m => m.FinancialContactPhone).HasMaxLength(35);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CIDG_OrganizationContactSegment");
        }
    }
}
