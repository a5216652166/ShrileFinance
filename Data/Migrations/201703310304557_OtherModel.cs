namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SYS_Draft",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PageLink = c.String(maxLength: 400),
                        PageData = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SYS_FileSystem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 36),
                        OldName = c.String(nullable: false, maxLength: 100),
                        Extension = c.String(nullable: false, maxLength: 20),
                        Path = c.String(nullable: false, maxLength: 200),
                        IsTemp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SYS_Draft", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SYS_Draft", new[] { "UserId" });
            DropTable("dbo.SYS_FileSystem");
            DropTable("dbo.SYS_Draft");
        }
    }
}
