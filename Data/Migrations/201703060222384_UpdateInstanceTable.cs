namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInstanceTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FLOW_Instance", "ProcessType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FLOW_Instance", "ProcessType", c => c.Int(nullable: false));
        }
    }
}
