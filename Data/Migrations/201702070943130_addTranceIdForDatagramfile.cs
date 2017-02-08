namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTranceIdForDatagramfile : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CIDG_DatagramFile", new[] { "TraceId" });
            AddColumn("dbo.CIDG_Datagram", "TraceId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CIDG_DatagramFile", "TraceId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CIDG_DatagramFile", "TraceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CIDG_DatagramFile", new[] { "TraceId" });
            AlterColumn("dbo.CIDG_DatagramFile", "TraceId", c => c.Guid());
            DropColumn("dbo.CIDG_Datagram", "TraceId");
            CreateIndex("dbo.CIDG_DatagramFile", "TraceId");
        }
    }
}
