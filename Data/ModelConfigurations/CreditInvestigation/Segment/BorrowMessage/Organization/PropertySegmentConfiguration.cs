namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    /// <summary>
    /// 基础信息
    /// </summary>
    public class PropertySegmentConfiguration : EntityTypeConfiguration<PropertySegment>
    {
        public PropertySegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 基础信息
            Property(m => m.InstitutionChName).HasMaxLength(80);
            Property(m => m.RegisterAddress).HasMaxLength(80);
            Property(m => m.RegisterAdministrativeDivision).HasMaxLength(6);
            Property(m => m.SetupDate).HasMaxLength(8);
            Property(m => m.CertificateDueDate).HasMaxLength(8);
            Property(m => m.BusinessScope).HasMaxLength(400);
            Property(m => m.RegisterCapital).HasMaxLength(10);
            Property(m => m.OrganizationCategory).HasMaxLength(1);
            Property(m => m.OrganizationCategorySubdivision).HasMaxLength(2);
            Property(m => m.EconomicSectorsClassification).HasMaxLength(5);
            Property(m => m.EconomicType).HasMaxLength(2);
            Property(m => m.信息更新日期).HasMaxLength(8);

            ToTable("CUST_PropertySegment");
        }
    }
}
