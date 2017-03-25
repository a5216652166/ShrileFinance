namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePaymentHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOAN_PaymentHistory", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOAN_PaymentHistory", "CreateDate");
        }
    }
}
