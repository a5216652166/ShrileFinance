namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.OrganizationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    /// <summary>
    /// 状态
    /// </summary>
    public class OrganizationStateSegmentConfiguration : EntityTypeConfiguration<OrganizationStateSegment>
    {
        public OrganizationStateSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 状态
            Property(m => m.EnterpriseScale).HasMaxLength(1);
            Property(m => m.InstitutionsState).HasMaxLength(1);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CIDG_OrganizationStateSegment");
        }
    }
}
