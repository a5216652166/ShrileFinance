namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProcessTempData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Process_ProcessTempData", "JsonData", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Process_ProcessTempData", "JsonData", c => c.String(nullable: false, maxLength: 400));
        }
    }
}
