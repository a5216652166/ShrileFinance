namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ProduceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PROD_Produce",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 80),
                        ProduceType = c.String(maxLength: 80),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 12),
                        Periods = c.Int(nullable: false),
                        PeriodsPerpayment = c.Int(nullable: false),
                        CustomerCostRatio = c.Decimal(nullable: false, precision: 18, scale: 8),
                        CustomerBailRatio = c.Decimal(nullable: false, precision: 18, scale: 8),
                        CostRate = c.Decimal(nullable: false, precision: 18, scale: 12),
                        PartnersCommissionRatio = c.Decimal(nullable: false, precision: 18, scale: 8),
                        EmployeeCommissionRatio = c.Decimal(nullable: false, precision: 18, scale: 8),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.PROD_PrincipalRatio",
                c => new
                    {
                        ProduceId = c.Guid(nullable: false),
                        Period = c.Int(nullable: false),
                        Ratio = c.Decimal(nullable: false, precision: 18, scale: 8),
                    })
                .PrimaryKey(t => new { t.ProduceId, t.Period })
                .ForeignKey("dbo.PROD_Produce", t => t.ProduceId, cascadeDelete: true)
                .Index(t => t.ProduceId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PROD_PrincipalRatio", "ProduceId", "dbo.PROD_Produce");
            DropIndex("dbo.PROD_PrincipalRatio", new[] { "ProduceId" });
            DropIndex("dbo.PROD_Produce", new[] { "Code" });
            DropTable("dbo.PROD_PrincipalRatio");
            DropTable("dbo.PROD_Produce");
        }
    }
}
