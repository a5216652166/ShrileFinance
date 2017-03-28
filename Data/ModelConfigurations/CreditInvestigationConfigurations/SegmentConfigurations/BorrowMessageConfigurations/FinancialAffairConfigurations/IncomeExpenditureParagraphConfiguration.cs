namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.FinancialAffairConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;

    public class IncomeExpenditureParagraphConfiguration : EntityTypeConfiguration<IncomeExpenditureParagraph>
    {
        public IncomeExpenditureParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.财政补助收入).HasMaxLength(20);
            Property(m => m.上级补助收入).HasMaxLength(20);
            Property(m => m.附属单位缴款).HasMaxLength(20);
            Property(m => m.事业收入).HasMaxLength(20);
            Property(m => m.预算外资金收入).HasMaxLength(20);
            Property(m => m.其他收入).HasMaxLength(20);
            Property(m => m.事业收入小计).HasMaxLength(20);
            Property(m => m.经营收入).HasMaxLength(20);
            Property(m => m.经营收入小计).HasMaxLength(20);
            Property(m => m.拨入专款).HasMaxLength(20);
            Property(m => m.拨入专款小计).HasMaxLength(20);
            Property(m => m.收入总计).HasMaxLength(20);
            Property(m => m.拨出经费).HasMaxLength(20);
            Property(m => m.上缴上级支出).HasMaxLength(20);
            Property(m => m.对附属单位补助).HasMaxLength(20);
            Property(m => m.事业支出).HasMaxLength(20);
            Property(m => m.财政补助支出).HasMaxLength(20);
            Property(m => m.预算外资金支出).HasMaxLength(20);
            Property(m => m.销售税金).HasMaxLength(20);
            Property(m => m.结转自筹基建).HasMaxLength(20);
            Property(m => m.事业支出小计).HasMaxLength(20);
            Property(m => m.经营支出).HasMaxLength(20);
            Property(m => m.销售税金1).HasMaxLength(20);
            Property(m => m.经营支出小计).HasMaxLength(20);
            Property(m => m.拨出专款).HasMaxLength(20);
            Property(m => m.专款支出).HasMaxLength(20);
            Property(m => m.专款小计).HasMaxLength(20);
            Property(m => m.支出总计).HasMaxLength(20);
            Property(m => m.事业结余).HasMaxLength(20);
            Property(m => m.正常收入结余).HasMaxLength(20);
            Property(m => m.收回以前年度事业支出).HasMaxLength(20);
            Property(m => m.经营结余).HasMaxLength(20);
            Property(m => m.以前年度经营亏损).HasMaxLength(20);
            Property(m => m.结余分配).HasMaxLength(20);
            Property(m => m.应交所得税).HasMaxLength(20);
            Property(m => m.提取专用基金).HasMaxLength(20);
            Property(m => m.转入事业基金).HasMaxLength(20);
            Property(m => m.其他结余分配).HasMaxLength(20);

            ToTable("CIDG_IncomeExpenditureParagraph");
        }
    }
}
