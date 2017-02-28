namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CancelAutoGeneratePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropPrimaryKey("dbo.Process_ProcessTempData");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.IO_FileSystem");
            AlterColumn("dbo.Process_ProcessTempData", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.IO_FileSystem", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Process_ProcessTempData", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.IO_FileSystem", "Id");
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.IO_FileSystem");
            DropPrimaryKey("dbo.LOAN_Loan");
            DropPrimaryKey("dbo.LOAN_CreditContranct");
            DropPrimaryKey("dbo.Process_ProcessTempData");
            AlterColumn("dbo.IO_FileSystem", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_Loan", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.LOAN_CreditContranct", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Process_ProcessTempData", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.IO_FileSystem", "Id");
            AddPrimaryKey("dbo.LOAN_Loan", "Id");
            AddPrimaryKey("dbo.LOAN_CreditContranct", "Id");
            AddPrimaryKey("dbo.Process_ProcessTempData", "Id");
            AddForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan", "Id");
            AddForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct", "Id", cascadeDelete: true);
        }
    }
}
