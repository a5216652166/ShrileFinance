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
                        ProduceType = c.Byte(nullable: false),
                        Code = c.String(nullable: false),
                        TimeLimit = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        Poundage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarginRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChannelRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesmanRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeaseType = c.Byte(nullable: false),
                        RepayPrincipals = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FANC_Produce");
        }
    }
}
