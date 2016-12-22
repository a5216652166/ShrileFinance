using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    public class InstitutionLiabilitiesParagraphConfiguration : EntityTypeConfiguration<InstitutionLiabilitiesParagraph>
    {
        public InstitutionLiabilitiesParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).HasMaxLength(1);
            Property(m => m.现金).HasMaxLength(20);
            Property(m => m.银行存款).HasMaxLength(20);
            Property(m => m.应收票据).HasMaxLength(20);
            Property(m => m.应收账款).HasMaxLength(20);
            Property(m => m.预付账款).HasMaxLength(20);
            Property(m => m.其他应收款).HasMaxLength(20);
            Property(m => m.材料).HasMaxLength(20);
            Property(m => m.产成品).HasMaxLength(20);
            Property(m => m.对外投资).HasMaxLength(20);
            Property(m => m.固定资产).HasMaxLength(20);
            Property(m => m.无形资产).HasMaxLength(20);
            Property(m => m.资产合计).HasMaxLength(20);
            Property(m => m.拨出经费).HasMaxLength(20);
            Property(m => m.拨出专款).HasMaxLength(20);
            Property(m => m.专款支出).HasMaxLength(20);
            Property(m => m.事业支出).HasMaxLength(20);
            Property(m => m.经营支出).HasMaxLength(20);
            Property(m => m.成本费用).HasMaxLength(20);
            Property(m => m.销售税金).HasMaxLength(20);
            Property(m => m.上缴上级支出).HasMaxLength(20);
            Property(m => m.对附属单位补助).HasMaxLength(20);
            Property(m => m.结转自筹基建).HasMaxLength(20);
            Property(m => m.支出合计).HasMaxLength(20);
            Property(m => m.资产部类总计).HasMaxLength(20);
            Property(m => m.借记款项).HasMaxLength(20);
            Property(m => m.应付票据).HasMaxLength(20);
            Property(m => m.应付账款).HasMaxLength(20);
            Property(m => m.预收账款).HasMaxLength(20);
            Property(m => m.其他应付款).HasMaxLength(20);
            Property(m => m.应缴预算款).HasMaxLength(20);
            Property(m => m.应缴财政专户款).HasMaxLength(20);
            Property(m => m.应交税金).HasMaxLength(20);
            Property(m => m.负债合计).HasMaxLength(20);
            Property(m => m.事业基金).HasMaxLength(20);
            Property(m => m.一般基金).HasMaxLength(20);
            Property(m => m.投资基金).HasMaxLength(20);
            Property(m => m.固定基金).HasMaxLength(20);
            Property(m => m.专用基金).HasMaxLength(20);
            Property(m => m.事业结余).HasMaxLength(20);
            Property(m => m.经营结余).HasMaxLength(20);
            Property(m => m.净资产合计).HasMaxLength(20);
            Property(m => m.财政补助收入).HasMaxLength(20);
            Property(m => m.上级补助收入).HasMaxLength(20);
            Property(m => m.拨入专款).HasMaxLength(20);
            Property(m => m.事业收入).HasMaxLength(20);
            Property(m => m.经营收入).HasMaxLength(20);
            Property(m => m.附属单位缴款).HasMaxLength(20);
            Property(m => m.其他收入).HasMaxLength(20);
            Property(m => m.收入合计).HasMaxLength(20);
            Property(m => m.负债部类总计).HasMaxLength(20);

            ToTable("CIDG_InstitutionLiabilitiesParagraph");
        }
    }
}
