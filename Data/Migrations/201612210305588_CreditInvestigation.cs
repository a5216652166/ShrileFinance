namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditInvestigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CIDG_Trace",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TraceDate = c.DateTime(nullable: false),
                        ReferenceId = c.Guid(nullable: false),
                        Type = c.Byte(nullable: false),
                        Name = c.String(maxLength: 20),
                        Status = c.Byte(nullable: false),
                        SerialNumber = c.Int(nullable: false),
                        DatagramFileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsDatagramFile", t => t.DatagramFileId)
                .Index(t => t.DatagramFileId);
            
            CreateTable(
                "dbo.AbsDatagramFile",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        SerialNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DebitInterestInfo_Id = c.Guid(),
                        GuaranteeBusinessInfo_Id = c.Guid(),
                        LoanBusinessInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsDatagram", t => t.DebitInterestInfo_Id)
                .ForeignKey("dbo.AbsDatagram", t => t.GuaranteeBusinessInfo_Id)
                .ForeignKey("dbo.AbsDatagram", t => t.LoanBusinessInfo_Id)
                .Index(t => t.DebitInterestInfo_Id)
                .Index(t => t.GuaranteeBusinessInfo_Id)
                .Index(t => t.LoanBusinessInfo_Id);
            
            CreateTable(
                "dbo.AbsDatagram",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbsRecord",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbsSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        信息记录长度1 = c.Int(),
                        信息记录类型1 = c.Int(),
                        借款人名称1 = c.String(),
                        贷款卡编号 = c.String(),
                        报表年份 = c.Int(),
                        报表类型 = c.Int(),
                        报表类型细分 = c.Int(),
                        审计事务所名称 = c.String(),
                        审计人员名称 = c.String(),
                        审计时间 = c.Int(),
                        信息记录操作类型 = c.Int(),
                        业务发生日期1 = c.Int(),
                        SaleGoodsCash = c.Decimal(precision: 18, scale: 2),
                        TaxesRefunds = c.Decimal(precision: 18, scale: 2),
                        ReceiveOperatingActivitiesCash = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitiesCashInflows = c.Decimal(precision: 18, scale: 2),
                        BuyGoodsCash = c.Decimal(precision: 18, scale: 2),
                        PayEmployeeCash = c.Decimal(precision: 18, scale: 2),
                        PayAllTaxes = c.Decimal(precision: 18, scale: 2),
                        PayOperatingActivitiesCash = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitiesCashOutflows = c.Decimal(precision: 18, scale: 2),
                        OperatingActivitieCashNet = c.Decimal(precision: 18, scale: 2),
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
                        InvestmentCashInflow = c.Decimal(precision: 18, scale: 2),
                        AbsorbInvestmentCash = c.Decimal(precision: 18, scale: 2),
                        GetLoanCash = c.Decimal(precision: 18, scale: 2),
                        GetFinancingCash = c.Decimal(precision: 18, scale: 2),
                        FinancingCashInflow = c.Decimal(precision: 18, scale: 2),
                        DebtRedemption = c.Decimal(precision: 18, scale: 2),
                        PayCashForDividend = c.Decimal(precision: 18, scale: 2),
                        PayFinancingCash = c.Decimal(precision: 18, scale: 2),
                        PayOtherFinancingCash = c.Decimal(precision: 18, scale: 2),
                        FinancingCashOutflow = c.Decimal(precision: 18, scale: 2),
                        FinancingNetCash = c.Decimal(precision: 18, scale: 2),
                        ExchangeRateChangeCash = c.Decimal(precision: 18, scale: 2),
                        CashIncrease5 = c.Decimal(precision: 18, scale: 2),
                        BeginCashBalance = c.Decimal(precision: 18, scale: 2),
                        FinalCashBalance6 = c.Decimal(precision: 18, scale: 2),
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
                        销售税金1 = c.Decimal(precision: 18, scale: 2),
                        结转自筹基建 = c.Decimal(precision: 18, scale: 2),
                        事业支出小计 = c.Decimal(precision: 18, scale: 2),
                        经营支出 = c.Decimal(precision: 18, scale: 2),
                        销售税金2 = c.Decimal(precision: 18, scale: 2),
                        经营支出小计 = c.Decimal(precision: 18, scale: 2),
                        拨出专款 = c.Decimal(precision: 18, scale: 2),
                        专款支出 = c.Decimal(precision: 18, scale: 2),
                        专款小计 = c.Decimal(precision: 18, scale: 2),
                        支出总计 = c.Decimal(precision: 18, scale: 2),
                        事业结余 = c.Decimal(precision: 18, scale: 2),
                        正常收入结余 = c.Decimal(precision: 18, scale: 2),
                        收回以前年度事业支出 = c.Decimal(precision: 18, scale: 2),
                        经营结余 = c.Decimal(precision: 18, scale: 2),
                        以前年度经营亏损 = c.Decimal(precision: 18, scale: 2),
                        结余分配 = c.Decimal(precision: 18, scale: 2),
                        应交所得税 = c.Decimal(precision: 18, scale: 2),
                        提取专用基金 = c.Decimal(precision: 18, scale: 2),
                        转入事业基金 = c.Decimal(precision: 18, scale: 2),
                        其他结余分配 = c.Decimal(precision: 18, scale: 2),
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
                        拨出经费1 = c.Decimal(precision: 18, scale: 2),
                        拨出专款1 = c.Decimal(precision: 18, scale: 2),
                        专款支出1 = c.Decimal(precision: 18, scale: 2),
                        事业支出1 = c.Decimal(precision: 18, scale: 2),
                        经营支出1 = c.Decimal(precision: 18, scale: 2),
                        成本费用 = c.Decimal(precision: 18, scale: 2),
                        销售税金 = c.Decimal(precision: 18, scale: 2),
                        上缴上级支出1 = c.Decimal(precision: 18, scale: 2),
                        对附属单位补助1 = c.Decimal(precision: 18, scale: 2),
                        结转自筹基建1 = c.Decimal(precision: 18, scale: 2),
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
                        事业结余1 = c.Decimal(precision: 18, scale: 2),
                        经营结余1 = c.Decimal(precision: 18, scale: 2),
                        净资产合计 = c.Decimal(precision: 18, scale: 2),
                        财政补助收入1 = c.Decimal(precision: 18, scale: 2),
                        上级补助收入1 = c.Decimal(precision: 18, scale: 2),
                        拨入专款1 = c.Decimal(precision: 18, scale: 2),
                        事业收入1 = c.Decimal(precision: 18, scale: 2),
                        经营收入1 = c.Decimal(precision: 18, scale: 2),
                        附属单位缴款1 = c.Decimal(precision: 18, scale: 2),
                        其他收入1 = c.Decimal(precision: 18, scale: 2),
                        收入合计 = c.Decimal(precision: 18, scale: 2),
                        负债部类总计 = c.Decimal(precision: 18, scale: 2),
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
                        TotalCurrentAssets = c.Decimal(precision: 18, scale: 2),
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
                        TotalNonCurrentAssets = c.Decimal(precision: 18, scale: 2),
                        TotalAssets = c.Decimal(precision: 18, scale: 2),
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
                        TotalNonNurrentLiabilities = c.Decimal(precision: 18, scale: 2),
                        TotalLiabilities = c.Decimal(precision: 18, scale: 2),
                        PaidCapital = c.Decimal(precision: 18, scale: 2),
                        CapitalReserve = c.Decimal(precision: 18, scale: 2),
                        Stock = c.Decimal(precision: 18, scale: 2),
                        SurplusReserve = c.Decimal(precision: 18, scale: 2),
                        NoProfit = c.Decimal(precision: 18, scale: 2),
                        TotalOwnersEquity = c.Decimal(precision: 18, scale: 2),
                        TotalLiabilitiesCapital = c.Decimal(precision: 18, scale: 2),
                        BusinessIncome = c.Decimal(precision: 18, scale: 2),
                        OperatingCost = c.Decimal(precision: 18, scale: 2),
                        SalesTax = c.Decimal(precision: 18, scale: 2),
                        SellingExpenses = c.Decimal(precision: 18, scale: 2),
                        ManagementExpenses = c.Decimal(precision: 18, scale: 2),
                        FinancialExpenses1 = c.Decimal(precision: 18, scale: 2),
                        AssetsimpairmentLoss = c.Decimal(precision: 18, scale: 2),
                        FairIncome = c.Decimal(precision: 18, scale: 2),
                        NetInvestmentIncome = c.Decimal(precision: 18, scale: 2),
                        EnterpriseInvestmentIncome = c.Decimal(precision: 18, scale: 2),
                        OperatingProfit = c.Decimal(precision: 18, scale: 2),
                        OperatingIncome = c.Decimal(precision: 18, scale: 2),
                        OperatingExpenditure = c.Decimal(precision: 18, scale: 2),
                        NonCurrentAssetsLoss = c.Decimal(precision: 18, scale: 2),
                        GrossProfit = c.Decimal(precision: 18, scale: 2),
                        IncomeTaxExpense = c.Decimal(precision: 18, scale: 2),
                        NetProfit1 = c.Decimal(precision: 18, scale: 2),
                        BasicEarningsShare = c.Decimal(precision: 18, scale: 2),
                        DilutedEarningsShare = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_BigEventSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BigEventNumber = c.String(maxLength: 60),
                        BigEventDescription = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_ConcernBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 8),
                        借款人名称 = c.String(maxLength: 80),
                        贷款卡编码 = c.String(maxLength: 16),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_LitigationSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChargedSerialNumber = c.String(maxLength: 60),
                        ProsecuteName = c.String(maxLength: 80),
                        Money = c.String(maxLength: 20),
                        DateTime = c.String(maxLength: 8),
                        Result = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_AssociatedEnterpriseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssociatedType = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_BaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerNumber = c.String(maxLength: 40),
                        ManagementerCode = c.String(maxLength: 20),
                        CustomerType = c.String(nullable: false, maxLength: 1),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizateCode = c.String(maxLength: 10),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        TaxpayerIdentifyIrsNumber = c.String(maxLength: 20),
                        TaxpayerIdentifyLandNumber = c.String(maxLength: 20),
                        LoanCardCode = c.String(maxLength: 16),
                        数据提取日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_FamilySegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MianName = c.String(maxLength: 80),
                        MainType = c.String(maxLength: 2),
                        MainCode = c.String(maxLength: 20),
                        Relationship = c.String(maxLength: 1),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_ManagerSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_OrganizationContactSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OfficeAddress = c.String(maxLength: 80),
                        ContactPhone = c.String(maxLength: 35),
                        FinancialContactPhone = c.String(maxLength: 35),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_OrganizationStateSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EnterpriseScale = c.String(maxLength: 1),
                        InstitutionsState = c.String(maxLength: 1),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_ParentSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SuperInstitutionsName = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_PropertySegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstitutionChName = c.String(maxLength: 80),
                        RegisterAddress = c.String(maxLength: 80),
                        RegisterAdministrativeDivision = c.String(maxLength: 6),
                        SetupDate = c.String(maxLength: 8),
                        CertificateDueDate = c.String(maxLength: 8),
                        BusinessScope = c.String(maxLength: 400),
                        RegisterCapital = c.String(maxLength: 10),
                        OrganizationCategory = c.String(maxLength: 1),
                        OrganizationCategorySubdivision = c.String(maxLength: 2),
                        EconomicSectorsClassification = c.String(maxLength: 5),
                        EconomicType = c.String(maxLength: 2),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_StockholderSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShareholdersType = c.String(maxLength: 1),
                        ShareholdersName = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        SharesProportion = c.String(maxLength: 10),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 2),
                        LoanCardCode = c.String(maxLength: 16),
                        CreditContractCode = c.String(maxLength: 60),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditContractAmountSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreditLimit = c.String(maxLength: 20),
                        CreditBalance = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditContractSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstitutionChName = c.String(maxLength: 80),
                        EffectiveDate = c.String(maxLength: 8),
                        ExpirationDate = c.String(maxLength: 8),
                        EffectiveStatus = c.String(maxLength: 1),
                        HasGuarantee = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_DebitInterestBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        信息记录长度 = c.String(maxLength: 4),
                        LoanCardCode = c.String(maxLength: 16),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_DebitInterestSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        欠息余额 = c.String(maxLength: 20),
                        欠息余额改变日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 2),
                        LoanCardCode = c.String(maxLength: 16),
                        CreditId = c.String(maxLength: 60),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeMortgageSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        抵押合同编号 = c.String(maxLength: 60),
                        MortgageNumber = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CreditcardCode = c.String(maxLength: 16),
                        AssessmentValue = c.String(maxLength: 20),
                        AssessmentDate = c.String(maxLength: 8),
                        AssessmentName = c.String(maxLength: 80),
                        AssessmentOrganizationCode = c.String(maxLength: 10),
                        SigningDate = c.String(maxLength: 8),
                        CollateralType = c.String(maxLength: 1),
                        Margin = c.String(maxLength: 20),
                        RegistrateAuthorit = c.String(maxLength: 80),
                        RegistrateDate = c.String(maxLength: 8),
                        CollateralInstruction = c.String(maxLength: 400),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteePledgeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        质押合同编号 = c.String(maxLength: 60),
                        PledgeNumber = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CreditcardCode = c.String(maxLength: 16),
                        CollateralValue = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        PledgeType = c.String(maxLength: 1),
                        Margin = c.String(maxLength: 20),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        保证合同编号 = c.String(maxLength: 60),
                        Name = c.String(maxLength: 80),
                        CreditcardCode = c.String(maxLength: 16),
                        Margin = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        GuaranteeForm = c.String(maxLength: 1),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_LoanSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        借据编号 = c.String(maxLength: 60),
                        Principle = c.String(maxLength: 20),
                        Balance = c.String(maxLength: 20),
                        SpecialDate = c.String(maxLength: 8),
                        MatureDate = c.String(maxLength: 8),
                        LoanBusinessTypes = c.String(maxLength: 1),
                        LoanForm = c.String(maxLength: 1),
                        LoanNature = c.String(maxLength: 1),
                        LoansTo = c.String(maxLength: 5),
                        LoanTypes = c.String(maxLength: 2),
                        FourCategoryAssetsClassification = c.String(maxLength: 2),
                        FiveCategoryAssetsClassification = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalGuaranteeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        保证合同编号 = c.String(maxLength: 60),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 1),
                        CertificateNumber = c.String(maxLength: 18),
                        Margin = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        GuaranteeForm = c.String(maxLength: 1),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalMortgageSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        抵押合同编号 = c.String(maxLength: 60),
                        MortgageNumber = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 1),
                        CertificateNumber = c.String(maxLength: 18),
                        AssessmentValue = c.String(maxLength: 20),
                        AssessmentDate = c.String(maxLength: 8),
                        AssessmentName = c.String(maxLength: 80),
                        AssessmentOrganizationCode = c.String(maxLength: 10),
                        SigningDate = c.String(maxLength: 8),
                        CollateralType = c.String(maxLength: 1),
                        Margin = c.String(maxLength: 20),
                        RegistrateAuthorit = c.String(maxLength: 80),
                        RegistrateDate = c.String(maxLength: 8),
                        CollateralInstruction = c.String(maxLength: 400),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalPledgeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        质押合同编号 = c.String(maxLength: 60),
                        PledgeNumber = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 1),
                        CertificateNumber = c.String(maxLength: 18),
                        CollateralValue = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        PledgeType = c.String(maxLength: 1),
                        Margin = c.String(maxLength: 20),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_RepaymentSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoanId = c.String(maxLength: 60),
                        DatePayment = c.String(maxLength: 8),
                        还款次数 = c.String(maxLength: 4),
                        PaymentTypes = c.String(maxLength: 2),
                        ActualPaymentPrincipal = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CIDG_RepaymentSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_NaturalPledgeSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_NaturalMortgageSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_NaturalGuaranteeSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_LoanSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_GuaranteeSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_GuaranteePledgeSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_GuaranteeMortgageSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_GuaranteeBaseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_DebitInterestSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_DebitInterestBaseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_CreditContractSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_CreditContractAmountSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_CreditBaseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_StockholderSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_PropertySegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_ParentSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_OrganizationStateSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_OrganizationContactSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_ManagerSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_FamilySegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_BaseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_AssociatedEnterpriseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_LitigationSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_ConcernBaseSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_BigEventSegment", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_Trace", "DatagramFileId", "dbo.AbsDatagramFile");
            DropForeignKey("dbo.AbsDatagramFile", "LoanBusinessInfo_Id", "dbo.AbsDatagram");
            DropForeignKey("dbo.AbsDatagramFile", "GuaranteeBusinessInfo_Id", "dbo.AbsDatagram");
            DropForeignKey("dbo.AbsDatagramFile", "DebitInterestInfo_Id", "dbo.AbsDatagram");
            DropIndex("dbo.CIDG_RepaymentSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_NaturalPledgeSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_NaturalMortgageSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_NaturalGuaranteeSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_LoanSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_GuaranteeSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_GuaranteePledgeSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_GuaranteeMortgageSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_GuaranteeBaseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_DebitInterestSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_DebitInterestBaseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_CreditContractSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_CreditContractAmountSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_CreditBaseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_StockholderSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_PropertySegment", new[] { "Id" });
            DropIndex("dbo.CIDG_ParentSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_OrganizationStateSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_OrganizationContactSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_ManagerSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_FamilySegment", new[] { "Id" });
            DropIndex("dbo.CIDG_BaseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_AssociatedEnterpriseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_LitigationSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_ConcernBaseSegment", new[] { "Id" });
            DropIndex("dbo.CIDG_BigEventSegment", new[] { "Id" });
            DropIndex("dbo.AbsDatagramFile", new[] { "LoanBusinessInfo_Id" });
            DropIndex("dbo.AbsDatagramFile", new[] { "GuaranteeBusinessInfo_Id" });
            DropIndex("dbo.AbsDatagramFile", new[] { "DebitInterestInfo_Id" });
            DropIndex("dbo.CIDG_Trace", new[] { "DatagramFileId" });
            DropTable("dbo.CIDG_RepaymentSegment");
            DropTable("dbo.CIDG_NaturalPledgeSegment");
            DropTable("dbo.CIDG_NaturalMortgageSegment");
            DropTable("dbo.CIDG_NaturalGuaranteeSegment");
            DropTable("dbo.CIDG_LoanSegment");
            DropTable("dbo.CIDG_GuaranteeSegment");
            DropTable("dbo.CIDG_GuaranteePledgeSegment");
            DropTable("dbo.CIDG_GuaranteeMortgageSegment");
            DropTable("dbo.CIDG_GuaranteeBaseSegment");
            DropTable("dbo.CIDG_DebitInterestSegment");
            DropTable("dbo.CIDG_DebitInterestBaseSegment");
            DropTable("dbo.CIDG_CreditContractSegment");
            DropTable("dbo.CIDG_CreditContractAmountSegment");
            DropTable("dbo.CIDG_CreditBaseSegment");
            DropTable("dbo.CIDG_StockholderSegment");
            DropTable("dbo.CIDG_PropertySegment");
            DropTable("dbo.CIDG_ParentSegment");
            DropTable("dbo.CIDG_OrganizationStateSegment");
            DropTable("dbo.CIDG_OrganizationContactSegment");
            DropTable("dbo.CIDG_ManagerSegment");
            DropTable("dbo.CIDG_FamilySegment");
            DropTable("dbo.CIDG_BaseSegment");
            DropTable("dbo.CIDG_AssociatedEnterpriseSegment");
            DropTable("dbo.CIDG_LitigationSegment");
            DropTable("dbo.CIDG_ConcernBaseSegment");
            DropTable("dbo.CIDG_BigEventSegment");
            DropTable("dbo.AbsSegment");
            DropTable("dbo.AbsRecord");
            DropTable("dbo.AbsDatagram");
            DropTable("dbo.AbsDatagramFile");
            DropTable("dbo.CIDG_Trace");
        }
    }
}
