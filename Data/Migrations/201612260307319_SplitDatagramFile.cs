namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitDatagramFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CIDG_Trace", "DatagramFileId", "dbo.CIDG_DatagramFile");
            DropIndex("dbo.CIDG_Trace", new[] { "DatagramFileId" });
            AddColumn("dbo.CIDG_DatagramFile", "Trace_Id", c => c.Guid());
            CreateIndex("dbo.CIDG_DatagramFile", "Trace_Id");
            AddForeignKey("dbo.CIDG_DatagramFile", "Trace_Id", "dbo.CIDG_Trace", "Id", cascadeDelete: true);
            DropColumn("dbo.CIDG_Trace", "DatagramFileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIDG_Trace", "DatagramFileId", c => c.Guid());
            DropForeignKey("dbo.CIDG_DatagramFile", "Trace_Id", "dbo.CIDG_Trace");
            DropIndex("dbo.CIDG_DatagramFile", new[] { "Trace_Id" });
            DropColumn("dbo.CIDG_DatagramFile", "Trace_Id");
            CreateIndex("dbo.CIDG_Trace", "DatagramFileId");
            AddForeignKey("dbo.CIDG_Trace", "DatagramFileId", "dbo.CIDG_DatagramFile", "Id");
        }
    }
}
