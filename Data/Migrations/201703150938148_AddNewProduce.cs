namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewProduce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_Produce",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false),
                        TimeLimit = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Poundage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeaseType = c.Byte(nullable: false),
                        MonthCoefficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChannelRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesmanRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        EffectiveState = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FANC_Produce");
        }
    }
}
