namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    /// <summary>
    /// 上级机构
    /// </summary>
    public class ParentSegmentConfiguration : EntityTypeConfiguration<ParentSegment>
    {
        public ParentSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 上级机构
            Property(m => m.SuperInstitutionsName).HasMaxLength(80);
            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CUST_ParentSegment");
        }
    }
}
