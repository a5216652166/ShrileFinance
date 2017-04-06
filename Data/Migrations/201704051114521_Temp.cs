namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PROD_PrincipalRatio", "Factor", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AddColumn("dbo.FANC_Finance", "SelfPrincipal", c => c.Decimal(nullable: true, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "FinancialAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "Principal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FANC_FinancialItem", "Principal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_FinancialItem", "FinancialAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FANC_Finance", "SelfPrincipal");
            DropColumn("dbo.PROD_PrincipalRatio", "Factor");
        }
    }
}
