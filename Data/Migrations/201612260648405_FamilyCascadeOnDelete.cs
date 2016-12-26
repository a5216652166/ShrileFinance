namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FamilyCascadeOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager");
            DropForeignKey("dbo.CUST_FamilyMember", "StockholderId", "dbo.CUST_Stockholder");
            AddForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_FamilyMember", "StockholderId", "dbo.CUST_Stockholder", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CUST_FamilyMember", "StockholderId", "dbo.CUST_Stockholder");
            DropForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager");
            AddForeignKey("dbo.CUST_FamilyMember", "StockholderId", "dbo.CUST_Stockholder", "Id");
            AddForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager", "Id");
        }
    }
}
