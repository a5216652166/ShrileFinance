namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProduceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_Produce",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProduceType = c.Byte(nullable: false),
                        Code = c.String(nullable: false),
                        TimeLimit = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        Poundage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarginRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChannelRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesmanRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 4),
                        LeaseType = c.Byte(nullable: false),
                        RepayPrincipals = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CRET_Partner",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LineOfCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountOfBail = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(maxLength: 200),
                        ProxyArea = c.String(maxLength: 200),
                        VehicleManage = c.String(maxLength: 200),
                        ControllerName = c.String(maxLength: 50),
                        ControllerIdentity = c.String(maxLength: 50),
                        ControllerPhone = c.String(maxLength: 50),
                        Remarks = c.String(maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CRET_PartnerAccount",
                c => new
                    {
                        PartnerId = c.Guid(nullable: false),
                        AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.AccountId })
                .ForeignKey("dbo.CRET_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.CRET_PartnerApprover",
                c => new
                    {
                        PartnerId = c.Guid(nullable: false),
                        ApproverId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.ApproverId })
                .ForeignKey("dbo.CRET_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApproverId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.ApproverId);
            
            CreateTable(
                "dbo.CRET_PartnerProduce",
                c => new
                    {
                        PartnerId = c.Guid(nullable: false),
                        ProduceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.ProduceId })
                .ForeignKey("dbo.CRET_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.FANC_Produce", t => t.ProduceId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.ProduceId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRET_PartnerProduce", "ProduceId", "dbo.FANC_Produce");
            DropForeignKey("dbo.CRET_PartnerProduce", "PartnerId", "dbo.CRET_Partner");
            DropForeignKey("dbo.CRET_PartnerApprover", "ApproverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CRET_PartnerApprover", "PartnerId", "dbo.CRET_Partner");
            DropForeignKey("dbo.CRET_PartnerAccount", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CRET_PartnerAccount", "PartnerId", "dbo.CRET_Partner");
            DropIndex("dbo.CRET_PartnerProduce", new[] { "ProduceId" });
            DropIndex("dbo.CRET_PartnerProduce", new[] { "PartnerId" });
            DropIndex("dbo.CRET_PartnerApprover", new[] { "ApproverId" });
            DropIndex("dbo.CRET_PartnerApprover", new[] { "PartnerId" });
            DropIndex("dbo.CRET_PartnerAccount", new[] { "AccountId" });
            DropIndex("dbo.CRET_PartnerAccount", new[] { "PartnerId" });
            DropTable("dbo.CRET_PartnerProduce");
            DropTable("dbo.CRET_PartnerApprover");
            DropTable("dbo.CRET_PartnerAccount");
            DropTable("dbo.CRET_Partner");
            DropTable("dbo.FANC_Produce");
        }
    }
}
