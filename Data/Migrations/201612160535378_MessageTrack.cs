namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MESS_MessageTrack",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        ReferenceId = c.Guid(nullable: false),
                        OperationType = c.Byte(nullable: false),
                        MessageStatus = c.Byte(nullable: false),
                        MessageData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MESS_MessageTrack");
        }
    }
}
