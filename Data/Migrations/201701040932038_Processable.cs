namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Processable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Finance", "Hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.CUST_Organization", "Hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.LOAN_CreditContranct", "Hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.LOAN_Loan", "Hidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.LOAN_PaymentHistory", "Hidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOAN_PaymentHistory", "Hidden");
            DropColumn("dbo.LOAN_Loan", "Hidden");
            DropColumn("dbo.LOAN_CreditContranct", "Hidden");
            DropColumn("dbo.CUST_Organization", "Hidden");
            DropColumn("dbo.FANC_Finance", "Hidden");
        }
    }
}
