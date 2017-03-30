namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PROD_Produce", newName: "FANC_Produce");
            RenameTable(name: "dbo.AbsSegment", newName: "Segment");
            DropForeignKey("dbo.PROD_FinancingItem", "FinancingProjectId", "dbo.PROD_FinancingProject");
            DropForeignKey("dbo.PROD_FinancingItem", "ProduceId", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_FinanceProduce", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.CRET_PartnerProduce", "ProduceId", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_Finance", "ProduceId", "dbo.PROD_Produce");
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropIndex("dbo.PROD_FinancingItem", new[] { "FinancingProjectId" });
            DropIndex("dbo.PROD_FinancingItem", new[] { "ProduceId" });
            DropIndex("dbo.FANC_Finance", new[] { "ProduceId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ApprovePersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinalPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ReviewPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "TrialPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinanceProduce", new[] { "FinanceId" });
            DropIndex("dbo.CIDG_DatagramFile", new[] { "TraceId" });
            RenameColumn(table: "dbo.FANC_Finance", name: "ProduceId", newName: "Produce_Id");
            DropPrimaryKey("dbo.FANC_Produce");
            DropPrimaryKey("dbo.CUST_Organization");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.LOAN_PaymentHistory");
            CreateTable(
                "dbo.Process_ProcessTempData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstanceId = c.Guid(nullable: false),
                        JsonData = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_Instance", t => t.InstanceId)
                .Index(t => t.InstanceId);
            
            CreateTable(
                "dbo.FANC_FinancialItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        FinancialAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Principal = c.Decimal(precision: 18, scale: 2),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        VATamount = c.Decimal(precision: 18, scale: 2),
                        InvoiceAmount = c.Decimal(precision: 18, scale: 2),
                        FinanceId = c.Guid(),
                        FinancialLoanId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .ForeignKey("dbo.FANC_FinancialLoan", t => t.FinancialLoanId)
                .Index(t => t.FinanceId)
                .Index(t => t.FinancialLoanId);
            
            CreateTable(
                "dbo.FANC_FinancialLoan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoanNum = c.String(nullable: false, maxLength: 20),
                        LoanDate = c.DateTime(nullable: false),
                        RepayDate = c.Byte(nullable: false),
                        State = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        FinancialAmounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewProduce_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Produce", t => t.NewProduce_Id)
                .Index(t => t.NewProduce_Id);
            
            CreateTable(
                "dbo.IO_FileSystem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 36),
                        OldName = c.String(nullable: false, maxLength: 100),
                        Extension = c.String(nullable: false, maxLength: 20),
                        Path = c.String(nullable: false, maxLength: 200),
                        IsTemp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FANC_Produce", "ProduceType", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Produce", "TimeLimit", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Produce", "Interval", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Produce", "Poundage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "MarginRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "MonthRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "ChannelRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "SalesmanRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "LeaseType", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Produce", "RepayPrincipals", c => c.String(nullable: false));
            AddColumn("dbo.LOAN_GuarantyContract", "ContractNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.LOAN_PaymentHistory", "ActualDatePayment", c => c.DateTime(nullable: false));
            AddColumn("dbo.LOAN_PaymentHistory", "ScheduledDatePayment", c => c.DateTime(nullable: false));
            AddColumn("dbo.LOAN_PaymentHistory", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CIDG_Datagram", "TraceId", c => c.Guid(nullable: false));
            AddColumn("dbo.CIDG_Trace", "OrganizateName", c => c.String(maxLength: 200));
            AddColumn("dbo.CIDG_Trace", "FileName", c => c.String(maxLength: 200));
            AlterColumn("dbo.FANC_Produce", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_Produce", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Produce_Id", c => c.Guid());
            AlterColumn("dbo.CUST_Organization", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_PaymentHistory", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.CIDG_DatagramFile", "TraceId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.FANC_Produce", "Id");
            AddPrimaryKey("dbo.CUST_Organization", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.LOAN_PaymentHistory", "Id");
            CreateIndex("dbo.FANC_Finance", "Produce_Id");
            CreateIndex("dbo.CIDG_DatagramFile", "TraceId");
            AddForeignKey("dbo.CRET_PartnerProduce", "ProduceId", "dbo.FANC_Produce", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FANC_Finance", "Produce_Id", "dbo.FANC_Produce", "Id");
            AddForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
            DropColumn("dbo.FANC_Produce", "Name");
            DropColumn("dbo.FANC_Produce", "CostRate");
            DropColumn("dbo.FANC_Produce", "RepaymentMethod");
            DropColumn("dbo.FANC_Produce", "MinFinancingRatio");
            DropColumn("dbo.FANC_Produce", "MaxFinancingRatio");
            DropColumn("dbo.FANC_Produce", "FinalRatio");
            DropColumn("dbo.FANC_Produce", "FinancingPeriods");
            DropColumn("dbo.FANC_Produce", "RepaymentInterval");
            DropColumn("dbo.FANC_Produce", "CustomerBailRatio");
            DropColumn("dbo.FANC_Produce", "Remarks");
            DropColumn("dbo.FANC_FinanceProduce", "FinanceId");
            DropColumn("dbo.LOAN_PaymentHistory", "DatePayment");
            DropColumn("dbo.CIDG_Trace", "SerialNumber");
            DropTable("dbo.PROD_FinancingItem");
            DropTable("dbo.PROD_FinancingProject");
            DropTable("dbo.FANC_CreditExamine");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FANC_CreditExamine",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SubmitDataChannel = c.String(maxLength: 200),
                        LicenseRegistration = c.String(maxLength: 20),
                        CustomerCategory = c.String(maxLength: 20),
                        DetailedIndustry = c.String(maxLength: 20),
                        CensusRegisterSeat = c.String(maxLength: 20),
                        LivingSituation = c.String(maxLength: 20),
                        WorkingCondition = c.String(maxLength: 20),
                        IncomeSourceBusiness = c.Int(),
                        IncomeSourceWage = c.Int(),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountingBasis = c.String(maxLength: 20),
                        NetnuclearPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NuclearGroupPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalLine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditCondition = c.String(maxLength: 10),
                        SpecialInstructions = c.String(maxLength: 200),
                        Margin = c.String(maxLength: 20),
                        IncreaseMarginReson = c.String(maxLength: 400),
                        AgeRange = c.String(maxLength: 20),
                        AgeRangeOther = c.String(maxLength: 20),
                        Live = c.String(maxLength: 20),
                        RealEstate = c.String(maxLength: 20),
                        Work = c.String(maxLength: 20),
                        FamilyVisit = c.String(maxLength: 20),
                        CapitalUse = c.String(maxLength: 400),
                        CableInquiry = c.String(maxLength: 400),
                        Conclusion = c.String(maxLength: 400),
                        SurveyOpinion = c.String(maxLength: 20),
                        SurveyOpinionReson = c.String(maxLength: 400),
                        ApprovePersonId = c.String(maxLength: 128),
                        FinalPersonId = c.String(maxLength: 128),
                        ReviewPersonId = c.String(maxLength: 128),
                        TrialPersonId = c.String(maxLength: 128),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PROD_FinancingProject",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsFinancing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PROD_FinancingItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FinancingProjectId = c.Guid(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEdit = c.Boolean(nullable: false),
                        ProduceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CIDG_Trace", "SerialNumber", c => c.Int(nullable: false));
            AddColumn("dbo.LOAN_PaymentHistory", "DatePayment", c => c.DateTime(nullable: false));
            AddColumn("dbo.FANC_FinanceProduce", "FinanceId", c => c.Guid());
            AddColumn("dbo.FANC_Produce", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.FANC_Produce", "CustomerBailRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "RepaymentInterval", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Produce", "FinancingPeriods", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Produce", "FinalRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "MaxFinancingRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "MinFinancingRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "RepaymentMethod", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Produce", "CostRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Produce", "Name", c => c.String(nullable: false, maxLength: 200));
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.FANC_Finance", "Produce_Id", "dbo.FANC_Produce");
            DropForeignKey("dbo.CRET_PartnerProduce", "ProduceId", "dbo.FANC_Produce");
            DropForeignKey("dbo.FANC_FinancialLoan", "NewProduce_Id", "dbo.FANC_Produce");
            DropForeignKey("dbo.FANC_FinancialItem", "FinancialLoanId", "dbo.FANC_FinancialLoan");
            DropForeignKey("dbo.FANC_FinancialItem", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.Process_ProcessTempData", "InstanceId", "dbo.FLOW_Instance");
            DropIndex("dbo.CIDG_DatagramFile", new[] { "TraceId" });
            DropIndex("dbo.FANC_FinancialLoan", new[] { "NewProduce_Id" });
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinancialLoanId" });
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Finance", new[] { "Produce_Id" });
            DropIndex("dbo.Process_ProcessTempData", new[] { "InstanceId" });
            DropPrimaryKey("dbo.LOAN_PaymentHistory");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.CUST_Organization");
            DropPrimaryKey("dbo.FANC_Produce");
            AlterColumn("dbo.CIDG_DatagramFile", "TraceId", c => c.Guid());
            AlterColumn("dbo.LOAN_PaymentHistory", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.CUST_Organization", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.FANC_Finance", "Produce_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_Produce", "Code", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FANC_Produce", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.CIDG_Trace", "FileName");
            DropColumn("dbo.CIDG_Trace", "OrganizateName");
            DropColumn("dbo.CIDG_Datagram", "TraceId");
            DropColumn("dbo.LOAN_PaymentHistory", "CreateDate");
            DropColumn("dbo.LOAN_PaymentHistory", "ScheduledDatePayment");
            DropColumn("dbo.LOAN_PaymentHistory", "ActualDatePayment");
            DropColumn("dbo.LOAN_GuarantyContract", "ContractNumber");
            DropColumn("dbo.FANC_Produce", "RepayPrincipals");
            DropColumn("dbo.FANC_Produce", "LeaseType");
            DropColumn("dbo.FANC_Produce", "SalesmanRate");
            DropColumn("dbo.FANC_Produce", "ChannelRate");
            DropColumn("dbo.FANC_Produce", "MonthRate");
            DropColumn("dbo.FANC_Produce", "MarginRate");
            DropColumn("dbo.FANC_Produce", "Poundage");
            DropColumn("dbo.FANC_Produce", "Interval");
            DropColumn("dbo.FANC_Produce", "TimeLimit");
            DropColumn("dbo.FANC_Produce", "ProduceType");
            DropTable("dbo.IO_FileSystem");
            DropTable("dbo.FANC_FinancialLoan");
            DropTable("dbo.FANC_FinancialItem");
            DropTable("dbo.Process_ProcessTempData");
            AddPrimaryKey("dbo.LOAN_PaymentHistory", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.CUST_Organization", "Id");
            AddPrimaryKey("dbo.FANC_Produce", "Id");
            RenameColumn(table: "dbo.FANC_Finance", name: "Produce_Id", newName: "ProduceId");
            CreateIndex("dbo.CIDG_DatagramFile", "TraceId");
            CreateIndex("dbo.FANC_FinanceProduce", "FinanceId");
            CreateIndex("dbo.FANC_CreditExamine", "FinanceId");
            CreateIndex("dbo.FANC_CreditExamine", "TrialPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "ReviewPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "FinalPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "ApprovePersonId");
            CreateIndex("dbo.FANC_Finance", "ProduceId");
            CreateIndex("dbo.PROD_FinancingItem", "ProduceId");
            CreateIndex("dbo.PROD_FinancingItem", "FinancingProjectId");
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.FANC_Finance", "ProduceId", "dbo.PROD_Produce", "Id");
            AddForeignKey("dbo.CRET_PartnerProduce", "ProduceId", "dbo.PROD_Produce", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FANC_FinanceProduce", "FinanceId", "dbo.FANC_Finance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PROD_FinancingItem", "ProduceId", "dbo.PROD_Produce", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PROD_FinancingItem", "FinancingProjectId", "dbo.PROD_FinancingProject", "Id");
            RenameTable(name: "dbo.Segment", newName: "AbsSegment");
            RenameTable(name: "dbo.FANC_Produce", newName: "PROD_Produce");
        }
    }
}
