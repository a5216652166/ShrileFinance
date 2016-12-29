namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSegmentName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AbsSegment", newName: "Segment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Segment", newName: "AbsSegment");
        }
    }
}
