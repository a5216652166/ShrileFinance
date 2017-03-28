namespace Data.ModelConfigurations.FinanceConfigurations.FinancialConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Financial;

    public class NewProduceConfiguration : EntityTypeConfiguration<Produce>
    {
        public NewProduceConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.ProduceType).IsRequired();
            Property(m => m.Code).IsRequired();
            Property(m => m.TimeLimit).IsRequired();
            Property(m => m.Interval).IsRequired();
            Property(m => m.Poundage).IsRequired();
            Property(m => m.MarginRate).IsRequired();
            Property(m => m.MonthRate).IsRequired();
            Property(m => m.ChannelRate).IsRequired();
            Property(m => m.SalesmanRate).IsRequired();
            Property(m => m.InterestRate).IsRequired();
            Property(m => m.LeaseType).IsRequired();
            Property(m => m.RepayPrincipals).IsRequired();
            Property(m => m.CreatedDate).IsRequired();

            ToTable("FANC_Produce");
        }
    }
}
