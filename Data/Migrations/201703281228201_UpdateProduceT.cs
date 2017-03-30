namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduceT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PROD_FinancingItem", "ProduceId", "dbo.PROD_Produce");
            DropIndex("dbo.PROD_FinancingItem", new[] { "ProduceId" });
            DropColumn("dbo.PROD_FinancingItem", "ProduceId");
            DropTable("dbo.PROD_Produce");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PROD_Produce",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 200),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RepaymentMethod = c.Byte(nullable: false),
                        MinFinancingRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxFinancingRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinancingPeriods = c.Int(nullable: false),
                        RepaymentInterval = c.Int(nullable: false),
                        CustomerBailRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Remarks = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PROD_FinancingItem", "ProduceId", c => c.Guid());
            CreateIndex("dbo.PROD_FinancingItem", "ProduceId");
            AddForeignKey("dbo.PROD_FinancingItem", "ProduceId", "dbo.PROD_Produce", "Id", cascadeDelete: true);
        }
    }
}
