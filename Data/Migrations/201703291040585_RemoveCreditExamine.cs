namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCreditExamine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers");
            DropIndex("dbo.FANC_CreditExamine", new[] { "ApprovePersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinalPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ReviewPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "TrialPersonId" });
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FANC_CreditExamine", "TrialPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "ReviewPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "FinalPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "ApprovePersonId");
            AddForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers", "Id");
        }
    }
}
