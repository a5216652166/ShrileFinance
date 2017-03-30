namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProcessModel : DbMigration
    {
        public override void Up()
        {
            ////Sql(@"IF object_id(N'[dbo].[FK__Notice_Ac__Actio__7A3223E8]', N'F') IS NOT NULL
            ////    ALTER TABLE[dbo].[Notice_ActionNotice] DROP CONSTRAINT[FK__Notice_Ac__Actio__7A3223E8]");
            ////DropForeignKey("dbo.Notice_ActionNotice", "ActionId", "dbo.FLOW_Action");
            ////DropTable("dbo.FLOW_MenuWithRole");
            ////DropTable("dbo.FLOW_MenuWithNode");
            ////DropTable("dbo.FLOW_Menu");
            ////DropTable("dbo.FLOW_FormWithRole");
            ////DropTable("dbo.FLOW_FormWithNode");
            ////DropTable("dbo.FLOW_Form");
            ////DropTable("dbo.FLOW_Log");
            ////DropTable("dbo.FLOW_Instance");
            ////DropTable("dbo.FLOW_Action");
            ////DropTable("dbo.FLOW_Node");
            ////DropTable("dbo.FLOW_WorkFlow");

            CreateTable(
                "dbo.FLOW_WorkFlow",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FLOW_Node",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        FlowId = c.Guid(nullable: false),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_WorkFlow", t => t.FlowId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.FlowId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FLOW_Action",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        NodeId = c.Guid(nullable: false),
                        TransferId = c.Guid(),
                        Type = c.Byte(nullable: false),
                        AllocationType = c.Byte(),
                        Method = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_Node", t => t.NodeId)
                .ForeignKey("dbo.FLOW_Node", t => t.TransferId)
                .Index(t => t.NodeId)
                .Index(t => t.TransferId);
            
            CreateTable(
                "dbo.FLOW_Instance",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        FlowId = c.Guid(nullable: false),
                        CurrentNodeId = c.Guid(),
                        CurrentUserId = c.String(maxLength: 128),
                        StartUserId = c.String(nullable: false, maxLength: 128),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        Status = c.Byte(nullable: false),
                        RootKey = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_Node", t => t.CurrentNodeId)
                .ForeignKey("dbo.AspNetUsers", t => t.CurrentUserId)
                .ForeignKey("dbo.FLOW_WorkFlow", t => t.FlowId)
                .ForeignKey("dbo.AspNetUsers", t => t.StartUserId)
                .Index(t => t.FlowId)
                .Index(t => t.CurrentNodeId)
                .Index(t => t.CurrentUserId)
                .Index(t => t.StartUserId);
            
            CreateTable(
                "dbo.FLOW_Log",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        InstanceId = c.Guid(),
                        NodeId = c.Guid(nullable: false),
                        ActionId = c.Guid(nullable: false),
                        ProcessUserId = c.String(nullable: false, maxLength: 128),
                        ProcessTime = c.DateTime(nullable: false),
                        Content = c.String(maxLength: 500),
                        Opinion_InternalOpinion = c.String(maxLength: 500),
                        Opinion_ExnernalOpinion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_Action", t => t.ActionId)
                .ForeignKey("dbo.FLOW_Instance", t => t.InstanceId, cascadeDelete: true)
                .ForeignKey("dbo.FLOW_Node", t => t.NodeId)
                .ForeignKey("dbo.AspNetUsers", t => t.ProcessUserId)
                .Index(t => t.InstanceId)
                .Index(t => t.NodeId)
                .Index(t => t.ActionId)
                .Index(t => t.ProcessUserId);
            
            CreateTable(
                "dbo.FLOW_Form",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FlowId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 100),
                        Sort = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FLOW_WorkFlow", t => t.FlowId)
                .Index(t => t.FlowId);
            
            CreateTable(
                "dbo.FLOW_FormNode",
                c => new
                    {
                        NodeId = c.Guid(nullable: false),
                        FormId = c.Guid(nullable: false),
                        State = c.Byte(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                        IsHandler = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.NodeId, t.FormId })
                .ForeignKey("dbo.FLOW_Form", t => t.FormId, cascadeDelete: true)
                .ForeignKey("dbo.FLOW_Node", t => t.NodeId, cascadeDelete: true)
                .Index(t => t.NodeId)
                .Index(t => t.FormId);
            
            CreateTable(
                "dbo.FLOW_FormRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        FormId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.FormId })
                .ForeignKey("dbo.FLOW_Form", t => t.FormId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.FormId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FLOW_FormRole", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FLOW_FormRole", "FormId", "dbo.FLOW_Form");
            DropForeignKey("dbo.FLOW_FormNode", "NodeId", "dbo.FLOW_Node");
            DropForeignKey("dbo.FLOW_FormNode", "FormId", "dbo.FLOW_Form");
            DropForeignKey("dbo.FLOW_Form", "FlowId", "dbo.FLOW_WorkFlow");
            DropForeignKey("dbo.FLOW_Instance", "StartUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FLOW_Log", "ProcessUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FLOW_Log", "NodeId", "dbo.FLOW_Node");
            DropForeignKey("dbo.FLOW_Log", "InstanceId", "dbo.FLOW_Instance");
            DropForeignKey("dbo.FLOW_Log", "ActionId", "dbo.FLOW_Action");
            DropForeignKey("dbo.FLOW_Instance", "FlowId", "dbo.FLOW_WorkFlow");
            DropForeignKey("dbo.FLOW_Instance", "CurrentUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FLOW_Instance", "CurrentNodeId", "dbo.FLOW_Node");
            DropForeignKey("dbo.FLOW_Node", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FLOW_Node", "FlowId", "dbo.FLOW_WorkFlow");
            DropForeignKey("dbo.FLOW_Action", "TransferId", "dbo.FLOW_Node");
            DropForeignKey("dbo.FLOW_Action", "NodeId", "dbo.FLOW_Node");
            DropIndex("dbo.FLOW_FormRole", new[] { "FormId" });
            DropIndex("dbo.FLOW_FormRole", new[] { "RoleId" });
            DropIndex("dbo.FLOW_FormNode", new[] { "FormId" });
            DropIndex("dbo.FLOW_FormNode", new[] { "NodeId" });
            DropIndex("dbo.FLOW_Form", new[] { "FlowId" });
            DropIndex("dbo.FLOW_Log", new[] { "ProcessUserId" });
            DropIndex("dbo.FLOW_Log", new[] { "ActionId" });
            DropIndex("dbo.FLOW_Log", new[] { "NodeId" });
            DropIndex("dbo.FLOW_Log", new[] { "InstanceId" });
            DropIndex("dbo.FLOW_Instance", new[] { "StartUserId" });
            DropIndex("dbo.FLOW_Instance", new[] { "CurrentUserId" });
            DropIndex("dbo.FLOW_Instance", new[] { "CurrentNodeId" });
            DropIndex("dbo.FLOW_Instance", new[] { "FlowId" });
            DropIndex("dbo.FLOW_Action", new[] { "TransferId" });
            DropIndex("dbo.FLOW_Action", new[] { "NodeId" });
            DropIndex("dbo.FLOW_Node", new[] { "RoleId" });
            DropIndex("dbo.FLOW_Node", new[] { "FlowId" });
            DropTable("dbo.FLOW_FormRole");
            DropTable("dbo.FLOW_FormNode");
            DropTable("dbo.FLOW_Form");
            DropTable("dbo.FLOW_Log");
            DropTable("dbo.FLOW_Instance");
            DropTable("dbo.FLOW_Action");
            DropTable("dbo.FLOW_Node");
            DropTable("dbo.FLOW_WorkFlow");
        }
    }
}
