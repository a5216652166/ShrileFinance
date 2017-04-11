namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_BranchOffice",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Fax = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FANC_Finance", "LeaseMode", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Finance", "LeaseNo", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_Finance", "RentPayableStartDate", c => c.DateTime());
            AddColumn("dbo.FANC_Finance", "ApprovalPoundage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "ApprovalMargin", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_FinanceExtension", "GuarantorName1", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_FinanceExtension", "GuarantorNo1", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_FinanceExtension", "GuarantorName2", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_FinanceExtension", "GuarantorNo2", c => c.String(maxLength: 20));
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 1000));
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FLOW_Log", "Opinion_ExnernalOpinion", c => c.String(maxLength: 500));
            AlterColumn("dbo.FLOW_Log", "Opinion_InternalOpinion", c => c.String(maxLength: 500));
            DropColumn("dbo.FANC_FinanceExtension", "GuarantorNo2");
            DropColumn("dbo.FANC_FinanceExtension", "GuarantorName2");
            DropColumn("dbo.FANC_FinanceExtension", "GuarantorNo1");
            DropColumn("dbo.FANC_FinanceExtension", "GuarantorName1");
            DropColumn("dbo.FANC_Finance", "ApprovalMargin");
            DropColumn("dbo.FANC_Finance", "ApprovalPoundage");
            DropColumn("dbo.FANC_Finance", "RentPayableStartDate");
            DropColumn("dbo.FANC_Finance", "LeaseNo");
            DropColumn("dbo.FANC_Finance", "LeaseMode");
            DropTable("dbo.FANC_BranchOffice");
        }
    }
}
