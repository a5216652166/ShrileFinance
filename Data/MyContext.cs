namespace Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelConfigurations;
    using ModelConfigurations.Loan;
    using ModelConfigurations.CreditInvestigation;
    using ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Concern;
    using ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Organization;
    using ModelConfigurations.CreditInvestigation.Segment.CreditMessage;

    public class MyContext : IdentityDbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Identity Configurations
            modelBuilder.Configurations
                .Add(new AppUserConfiguration());

            // Process Configurations
            modelBuilder.Configurations
                .Add(new FlowConfiguration())
                .Add(new NodeConfiguration())
                .Add(new ActionConfiguration())
                .Add(new InstanceConfiguration())
                .Add(new LogConfiguration())
                .Add(new FormConfiguration())
                .Add(new FormNodeConfiguration())
                .Add(new FormRoleConfiguration());

            // Produce Configurations
            modelBuilder.Configurations
                .Add(new FinancingItemConfigration())
                .Add(new FinancingProjectConfigration())
                .Add(new ProduceConfigration());

            // Partner and Draft Configurations
            modelBuilder.Configurations
                .Add(new PartnerConfiguration())
                .Add(new DraftConfiguration());

            // Finance Configurations
            modelBuilder.Configurations
                .Add(new FinanceConfigration())
                .Add(new FinanceProduceConfiguration())
                .Add(new ApplicantConfiguration())
                .Add(new VehicleConfigration())
                .Add(new FinanceExtensionConfiguration())
                .Add(new ContactConfiguration())
                .Add(new CreditExamineConfiguration());

            // Organization Configurations
            modelBuilder.Configurations
                .Add(new OrganizationConfiguration())
                .Add(new ManagerConfiguration())
                .Add(new StockholderConfiguration())
                .Add(new AssociatedEnterpriseConfiguration())
                .Add(new FamilyMemberConfiguration())
                .Add(new BigEventConfiguration())
                .Add(new CashFlowConfiguration())
                .Add(new InstitutionIncomeExpenditureConfiguration())
                .Add(new InstitutionLiabilitiesConfiguration())
                .Add(new LiabilitiesConfiguration())
                .Add(new LitigationConfigruation())
                .Add(new ProfitConfiguration())
                .Add(new ParentConfigration())
                .Add(new FinancialAffairsConfiguration());

            // Loan Configurations
            modelBuilder.Configurations
                .Add(new CreditContractConfiguration())
                .Add(new GuarantorConfiguration())
                .Add(new GuarantyOrganizationConfiguration())
                .Add(new GuarantyPersonConfiguration())
                .Add(new GuarantyContractConfiguration())
                .Add(new PledgeGuarantyContractConfiguration())
                .Add(new MortgageGuarantyContractConfiguration())
                .Add(new LoanConfiguration())
                .Add(new PaymentHistoryConfiguration());

            // CreditInvestigations
            modelBuilder.Configurations
                .Add(new MessageTrackConfiguration())
                .Add(new BigEventSegmentConfiguration())
                .Add(new ConcernBaseSegmentConfiguration())
                .Add(new LitigationSegmentConfiguration())
                .Add(new AssociatedEnterpriseSegmentConfiguration())
                .Add(new BaseSegmentConfiguration())
                .Add(new FamilySegmentConfiguration())
                .Add(new ManagerSegmentConfiguration())
                .Add(new OrganizationContactSegmentConfiguration())
                .Add(new OrganizationStateSegmentConfiguration())
                .Add(new ParentSegmentConfiguration())
                .Add(new PropertySegmentConfiguration())
                .Add(new StockholderSegmentConfiguration())
                .Add(new CreditBaseSegmentConfiguration())
                .Add(new CreditContractAmountSegmentConfiguration())
                .Add(new CreditContractSegmentConfiguration())
                .Add(new DebitInterestBaseSegmentConfiguration())
                .Add(new DebitInterestSegmentConfiguration())
                .Add(new GuaranteeBaseSegmentConfiguration())
                .Add(new GuaranteeMortgageSegmentConfiguration())
                .Add(new GuaranteePledgeSegmentConfiguration())
                .Add(new GuaranteeSegmentConfiguration())
                .Add(new LoanSegmentConfiguration())
                .Add(new NaturalGuaranteeSegmentConfiguration())
                .Add(new NaturalMortgageSegmentConfiguration())
                .Add(new NaturalPledgeSegmentConfiguration())
                .Add(new RepaymentSegmentConfiguration())
                ;
            base.OnModelCreating(modelBuilder);
        }
    }
}