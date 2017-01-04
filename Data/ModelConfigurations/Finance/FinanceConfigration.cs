namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceConfigration : EntityTypeConfiguration<Finance>
    {
        public FinanceConfigration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Principal);
            Property(m => m.RepaymentDate);
            Property(m => m.RepaymentScheme);
            Property(m => m.Bail);
            Property(m => m.State);
            Property(m => m.OnePayInterest);
            Property(m => m.DateEffective);
            Property(m => m.DateCreated);
            Property(m => m.Financing);
            Property(m => m.Poundage);
            Property(m => m.OncePayMonths);
            Property(m => m.AdviceMoney);
            Property(m => m.AdviceRatio);
            Property(m => m.ApprovalMoney);
            Property(m => m.ApprovalRatio);
            Property(m => m.Payment);
            Property(m => m.RepayRentDate);

            // 信审报告
            HasOptional(m => m.CreditExamine).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 车辆信息
            HasOptional(m => m.Vehicle).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 融资中对应的产品融资项
            HasMany(m => m.FinanceProduce).WithOptional().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 联系人信息
            HasMany(m => m.Applicant).WithOptional().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 合同
            HasMany(m => m.Contact).WithOptional().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 融资扩展
            HasOptional(m => m.FinanceExtension).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ////合作商
           ////HasOptional(m => m.CreateOf).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ////用户
            ////HasOptional(m => m.CreateBy).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ToTable("FANC_Finance");
        }
    }
}
