namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcessTempData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Process_ProcessTempData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstanceId = c.Guid(nullable: false),
                        JsonData = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_Instance", t => t.InstanceId)
                .Index(t => t.InstanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Process_ProcessTempData", "InstanceId", "dbo.FLOW_Instance");
            DropIndex("dbo.Process_ProcessTempData", new[] { "InstanceId" });
            DropTable("dbo.Process_ProcessTempData");
        }
    }
}
