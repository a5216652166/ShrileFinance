namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnusedDatagram : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIDG_Datagram", "UnusedType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CIDG_Datagram", "UnusedType");
        }
    }
}
