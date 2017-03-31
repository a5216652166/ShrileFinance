namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 事业单位收入支出
    /// </summary>
    public class InstitutionIncomeExpenditureConfiguration : EntityTypeConfiguration<InstitutionIncomeExpenditure>
    {
        public InstitutionIncomeExpenditureConfiguration() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).IsRequired();
            Property(m => m.上级补助收入).HasPrecision(18, 2);
            Property(m => m.上缴上级支出).HasPrecision(18, 2);
            Property(m => m.专款小计).HasPrecision(18, 2);
            Property(m => m.专款支出).HasPrecision(18, 2);
            Property(m => m.事业支出).HasPrecision(18, 2);
            Property(m => m.事业支出小计).HasPrecision(18, 2);
            Property(m => m.事业收入).HasPrecision(18, 2);
            Property(m => m.事业收入小计).HasPrecision(18, 2);
            Property(m => m.事业结余).IsRequired().HasPrecision(18, 2);
            Property(m => m.以前年度经营亏损).HasPrecision(18, 2);
            Property(m => m.其他收入).HasPrecision(18, 2);
            Property(m => m.其他结余分配).HasPrecision(18, 2);
            Property(m => m.对附属单位补助).HasPrecision(18, 2);
            Property(m => m.应交所得税).HasPrecision(18, 2);
            Property(m => m.拨入专款).HasPrecision(18, 2);
            Property(m => m.拨入专款小计).HasPrecision(18, 2);
            Property(m => m.拨出专款).HasPrecision(18, 2);
            Property(m => m.拨出经费).HasPrecision(18, 2);
            Property(m => m.提取专用基金).HasPrecision(18, 2);
            Property(m => m.支出总计).HasPrecision(18, 2);
            Property(m => m.收入总计).HasPrecision(18, 2);
            Property(m => m.收回以前年度事业支出).HasPrecision(18, 2);
            Property(m => m.正常收入结余).HasPrecision(18, 2);
            Property(m => m.经营支出).HasPrecision(18, 2);
            Property(m => m.经营支出小计).HasPrecision(18, 2);
            Property(m => m.经营收入).HasPrecision(18, 2);
            Property(m => m.经营收入小计).HasPrecision(18, 2);
            Property(m => m.经营结余).IsRequired().HasPrecision(18, 2);
            Property(m => m.结余分配).HasPrecision(18, 2);
            Property(m => m.结转自筹基建).HasPrecision(18, 2);
            Property(m => m.财政补助支出).HasPrecision(18, 2);
            Property(m => m.财政补助收入).HasPrecision(18, 2);
            Property(m => m.转入事业基金).HasPrecision(18, 2);
            Property(m => m.销售税金).HasPrecision(18, 2);
            Property(m => m.销售税金1).HasPrecision(18, 2);
            Property(m => m.附属单位缴款).HasPrecision(18, 2);
            Property(m => m.预算外资金支出).HasPrecision(18, 2);
            Property(m => m.预算外资金收入).HasPrecision(18, 2);

            ToTable("CIOG_InstitutionIncome");
        }
    }
}
