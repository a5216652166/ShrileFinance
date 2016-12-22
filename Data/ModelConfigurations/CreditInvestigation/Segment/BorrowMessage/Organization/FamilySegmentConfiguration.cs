namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    public class FamilySegmentConfiguration : EntityTypeConfiguration<FamilySegment>
    {
        public FamilySegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 家族
            Property(m => m.MianName).HasMaxLength(80);
            Property(m => m.MainType).HasMaxLength(2);
            Property(m => m.MainCode).HasMaxLength(20);
            Property(m => m.Relationship).HasMaxLength(1);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CertificateType).HasMaxLength(2);
            Property(m => m.CertificateCode).HasMaxLength(20);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CIDG_FamilySegment");
        }
    }
}
