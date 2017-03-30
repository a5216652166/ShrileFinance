namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 事业单位资产负债
    /// </summary>
    public class InstitutionLiabilitiesConfiguration : EntityTypeConfiguration<InstitutionLiabilities>
    {
        public InstitutionLiabilitiesConfiguration() : base()
        {
            Property(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).IsRequired();
            Property(m => m.一般基金).HasPrecision(18, 2);
            Property(m => m.上级补助收入).HasPrecision(18, 2);
            Property(m => m.上缴上级支出).HasPrecision(18, 2);
            Property(m => m.专款支出).HasPrecision(18, 2);
            Property(m => m.专用基金).HasPrecision(18, 2);
            Property(m => m.事业基金).HasPrecision(18, 2);
            Property(m => m.事业支出).HasPrecision(18, 2);
            Property(m => m.事业收入).HasPrecision(18, 2);
            Property(m => m.事业结余).HasPrecision(18, 2);
            Property(m => m.产成品).HasPrecision(18, 2);
            Property(m => m.借记款项).HasPrecision(18, 2);
            Property(m => m.其他应付款).HasPrecision(18, 2);
            Property(m => m.其他应收款).HasPrecision(18, 2);
            Property(m => m.其他收入).HasPrecision(18, 2);
            Property(m => m.净资产合计).HasPrecision(18, 2);
            Property(m => m.固定基金).HasPrecision(18, 2);
            Property(m => m.固定资产).HasPrecision(18, 2);
            Property(m => m.对外投资).HasPrecision(18, 2);
            Property(m => m.对附属单位补助).HasPrecision(18, 2);
            Property(m => m.应交税金).HasPrecision(18, 2);
            Property(m => m.应付票据).HasPrecision(18, 2);
            Property(m => m.应付账款).HasPrecision(18, 2);
            Property(m => m.应收票据).HasPrecision(18, 2);
            Property(m => m.应收账款).HasPrecision(18, 2);
            Property(m => m.应缴财政专户款).HasPrecision(18, 2);
            Property(m => m.应缴预算款).HasPrecision(18, 2);
            Property(m => m.成本费用).HasPrecision(18, 2);
            Property(m => m.投资基金).HasPrecision(18, 2);
            Property(m => m.拨入专款).HasPrecision(18, 2);
            Property(m => m.拨出专款).HasPrecision(18, 2);
            Property(m => m.拨出经费).HasPrecision(18, 2);
            Property(m => m.支出合计).HasPrecision(18, 2);
            Property(m => m.收入合计).HasPrecision(18, 2);
            Property(m => m.无形资产).HasPrecision(18, 2);
            Property(m => m.材料).HasPrecision(18, 2);
            Property(m => m.现金).HasPrecision(18, 2);
            Property(m => m.经营支出).HasPrecision(18, 2);
            Property(m => m.经营收入).HasPrecision(18, 2);
            Property(m => m.经营结余).HasPrecision(18, 2);
            Property(m => m.结转自筹基建).HasPrecision(18, 2);
            Property(m => m.负债合计).HasPrecision(18, 2);
            Property(m => m.负债部类总计).HasPrecision(18, 2);
            Property(m => m.财政补助收入).HasPrecision(18, 2);
            Property(m => m.资产合计).HasPrecision(18, 2);
            Property(m => m.资产部类总计).HasPrecision(18, 2);
            Property(m => m.银行存款).HasPrecision(18, 2);
            Property(m => m.销售税金).HasPrecision(18, 2);
            Property(m => m.附属单位缴款).HasPrecision(18, 2);
            Property(m => m.预付账款).HasPrecision(18, 2);
            Property(m => m.预收账款).HasPrecision(18, 2);

            ToTable("CUST_InstitutionLiabilities");
        }
    }
}
