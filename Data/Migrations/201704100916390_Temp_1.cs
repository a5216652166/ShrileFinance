namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Finance", "ApprovalPoundage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "ApprovalMargin", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 1000));
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 500));
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 500));
            DropColumn("dbo.FANC_Finance", "ApprovalMargin");
            DropColumn("dbo.FANC_Finance", "ApprovalPoundage");
        }
    }
}
