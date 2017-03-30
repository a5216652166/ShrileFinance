namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.OrganizationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization;

    public class BaseSegmentConfiguration : EntityTypeConfiguration<BaseSegment>
    {
        public BaseSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 机构
            Property(m => m.CustomerNumber).HasMaxLength(40);
            Property(m => m.ManagementerCode).HasMaxLength(20);
            Property(m => m.CustomerType).HasMaxLength(1);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.TaxpayerIdentifyIrsNumber).HasMaxLength(20);
            Property(m => m.TaxpayerIdentifyLandNumber).HasMaxLength(20);
            Property(m => m.LoanCardCode).HasMaxLength(16);
            Property(m => m.数据提取日期).HasMaxLength(8);

            ToTable("CIDG_BaseSegment");
        }
    }
}
