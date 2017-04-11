namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 1000));
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 500));
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 500));
        }
    }
}
