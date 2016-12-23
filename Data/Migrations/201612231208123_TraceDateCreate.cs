namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraceDateCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIDG_Trace", "SpecialDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CIDG_Trace", "TraceDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIDG_Trace", "TraceDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CIDG_Trace", "SpecialDate");
        }
    }
}
