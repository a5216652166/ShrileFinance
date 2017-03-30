namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.FinancialAffairConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;

    public class BaseParagraphConfiguration : EntityTypeConfiguration<BaseParagraph>
    {
        public BaseParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.信息记录长度).HasMaxLength(4);
            Property(m => m.信息记录类型).HasMaxLength(2);
            Property(m => m.借款人名称).HasMaxLength(80);
            Property(m => m.贷款卡编号).HasMaxLength(16);
            Property(m => m.报表年份).HasMaxLength(4);
            Property(m => m.报表类型).HasMaxLength(2);
            Property(m => m.报表类型细分).HasMaxLength(1);
            Property(m => m.审计事务所名称).HasMaxLength(80);
            Property(m => m.审计人员名称).HasMaxLength(30);
            Property(m => m.审计时间).HasMaxLength(8);
            Property(m => m.信息记录操作类型).HasMaxLength(1);
            Property(m => m.业务发生日期).HasMaxLength(8);

            ToTable("CIDG_BaseParagraph");
        }
    }
}
