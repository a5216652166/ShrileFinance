namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.OrganizationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    public class AssociatedEnterpriseSegmentConfiguration : EntityTypeConfiguration<AssociatedEnterpriseSegment>
    {
        public AssociatedEnterpriseSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.AssociatedType).HasMaxLength(2);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CIDG_AssociatedEnterpriseSegment");
        }
    }
}
