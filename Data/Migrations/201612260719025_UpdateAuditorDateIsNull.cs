namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuditorDateIsNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CUST_FinancialAffairs", "AuditorDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CUST_FinancialAffairs", "AuditorDate", c => c.DateTime(nullable: false));
        }
    }
}
