namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSeriaNumberForTrace : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CIDG_Trace", "SerialNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIDG_Trace", "SerialNumber", c => c.Int(nullable: false));
        }
    }
}
