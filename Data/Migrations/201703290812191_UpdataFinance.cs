namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataFinance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_FinanceProduce", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FANC_Finance", new[] { "ProduceId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinanceProduce", new[] { "FinanceId" });
            RenameColumn(table: "dbo.FANC_Finance", name: "ProduceId", newName: "Produce_Id");
            AddColumn("dbo.FANC_FinancialItem", "FinanceId", c => c.Guid());
            AlterColumn("dbo.FANC_Finance", "Produce_Id", c => c.Guid());
            CreateIndex("dbo.FANC_Finance", "Produce_Id");
            CreateIndex("dbo.FANC_FinancialItem", "FinanceId");
            AddForeignKey("dbo.FANC_FinancialItem", "FinanceId", "dbo.FANC_Finance", "Id", cascadeDelete: true);
            DropColumn("dbo.FANC_CreditExamine", "FinanceId");
            DropColumn("dbo.FANC_FinanceProduce", "FinanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_FinanceProduce", "FinanceId", c => c.Guid());
            AddColumn("dbo.FANC_CreditExamine", "FinanceId", c => c.Guid());
            DropForeignKey("dbo.FANC_FinancialItem", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FANC_FinancialItem", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Finance", new[] { "Produce_Id" });
            AlterColumn("dbo.FANC_Finance", "Produce_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.FANC_FinancialItem", "FinanceId");
            RenameColumn(table: "dbo.FANC_Finance", name: "Produce_Id", newName: "ProduceId");
            CreateIndex("dbo.FANC_FinanceProduce", "FinanceId");
            CreateIndex("dbo.FANC_CreditExamine", "FinanceId");
            CreateIndex("dbo.FANC_Finance", "ProduceId");
            AddForeignKey("dbo.FANC_FinanceProduce", "FinanceId", "dbo.FANC_Finance", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance", "Id", cascadeDelete: true);
        }
    }
}
