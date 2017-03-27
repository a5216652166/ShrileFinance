namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_Partner",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FANC_PartnerUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        PartnerId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.FANC_Partner", t => t.PartnerId)
                .Index(t => t.AppUser_Id)
                .Index(t => t.PartnerId);
            
            AddColumn("dbo.AspNetUsers", "UserType", c => c.Byte());
            AddColumn("dbo.FANC_Produce", "PartnerId", c => c.Guid());
            CreateIndex("dbo.FANC_Produce", "PartnerId");
            AddForeignKey("dbo.FANC_Produce", "PartnerId", "dbo.FANC_Partner", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FANC_Produce", "PartnerId", "dbo.FANC_Partner");
            DropForeignKey("dbo.FANC_PartnerUser", "PartnerId", "dbo.FANC_Partner");
            DropForeignKey("dbo.FANC_PartnerUser", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FANC_PartnerUser", new[] { "PartnerId" });
            DropIndex("dbo.FANC_PartnerUser", new[] { "AppUser_Id" });
            DropIndex("dbo.FANC_Produce", new[] { "PartnerId" });
            DropColumn("dbo.FANC_Produce", "PartnerId");
            DropColumn("dbo.AspNetUsers", "UserType");
            DropTable("dbo.FANC_PartnerUser");
            DropTable("dbo.FANC_Partner");
        }
    }
}
