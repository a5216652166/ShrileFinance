namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FinanceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_Finance",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Principal = c.Decimal(precision: 18, scale: 2),
                        RepaymentDate = c.Int(),
                        RepaymentScheme = c.Byte(nullable: false),
                        Bail = c.Decimal(precision: 18, scale: 2),
                        OnePayInterest = c.Decimal(precision: 18, scale: 2),
                        DateEffective = c.DateTime(),
                        Financing = c.Decimal(precision: 18, scale: 2),
                        Poundage = c.Decimal(precision: 18, scale: 2),
                        OncePayMonths = c.Int(),
                        AdviceMoney = c.Decimal(precision: 18, scale: 2),
                        AdviceRatio = c.Decimal(precision: 18, scale: 2),
                        ApprovalMoney = c.Decimal(precision: 18, scale: 2),
                        ApprovalRatio = c.Decimal(precision: 18, scale: 2),
                        Payment = c.Decimal(precision: 18, scale: 2),
                        RepayRentDate = c.DateTime(),
                        DateCreated = c.DateTime(nullable: false),
                        CreateBy_Id = c.String(maxLength: 128),
                        CreateOf_Id = c.Guid(),
                        Produce_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreateBy_Id)
                .ForeignKey("dbo.CRET_Partner", t => t.CreateOf_Id)
                .ForeignKey("dbo.PROD_Produce", t => t.Produce_Id)
                .Index(t => t.CreateBy_Id)
                .Index(t => t.CreateOf_Id)
                .Index(t => t.Produce_Id);
            
            CreateTable(
                "dbo.FANC_Applicant",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sex = c.String(nullable: false, maxLength: 5),
                        IdentityType = c.String(maxLength: 50),
                        Identity = c.String(maxLength: 50),
                        Type = c.Byte(nullable: false),
                        RelationWithMaster = c.String(maxLength: 50),
                        MaritalStatus = c.String(maxLength: 10),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        LiveHouseAddress = c.String(maxLength: 200),
                        ContactAddress = c.String(maxLength: 200),
                        ContactAddressType = c.String(maxLength: 10),
                        RegisteredAddress = c.String(maxLength: 200),
                        OfficeName = c.String(maxLength: 200),
                        Department = c.String(maxLength: 50),
                        Position = c.String(maxLength: 50),
                        IndustryType = c.String(maxLength: 100),
                        OfficePhone = c.String(maxLength: 50),
                        OfficeAddress = c.String(maxLength: 200),
                        WifeName = c.String(maxLength: 50),
                        WifePhone = c.String(maxLength: 50),
                        WifeOfficeName = c.String(maxLength: 100),
                        WifeOfficeAddress = c.String(maxLength: 200),
                        TotalMonthlyIncome = c.Decimal(precision: 18, scale: 2),
                        OtherIncome = c.Decimal(precision: 18, scale: 2),
                        HomeMonthlyIncome = c.Decimal(precision: 18, scale: 2),
                        HomeMonthlyExpend = c.Decimal(precision: 18, scale: 2),
                        Degree = c.String(maxLength: 50),
                        FamilyNumber = c.Int(),
                        OwnHouseCount = c.Int(nullable: false),
                        OwnHouse = c.String(maxLength: 1000),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Path = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_FinanceExtension",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanPrincipal = c.String(maxLength: 20),
                        CreditAccountName = c.String(),
                        CreditBankName = c.String(maxLength: 40),
                        CreditBankCard = c.String(maxLength: 40),
                        ContactJson = c.String(maxLength: 800),
                        CustomerAccountName = c.String(maxLength: 40),
                        CustomerBankName = c.String(maxLength: 40),
                        CustomerBankCard = c.String(maxLength: 40),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_FinancialItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                "dbo.FANC_Vehicle",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MakeCode = c.String(nullable: false, maxLength: 50),
                        VehicleCondition = c.Int(nullable: false),
                        FamilyCode = c.String(nullable: false, maxLength: 50),
                        VehicleKey = c.String(nullable: false, maxLength: 20),
                        ManufacturerGuidePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegisterCity = c.String(maxLength: 50),
                        SallerName = c.String(maxLength: 50),
                        PlateNo = c.String(maxLength: 50),
                        FrameNo = c.String(maxLength: 50),
                        EngineNo = c.String(maxLength: 50),
                        RegisterDate = c.String(),
                        RunningMiles = c.Int(),
                        FactoryDate = c.String(),
                        BuyCarYears = c.Int(),
                        Color = c.String(maxLength: 50),
                        Condition = c.Byte(nullable: false),
                        BusinessType = c.Byte(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_FinancialLoan",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanNum = c.String(nullable: false, maxLength: 20),
                        LoanDate = c.DateTime(nullable: false),
                        RepayDate = c.Byte(nullable: false),
                        State = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        FinancialAmounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Produce_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PROD_Produce", t => t.Produce_Id)
                .Index(t => t.Produce_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FANC_FinancialLoan", "Produce_Id", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_FinancialItem", "FinancialLoanId", "dbo.FANC_FinancialLoan");
            DropForeignKey("dbo.FANC_Vehicle", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Finance", "Produce_Id", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_FinancialItem", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_FinanceExtension", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Finance", "CreateOf_Id", "dbo.CRET_Partner");
            DropForeignKey("dbo.FANC_Finance", "CreateBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_Contact", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Applicant", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FANC_FinancialLoan", new[] { "Produce_Id" });
            DropIndex("dbo.FANC_Vehicle", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinancialLoanId" });
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinanceExtension", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Contact", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Applicant", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Finance", new[] { "Produce_Id" });
            DropIndex("dbo.FANC_Finance", new[] { "CreateOf_Id" });
            DropIndex("dbo.FANC_Finance", new[] { "CreateBy_Id" });
            DropTable("dbo.FANC_FinancialLoan");
            DropTable("dbo.FANC_Vehicle");
            DropTable("dbo.FANC_FinancialItem");
            DropTable("dbo.FANC_FinanceExtension");
            DropTable("dbo.FANC_Contact");
            DropTable("dbo.FANC_Applicant");
            DropTable("dbo.FANC_Finance");
        }
    }
}
