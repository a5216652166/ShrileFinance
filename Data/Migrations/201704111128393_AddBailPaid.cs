namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBailPaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Finance", "BailPaid", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FANC_Finance", "BailPaid");
        }
    }
}
