namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CancelAutoGeneratePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropPrimaryKey("dbo.Process_ProcessTempData");
            DropPrimaryKey("dbo.CUST_Organization");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.IO_FileSystem");
            AddColumn("dbo.LOAN_GuarantyContract", "ContractNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Process_ProcessTempData", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.CUST_Organization", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.IO_FileSystem", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Process_ProcessTempData", "Id");
            AddPrimaryKey("dbo.CUST_Organization", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.IO_FileSystem", "Id");
            AddForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropPrimaryKey("dbo.IO_FileSystem");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.CUST_Organization");
            DropPrimaryKey("dbo.Process_ProcessTempData");
            AlterColumn("dbo.IO_FileSystem", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.CUST_Organization", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Process_ProcessTempData", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.LOAN_GuarantyContract", "ContractNumber");
            AddPrimaryKey("dbo.IO_FileSystem", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.CUST_Organization", "Id");
            AddPrimaryKey("dbo.Process_ProcessTempData", "Id");
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization", "Id");
            AddForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization", "Id");
        }
    }
}
