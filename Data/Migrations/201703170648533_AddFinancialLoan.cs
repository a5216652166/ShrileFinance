namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinancialLoan : DbMigration
    {
        public override void Up()
        {
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
                        NewProduce_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Produce", t => t.NewProduce_Id)
                .Index(t => t.NewProduce_Id);
            
            CreateTable(
                "dbo.FANC_FinancialItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Principal = c.Decimal(precision: 18, scale: 2),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        VATamount = c.Decimal(precision: 18, scale: 2),
                        InvoiceAmount = c.Decimal(precision: 18, scale: 2),
                        financialAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinancialLoanId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_FinancialLoan", t => t.FinancialLoanId)
                .Index(t => t.FinancialLoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FANC_FinancialLoan", "NewProduce_Id", "dbo.FANC_Produce");
            DropForeignKey("dbo.FANC_FinancialItem", "FinancialLoanId", "dbo.FANC_FinancialLoan");
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinancialLoanId" });
            DropIndex("dbo.FANC_FinancialLoan", new[] { "NewProduce_Id" });
            DropTable("dbo.FANC_FinancialItem");
            DropTable("dbo.FANC_FinancialLoan");
        }
    }
}
