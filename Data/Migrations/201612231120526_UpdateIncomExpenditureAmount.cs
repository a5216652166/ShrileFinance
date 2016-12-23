namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomExpenditureAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CUST_InstitutionIncome", "销售税金1", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.CIDG_IncomeExpenditureParagraph", "销售税金", c => c.String(maxLength: 20));
            DropColumn("dbo.CIDG_IncomeExpenditureParagraph", "销售税金2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIDG_IncomeExpenditureParagraph", "销售税金2", c => c.String(maxLength: 20));
            DropColumn("dbo.CIDG_IncomeExpenditureParagraph", "销售税金");
            DropColumn("dbo.CUST_InstitutionIncome", "销售税金1");
        }
    }
}
