namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfinancialAffilibiteANDTraceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CUST_FinancialAffairs", "AuditorDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CIDG_Trace", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CIDG_Trace", "DateCreated");
            DropColumn("dbo.CUST_FinancialAffairs", "AuditorDate");
        }
    }
}
