namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    /// <summary>
    /// 高管
    /// </summary>
    public class ManagerSegmentConfiguration : EntityTypeConfiguration<ManagerSegment>
    {
        public ManagerSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 高管
            Property(m => m.Type).HasMaxLength(2);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CertificateType).HasMaxLength(2);
            Property(m => m.CertificateCode).HasMaxLength(20);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CUST_ManagerSegment");
        }
    }
}
