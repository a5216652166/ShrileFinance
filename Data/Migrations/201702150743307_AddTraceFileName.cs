namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraceFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIDG_Trace", "OrganizateName", c => c.String(maxLength: 200));
            AddColumn("dbo.CIDG_Trace", "FileName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CIDG_Trace", "FileName");
            DropColumn("dbo.CIDG_Trace", "OrganizateName");
        }
    }
}
