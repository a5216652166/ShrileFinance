namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PROD_PrincipalRatio", "Factor", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AddColumn("dbo.FANC_Finance", "Margin", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "SelfPrincipal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinanceExtension", "CustomerAccountName", c => c.String());
            AlterColumn("dbo.FANC_FinancialItem", "FinancialAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "Principal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FANC_Finance", "AdviceMoney");
            DropColumn("dbo.FANC_Finance", "AdviceRatio");
            DropColumn("dbo.FANC_Finance", "ApprovalRatio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "Principal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "FinancialAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinanceExtension", "CustomerAccountName", c => c.String(maxLength: 40));
            DropColumn("dbo.FANC_Finance", "SelfPrincipal");
            DropColumn("dbo.FANC_Finance", "Margin");
            DropColumn("dbo.PROD_PrincipalRatio", "Factor");
        }
    }
}
