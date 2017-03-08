namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcessDecouple : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LOAN_PaymentHistory");
            AlterColumn("dbo.LOAN_PaymentHistory", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.LOAN_PaymentHistory", "Id");
            DropColumn("dbo.FLOW_Instance", "ProcessType");
            DropColumn("dbo.FANC_Finance", "Hidden");
            DropColumn("dbo.CUST_Organization", "Hidden");
            DropColumn("dbo.LOAN_CreditContranct", "Hidden");
            DropColumn("dbo.LOAN_Loan", "Hidden");
            DropColumn("dbo.LOAN_PaymentHistory", "Hidden");
            DropColumn("dbo.LOAN_PaymentHistory", "InstanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOAN_PaymentHistory", "InstanceId", c => c.Guid(nullable: false));
            AddColumn("dbo.LOAN_PaymentHistory", "Hidden", c => c.Byte(nullable: false));
            AddColumn("dbo.LOAN_Loan", "Hidden", c => c.Byte(nullable: false));
            AddColumn("dbo.LOAN_CreditContranct", "Hidden", c => c.Byte(nullable: false));
            AddColumn("dbo.CUST_Organization", "Hidden", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Finance", "Hidden", c => c.Byte(nullable: false));
            AddColumn("dbo.FLOW_Instance", "ProcessType", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.LOAN_PaymentHistory");
            AlterColumn("dbo.LOAN_PaymentHistory", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.LOAN_PaymentHistory", "Id");
        }
    }
}
