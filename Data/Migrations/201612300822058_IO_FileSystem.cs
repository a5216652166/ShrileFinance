namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IO_FileSystem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IO_FileSystem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
            DropTable("dbo.IO_FileSystem");
        }
    }
}
