namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstanceIdInPaymentHository : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LOAN_PaymentHistory", "InstanceId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LOAN_PaymentHistory", "InstanceId");
        }
    }
}
