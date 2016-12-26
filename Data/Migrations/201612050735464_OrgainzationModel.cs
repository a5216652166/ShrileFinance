namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrgainzationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUST_Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CustomerNumber = c.String(nullable: false, maxLength: 40),
                        ManagementerCode = c.String(nullable: false, maxLength: 20),
                        CustomerType = c.String(nullable: false, maxLength: 1),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizateCode = c.String(maxLength: 10),
                        TaxpayerIdentifyIrsNumber = c.String(maxLength: 20),
                        TaxpayerIdentifyLandNumber = c.String(maxLength: 20),
                        LoanCardCode = c.String(nullable: false, maxLength: 16),
                        CreatedDate = c.DateTime(nullable: false),
                        Property_InstitutionChName = c.String(nullable: false, maxLength: 80),
                        Property_RegisterAddress = c.String(maxLength: 80),
                        Property_RegisterAdministrativeDivision = c.String(maxLength: 6),
                        Property_SetupDate = c.DateTime(),
                        Property_CertificateDueDate = c.DateTime(),
                        Property_BusinessScope = c.String(maxLength: 400),
                        Property_RegisterCapital = c.Decimal(precision: 10, scale: 2),
                        Property_OrganizationCategory = c.String(maxLength: 1),
                        Property_OrganizationCategorySubdivision = c.String(maxLength: 2),
                        Property_EconomicSectorsClassification = c.String(maxLength: 5),
                        Property_EconomicType = c.String(maxLength: 2),
                        State_EnterpriseScale = c.String(maxLength: 1),
                        State_InstitutionsState = c.String(maxLength: 1),
                        Contact_OfficeAddress = c.String(maxLength: 80),
                        Contact_ContactPhone = c.String(maxLength: 35),
                        Contact_FinancialContactPhone = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_AssociatedEnterprise",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AssociatedType = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false, maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_BigEvent",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BigEventNumber = c.String(),
                        BigEventDescription = c.String(nullable: false, maxLength: 250),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_FinancialAffairs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        TypeSubdivision = c.Int(nullable: false),
                        AuditFirm = c.String(nullable: false, maxLength: 80),
                        AuditorName = c.String(nullable: false, maxLength: 30),
                        AuditorDate = c.DateTime(),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_CashFlow",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        SaleGoodsCash = c.Decimal(precision: 18, scale: 2),
                        TaxesRefunds = c.Decimal(precision: 18, scale: 2),
                        ReceiveOperatingActivitiesCash = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitiesCashInflows = c.Decimal(precision: 18, scale: 2),
                        BuyGoodsCash = c.Decimal(precision: 18, scale: 2),
                        PayEmployeeCash = c.Decimal(precision: 18, scale: 2),
                        PayAllTaxes = c.Decimal(precision: 18, scale: 2),
                        PayOperatingActivitiesCash = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitiesCashOutflows = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitieCashNet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecoveryInvestmentCash = c.Decimal(precision: 18, scale: 2),
                        InvestmentIncomeCash = c.Decimal(precision: 18, scale: 2),
                        RecoveryAssetsCash = c.Decimal(precision: 18, scale: 2),
                        RecoveryChildrenCompanyCash = c.Decimal(precision: 18, scale: 2),
                        OtherInvestmentCash = c.Decimal(precision: 18, scale: 2),
                        CashInInvestmentActivities = c.Decimal(precision: 18, scale: 2),
                        BuyAssetsCash = c.Decimal(precision: 18, scale: 2),
                        InvestmentPaidCash = c.Decimal(precision: 18, scale: 2),
                        GetChildrenComponyCash = c.Decimal(precision: 18, scale: 2),
                        PayOtherInvestmentCash = c.Decimal(precision: 18, scale: 2),
                        InvestmentCashOutflow = c.Decimal(precision: 18, scale: 2),
                        InvestmentCashInflow = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AbsorbInvestmentCash = c.Decimal(precision: 18, scale: 2),
                        GetLoanCash = c.Decimal(precision: 18, scale: 2),
                        GetFinancingCash = c.Decimal(precision: 18, scale: 2),
                        FinancingCashInflow = c.Decimal(precision: 18, scale: 2),
                        DebtRedemption = c.Decimal(precision: 18, scale: 2),
                        PayCashForDividend = c.Decimal(precision: 18, scale: 2),
                        PayFinancingCash = c.Decimal(precision: 18, scale: 2),
                        PayOtherFinancingCash = c.Decimal(precision: 18, scale: 2),
                        FinancingCashOutflow = c.Decimal(precision: 18, scale: 2),
                        FinancingNetCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExchangeRateChangeCash = c.Decimal(precision: 18, scale: 2),
                        CashIncrease5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeginCashBalance = c.Decimal(precision: 18, scale: 2),
                        FinalCashBalance6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetProfit = c.Decimal(precision: 18, scale: 2),
                        AssetImpairment = c.Decimal(precision: 18, scale: 2),
                        AssetsDepreciation = c.Decimal(precision: 18, scale: 2),
                        IntangibleAssetsAmortization = c.Decimal(precision: 18, scale: 2),
                        LongPrepaidExpenses = c.Decimal(precision: 18, scale: 2),
                        PrepaidExpensesLessen = c.Decimal(precision: 18, scale: 2),
                        AccruedExpenses = c.Decimal(precision: 18, scale: 2),
                        Assetloss = c.Decimal(precision: 18, scale: 2),
                        FixedAssetsScrap = c.Decimal(precision: 18, scale: 2),
                        FairChanges = c.Decimal(precision: 18, scale: 2),
                        FinancialExpenses = c.Decimal(precision: 18, scale: 2),
                        InvestmentLosses = c.Decimal(precision: 18, scale: 2),
                        DeferredIncomeTaxLessen = c.Decimal(precision: 18, scale: 2),
                        DeferredIncomeTaAdd = c.Decimal(precision: 18, scale: 2),
                        Inventoryreduction = c.Decimal(precision: 18, scale: 2),
                        ReceivableItemLosses = c.Decimal(precision: 18, scale: 2),
                        PayablesAdd = c.Decimal(precision: 18, scale: 2),
                        Other = c.Decimal(precision: 18, scale: 2),
                        OperatingCashFlowsNet = c.Decimal(precision: 18, scale: 2),
                        CapitalDebt = c.Decimal(precision: 18, scale: 2),
                        CorporateBondInYear = c.Decimal(precision: 18, scale: 2),
                        FinancingFixedAssets = c.Decimal(precision: 18, scale: 2),
                        EndingBalance = c.Decimal(precision: 18, scale: 2),
                        BeginBalance = c.Decimal(precision: 18, scale: 2),
                        CashEquivalentsEndingBalance = c.Decimal(precision: 18, scale: 2),
                        CashEquivalentsBeginBalance = c.Decimal(precision: 18, scale: 2),
                        CashEquivalentsNetIncrease = c.Decimal(precision: 18, scale: 2),
                        FinancialAffairsId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_FinancialAffairs", t => t.FinancialAffairsId)
                .Index(t => t.FinancialAffairsId);
            
            CreateTable(
                "dbo.CUST_InstitutionIncome",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        财政补助收入 = c.Decimal(precision: 18, scale: 2),
                        上级补助收入 = c.Decimal(precision: 18, scale: 2),
                        附属单位缴款 = c.Decimal(precision: 18, scale: 2),
                        事业收入 = c.Decimal(precision: 18, scale: 2),
                        预算外资金收入 = c.Decimal(precision: 18, scale: 2),
                        其他收入 = c.Decimal(precision: 18, scale: 2),
                        事业收入小计 = c.Decimal(precision: 18, scale: 2),
                        经营收入 = c.Decimal(precision: 18, scale: 2),
                        经营收入小计 = c.Decimal(precision: 18, scale: 2),
                        拨入专款 = c.Decimal(precision: 18, scale: 2),
                        拨入专款小计 = c.Decimal(precision: 18, scale: 2),
                        收入总计 = c.Decimal(precision: 18, scale: 2),
                        拨出经费 = c.Decimal(precision: 18, scale: 2),
                        上缴上级支出 = c.Decimal(precision: 18, scale: 2),
                        对附属单位补助 = c.Decimal(precision: 18, scale: 2),
                        事业支出 = c.Decimal(precision: 18, scale: 2),
                        财政补助支出 = c.Decimal(precision: 18, scale: 2),
                        预算外资金支出 = c.Decimal(precision: 18, scale: 2),
                        销售税金 = c.Decimal(precision: 18, scale: 2),
                        销售税金1 = c.Decimal(precision: 18, scale: 2),
                        结转自筹基建 = c.Decimal(precision: 18, scale: 2),
                        事业支出小计 = c.Decimal(precision: 18, scale: 2),
                        经营支出 = c.Decimal(precision: 18, scale: 2),
                        经营支出小计 = c.Decimal(precision: 18, scale: 2),
                        拨出专款 = c.Decimal(precision: 18, scale: 2),
                        专款支出 = c.Decimal(precision: 18, scale: 2),
                        专款小计 = c.Decimal(precision: 18, scale: 2),
                        支出总计 = c.Decimal(precision: 18, scale: 2),
                        事业结余 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        正常收入结余 = c.Decimal(precision: 18, scale: 2),
                        收回以前年度事业支出 = c.Decimal(precision: 18, scale: 2),
                        经营结余 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        以前年度经营亏损 = c.Decimal(precision: 18, scale: 2),
                        结余分配 = c.Decimal(precision: 18, scale: 2),
                        应交所得税 = c.Decimal(precision: 18, scale: 2),
                        提取专用基金 = c.Decimal(precision: 18, scale: 2),
                        转入事业基金 = c.Decimal(precision: 18, scale: 2),
                        其他结余分配 = c.Decimal(precision: 18, scale: 2),
                        FinancialAffairsId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_FinancialAffairs", t => t.FinancialAffairsId)
                .Index(t => t.FinancialAffairsId);
            
            CreateTable(
                "dbo.CUST_InstitutionLiabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        现金 = c.Decimal(precision: 18, scale: 2),
                        银行存款 = c.Decimal(precision: 18, scale: 2),
                        应收票据 = c.Decimal(precision: 18, scale: 2),
                        应收账款 = c.Decimal(precision: 18, scale: 2),
                        预付账款 = c.Decimal(precision: 18, scale: 2),
                        其他应收款 = c.Decimal(precision: 18, scale: 2),
                        材料 = c.Decimal(precision: 18, scale: 2),
                        产成品 = c.Decimal(precision: 18, scale: 2),
                        对外投资 = c.Decimal(precision: 18, scale: 2),
                        固定资产 = c.Decimal(precision: 18, scale: 2),
                        无形资产 = c.Decimal(precision: 18, scale: 2),
                        资产合计 = c.Decimal(precision: 18, scale: 2),
                        拨出经费 = c.Decimal(precision: 18, scale: 2),
                        拨出专款 = c.Decimal(precision: 18, scale: 2),
                        专款支出 = c.Decimal(precision: 18, scale: 2),
                        事业支出 = c.Decimal(precision: 18, scale: 2),
                        经营支出 = c.Decimal(precision: 18, scale: 2),
                        销售税金1 = c.Decimal(precision: 18, scale: 2),
                        成本费用 = c.Decimal(precision: 18, scale: 2),
                        销售税金 = c.Decimal(precision: 18, scale: 2),
                        上缴上级支出 = c.Decimal(precision: 18, scale: 2),
                        对附属单位补助 = c.Decimal(precision: 18, scale: 2),
                        结转自筹基建 = c.Decimal(precision: 18, scale: 2),
                        支出合计 = c.Decimal(precision: 18, scale: 2),
                        资产部类总计 = c.Decimal(precision: 18, scale: 2),
                        借记款项 = c.Decimal(precision: 18, scale: 2),
                        应付票据 = c.Decimal(precision: 18, scale: 2),
                        应付账款 = c.Decimal(precision: 18, scale: 2),
                        预收账款 = c.Decimal(precision: 18, scale: 2),
                        其他应付款 = c.Decimal(precision: 18, scale: 2),
                        应缴预算款 = c.Decimal(precision: 18, scale: 2),
                        应缴财政专户款 = c.Decimal(precision: 18, scale: 2),
                        应交税金 = c.Decimal(precision: 18, scale: 2),
                        负债合计 = c.Decimal(precision: 18, scale: 2),
                        事业基金 = c.Decimal(precision: 18, scale: 2),
                        一般基金 = c.Decimal(precision: 18, scale: 2),
                        投资基金 = c.Decimal(precision: 18, scale: 2),
                        固定基金 = c.Decimal(precision: 18, scale: 2),
                        专用基金 = c.Decimal(precision: 18, scale: 2),
                        事业结余 = c.Decimal(precision: 18, scale: 2),
                        经营结余 = c.Decimal(precision: 18, scale: 2),
                        净资产合计 = c.Decimal(precision: 18, scale: 2),
                        财政补助收入 = c.Decimal(precision: 18, scale: 2),
                        上级补助收入 = c.Decimal(precision: 18, scale: 2),
                        拨入专款 = c.Decimal(precision: 18, scale: 2),
                        事业收入 = c.Decimal(precision: 18, scale: 2),
                        经营收入 = c.Decimal(precision: 18, scale: 2),
                        附属单位缴款 = c.Decimal(precision: 18, scale: 2),
                        其他收入 = c.Decimal(precision: 18, scale: 2),
                        收入合计 = c.Decimal(precision: 18, scale: 2),
                        负债部类总计 = c.Decimal(precision: 18, scale: 2),
                        FinancialAffairsId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_FinancialAffairs", t => t.FinancialAffairsId)
                .Index(t => t.FinancialAffairsId);
            
            CreateTable(
                "dbo.CUST_Liabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        MonetaryFund = c.Decimal(precision: 18, scale: 2),
                        TransactionAssets = c.Decimal(precision: 18, scale: 2),
                        NoteReceivable = c.Decimal(precision: 18, scale: 2),
                        AccountsReceivable = c.Decimal(precision: 18, scale: 2),
                        AdvancePayment = c.Decimal(precision: 18, scale: 2),
                        InterestReceivable = c.Decimal(precision: 18, scale: 2),
                        DividendsReceivable = c.Decimal(precision: 18, scale: 2),
                        OtherReceivables = c.Decimal(precision: 18, scale: 2),
                        Inventory = c.Decimal(precision: 18, scale: 2),
                        NonCurrentAssetsInYear = c.Decimal(precision: 18, scale: 2),
                        OtherCurrentAssets = c.Decimal(precision: 18, scale: 2),
                        TotalCurrentAssets = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CanSaleAsset = c.Decimal(precision: 18, scale: 2),
                        MaturityInvestment = c.Decimal(precision: 18, scale: 2),
                        LongEquity = c.Decimal(precision: 18, scale: 2),
                        LongReceivables = c.Decimal(precision: 18, scale: 2),
                        InvestmentRealEstate = c.Decimal(precision: 18, scale: 2),
                        FixedAssets = c.Decimal(precision: 18, scale: 2),
                        ConstructionProject = c.Decimal(precision: 18, scale: 2),
                        EngineeringMaterials = c.Decimal(precision: 18, scale: 2),
                        FixedAssetsLiquidation = c.Decimal(precision: 18, scale: 2),
                        ProductiveBiologicalAssets = c.Decimal(precision: 18, scale: 2),
                        OilGasAssets = c.Decimal(precision: 18, scale: 2),
                        IntangibleAssets = c.Decimal(precision: 18, scale: 2),
                        DevelopmentExpenditure = c.Decimal(precision: 18, scale: 2),
                        Goodwill = c.Decimal(precision: 18, scale: 2),
                        LongArepaidExpenses = c.Decimal(precision: 18, scale: 2),
                        DeferredTaxAssets = c.Decimal(precision: 18, scale: 2),
                        OtherNonCurrentAssets = c.Decimal(precision: 18, scale: 2),
                        TotalNonCurrentAssets = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAssets = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShortLoan = c.Decimal(precision: 18, scale: 2),
                        TransactionalFinancialLiabilities = c.Decimal(precision: 18, scale: 2),
                        NotesPayable = c.Decimal(precision: 18, scale: 2),
                        AccountsPayable = c.Decimal(precision: 18, scale: 2),
                        AccountsAdvance = c.Decimal(precision: 18, scale: 2),
                        InterestPayable = c.Decimal(precision: 18, scale: 2),
                        EmployeesSalary = c.Decimal(precision: 18, scale: 2),
                        PayTax = c.Decimal(precision: 18, scale: 2),
                        PayDividend = c.Decimal(precision: 18, scale: 2),
                        OtherPayable = c.Decimal(precision: 18, scale: 2),
                        NonCurrentLiabilitiesInYear = c.Decimal(precision: 18, scale: 2),
                        OtherCurrentLiabilities = c.Decimal(precision: 18, scale: 2),
                        TotalCurrentLiabilities = c.Decimal(precision: 18, scale: 2),
                        LongLoan = c.Decimal(precision: 18, scale: 2),
                        BondPayable = c.Decimal(precision: 18, scale: 2),
                        LongAcountsPayable = c.Decimal(precision: 18, scale: 2),
                        SpecialPayment = c.Decimal(precision: 18, scale: 2),
                        EstimatedLiabilities = c.Decimal(precision: 18, scale: 2),
                        DeferredTaxLiability = c.Decimal(precision: 18, scale: 2),
                        OtherNonCurrentLiabilities = c.Decimal(precision: 18, scale: 2),
                        TotalNonNurrentLiabilities = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalLiabilities = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidCapital = c.Decimal(precision: 18, scale: 2),
                        CapitalReserve = c.Decimal(precision: 18, scale: 2),
                        Stock = c.Decimal(precision: 18, scale: 2),
                        SurplusReserve = c.Decimal(precision: 18, scale: 2),
                        NoProfit = c.Decimal(precision: 18, scale: 2),
                        TotalOwnersEquity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalLiabilitiesCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinancialAffairsId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_FinancialAffairs", t => t.FinancialAffairsId)
                .Index(t => t.FinancialAffairsId);
            
            CreateTable(
                "dbo.CUST_Profit",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        BusinessIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingCost = c.Decimal(precision: 18, scale: 2),
                        SalesTax = c.Decimal(precision: 18, scale: 2),
                        SellingExpenses = c.Decimal(precision: 18, scale: 2),
                        ManagementExpenses = c.Decimal(precision: 18, scale: 2),
                        FinancialExpenses = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AssetsimpairmentLoss = c.Decimal(precision: 18, scale: 2),
                        FairIncome = c.Decimal(precision: 18, scale: 2),
                        NetInvestmentIncome = c.Decimal(precision: 18, scale: 2),
                        EnterpriseInvestmentIncome = c.Decimal(precision: 18, scale: 2),
                        OperatingProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperatingIncome = c.Decimal(precision: 18, scale: 2),
                        OperatingExpenditure = c.Decimal(precision: 18, scale: 2),
                        NonCurrentAssetsLoss = c.Decimal(precision: 18, scale: 2),
                        GrossProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTaxExpense = c.Decimal(precision: 18, scale: 2),
                        NetProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasicEarningsShare = c.Decimal(precision: 18, scale: 2),
                        DilutedEarningsShare = c.Decimal(precision: 18, scale: 2),
                        FinancialAffairsId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_FinancialAffairs", t => t.FinancialAffairsId)
                .Index(t => t.FinancialAffairsId);
            
            CreateTable(
                "dbo.CUST_Litigation",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ChargedSerialNumber = c.String(nullable: false, maxLength: 60),
                        ProsecuteName = c.String(nullable: false, maxLength: 80),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.String(nullable: false),
                        Result = c.String(nullable: false, maxLength: 100),
                        Reason = c.String(nullable: false, maxLength: 300),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_Manager",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false, maxLength: 80),
                        CertificateType = c.String(nullable: false, maxLength: 2),
                        CertificateCode = c.String(nullable: false, maxLength: 20),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_FamilyMember",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Relationship = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false, maxLength: 80),
                        CertificateType = c.String(nullable: false, maxLength: 2),
                        CertificateCode = c.String(nullable: false, maxLength: 20),
                        ManagerId = c.Guid(),
                        StockholderId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Manager", t => t.ManagerId)
                .ForeignKey("dbo.CUST_Stockholder", t => t.StockholderId)
                .Index(t => t.ManagerId)
                .Index(t => t.StockholderId);
            
            CreateTable(
                "dbo.CUST_Parent",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SuperInstitutionsName = c.String(nullable: false, maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_Stockholder",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShareholdersType = c.String(nullable: false, maxLength: 1),
                        ShareholdersName = c.String(nullable: false, maxLength: 80),
                        SharesProportion = c.Decimal(nullable: false, precision: 10, scale: 2),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateIndex("dbo.LOAN_CreditContranct", "OrganizationId");
            AddForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOAN_CreditContranct", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FamilyMember", "StockholderId", "dbo.CUST_Stockholder");
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager");
            DropForeignKey("dbo.CUST_Litigation", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_Profit", "FinancialAffairsId", "dbo.CUST_FinancialAffairs");
            DropForeignKey("dbo.CUST_Liabilities", "FinancialAffairsId", "dbo.CUST_FinancialAffairs");
            DropForeignKey("dbo.CUST_InstitutionLiabilities", "FinancialAffairsId", "dbo.CUST_FinancialAffairs");
            DropForeignKey("dbo.CUST_InstitutionIncome", "FinancialAffairsId", "dbo.CUST_FinancialAffairs");
            DropForeignKey("dbo.CUST_CashFlow", "FinancialAffairsId", "dbo.CUST_FinancialAffairs");
            DropForeignKey("dbo.CUST_BigEvent", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropIndex("dbo.LOAN_CreditContranct", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Stockholder", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Parent", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_FamilyMember", new[] { "StockholderId" });
            DropIndex("dbo.CUST_FamilyMember", new[] { "ManagerId" });
            DropIndex("dbo.CUST_Manager", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Litigation", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Profit", new[] { "FinancialAffairsId" });
            DropIndex("dbo.CUST_Liabilities", new[] { "FinancialAffairsId" });
            DropIndex("dbo.CUST_InstitutionLiabilities", new[] { "FinancialAffairsId" });
            DropIndex("dbo.CUST_InstitutionIncome", new[] { "FinancialAffairsId" });
            DropIndex("dbo.CUST_CashFlow", new[] { "FinancialAffairsId" });
            DropIndex("dbo.CUST_FinancialAffairs", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_BigEvent", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_AssociatedEnterprise", new[] { "OrganizationId" });
            DropTable("dbo.CUST_Stockholder");
            DropTable("dbo.CUST_Parent");
            DropTable("dbo.CUST_FamilyMember");
            DropTable("dbo.CUST_Manager");
            DropTable("dbo.CUST_Litigation");
            DropTable("dbo.CUST_Profit");
            DropTable("dbo.CUST_Liabilities");
            DropTable("dbo.CUST_InstitutionLiabilities");
            DropTable("dbo.CUST_InstitutionIncome");
            DropTable("dbo.CUST_CashFlow");
            DropTable("dbo.CUST_FinancialAffairs");
            DropTable("dbo.CUST_BigEvent");
            DropTable("dbo.CUST_AssociatedEnterprise");
            DropTable("dbo.CUST_Organization");
        }
    }
}
