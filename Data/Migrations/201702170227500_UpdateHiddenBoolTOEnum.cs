namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHiddenBoolTOEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FANC_Finance", "Hidden", c => c.Byte(nullable: false));
            AlterColumn("dbo.CUST_Organization", "Hidden", c => c.Byte(nullable: false));
            AlterColumn("dbo.LOAN_CreditContranct", "Hidden", c => c.Byte(nullable: false));
            AlterColumn("dbo.LOAN_Loan", "Hidden", c => c.Byte(nullable: false));
            AlterColumn("dbo.LOAN_PaymentHistory", "Hidden", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LOAN_PaymentHistory", "Hidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LOAN_Loan", "Hidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LOAN_CreditContranct", "Hidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CUST_Organization", "Hidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Hidden", c => c.Boolean(nullable: false));
        }
    }
}
