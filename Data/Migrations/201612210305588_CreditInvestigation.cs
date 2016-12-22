namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditInvestigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CIDG_DatagramFile",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        SerialNumber = c.String(nullable: false, maxLength: 4),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_Datagram",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DatagramFileId = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CIDG_DatagramFile", t => t.DatagramFileId, cascadeDelete: true)
                .Index(t => t.DatagramFileId);
            
            CreateTable(
                "dbo.CIDG_Record",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DatagramId = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CIDG_Datagram", t => t.DatagramId, cascadeDelete: true)
                .Index(t => t.DatagramId);
            
            CreateTable(
                "dbo.AbsSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RecordId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CIDG_Record", t => t.RecordId, cascadeDelete: true)
                .Index(t => t.RecordId);
            
            CreateTable(
                "dbo.CIDG_Trace",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TraceDate = c.DateTime(nullable: false),
                        ReferenceId = c.Guid(nullable: false),
                        Type = c.Byte(nullable: false),
                        Name = c.String(maxLength: 200),
                        Status = c.Byte(nullable: false),
                        SerialNumber = c.Int(nullable: false),
                        DatagramFileId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CIDG_DatagramFile", t => t.DatagramFileId)
                .Index(t => t.DatagramFileId);
            
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
            
            CreateTable(
                "dbo.CIDG_BaseParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 2),
                        借款人名称 = c.String(maxLength: 80),
                        贷款卡编号 = c.String(maxLength: 16),
                        报表年份 = c.String(maxLength: 4),
                        报表类型 = c.String(maxLength: 2),
                        报表类型细分 = c.String(maxLength: 1),
                        审计事务所名称 = c.String(maxLength: 80),
                        审计人员名称 = c.String(maxLength: 30),
                        审计时间 = c.String(maxLength: 8),
                        信息记录操作类型 = c.String(maxLength: 1),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CashFlowParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SaleGoodsCash = c.String(maxLength: 20),
                        TaxesRefunds = c.String(maxLength: 20),
                        ReceiveOperatingActivitiesCash = c.String(maxLength: 20),
                        OperatingActivitiesCashInflows = c.String(maxLength: 20),
                        BuyGoodsCash = c.String(maxLength: 20),
                        PayEmployeeCash = c.String(maxLength: 20),
                        PayAllTaxes = c.String(maxLength: 20),
                        PayOperatingActivitiesCash = c.String(maxLength: 20),
                        OperatingActivitiesCashOutflows = c.String(maxLength: 20),
                        OperatingActivitieCashNet = c.String(maxLength: 20),
                        RecoveryInvestmentCash = c.String(maxLength: 20),
                        InvestmentIncomeCash = c.String(maxLength: 20),
                        RecoveryAssetsCash = c.String(maxLength: 20),
                        RecoveryChildrenCompanyCash = c.String(maxLength: 20),
                        OtherInvestmentCash = c.String(maxLength: 20),
                        CashInInvestmentActivities = c.String(maxLength: 20),
                        BuyAssetsCash = c.String(maxLength: 20),
                        InvestmentPaidCash = c.String(maxLength: 20),
                        GetChildrenComponyCash = c.String(maxLength: 20),
                        PayOtherInvestmentCash = c.String(maxLength: 20),
                        InvestmentCashOutflow = c.String(maxLength: 20),
                        InvestmentCashInflow = c.String(maxLength: 20),
                        AbsorbInvestmentCash = c.String(maxLength: 20),
                        GetLoanCash = c.String(maxLength: 20),
                        GetFinancingCash = c.String(maxLength: 20),
                        FinancingCashInflow = c.String(maxLength: 20),
                        DebtRedemption = c.String(maxLength: 20),
                        PayCashForDividend = c.String(maxLength: 20),
                        PayFinancingCash = c.String(maxLength: 20),
                        PayOtherFinancingCash = c.String(maxLength: 20),
                        FinancingCashOutflow = c.String(maxLength: 20),
                        FinancingNetCash = c.String(maxLength: 20),
                        ExchangeRateChangeCash = c.String(maxLength: 20),
                        CashIncrease5 = c.String(maxLength: 20),
                        BeginCashBalance = c.String(maxLength: 20),
                        FinalCashBalance6 = c.String(maxLength: 20),
                        NetProfit = c.String(maxLength: 20),
                        AssetImpairment = c.String(maxLength: 20),
                        AssetsDepreciation = c.String(maxLength: 20),
                        IntangibleAssetsAmortization = c.String(maxLength: 20),
                        LongPrepaidExpenses = c.String(maxLength: 20),
                        PrepaidExpensesLessen = c.String(maxLength: 20),
                        AccruedExpenses = c.String(maxLength: 20),
                        Assetloss = c.String(maxLength: 20),
                        FixedAssetsScrap = c.String(maxLength: 20),
                        FairChanges = c.String(maxLength: 20),
                        FinancialExpenses = c.String(maxLength: 20),
                        InvestmentLosses = c.String(maxLength: 20),
                        DeferredIncomeTaxLessen = c.String(maxLength: 20),
                        DeferredIncomeTaAdd = c.String(maxLength: 20),
                        Inventoryreduction = c.String(maxLength: 20),
                        ReceivableItemLosses = c.String(maxLength: 20),
                        PayablesAdd = c.String(maxLength: 20),
                        Other = c.String(maxLength: 20),
                        OperatingCashFlowsNet = c.String(maxLength: 20),
                        CapitalDebt = c.String(maxLength: 20),
                        CorporateBondInYear = c.String(maxLength: 20),
                        FinancingFixedAssets = c.String(maxLength: 20),
                        EndingBalance = c.String(maxLength: 20),
                        BeginBalance = c.String(maxLength: 20),
                        CashEquivalentsEndingBalance = c.String(maxLength: 20),
                        CashEquivalentsBeginBalance = c.String(maxLength: 20),
                        CashEquivalentsNetIncrease = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_IncomeExpenditureParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        财政补助收入 = c.String(maxLength: 20),
                        上级补助收入 = c.String(maxLength: 20),
                        附属单位缴款 = c.String(maxLength: 20),
                        事业收入 = c.String(maxLength: 20),
                        预算外资金收入 = c.String(maxLength: 20),
                        其他收入 = c.String(maxLength: 20),
                        事业收入小计 = c.String(maxLength: 20),
                        经营收入 = c.String(maxLength: 20),
                        经营收入小计 = c.String(maxLength: 20),
                        拨入专款 = c.String(maxLength: 20),
                        拨入专款小计 = c.String(maxLength: 20),
                        收入总计 = c.String(maxLength: 20),
                        拨出经费 = c.String(maxLength: 20),
                        上缴上级支出 = c.String(maxLength: 20),
                        对附属单位补助 = c.String(maxLength: 20),
                        事业支出 = c.String(maxLength: 20),
                        财政补助支出 = c.String(maxLength: 20),
                        预算外资金支出 = c.String(maxLength: 20),
                        销售税金1 = c.String(maxLength: 20),
                        结转自筹基建 = c.String(maxLength: 20),
                        事业支出小计 = c.String(maxLength: 20),
                        经营支出 = c.String(maxLength: 20),
                        销售税金2 = c.String(maxLength: 20),
                        经营支出小计 = c.String(maxLength: 20),
                        拨出专款 = c.String(maxLength: 20),
                        专款支出 = c.String(maxLength: 20),
                        专款小计 = c.String(maxLength: 20),
                        支出总计 = c.String(maxLength: 20),
                        事业结余 = c.String(maxLength: 20),
                        正常收入结余 = c.String(maxLength: 20),
                        收回以前年度事业支出 = c.String(maxLength: 20),
                        经营结余 = c.String(maxLength: 20),
                        以前年度经营亏损 = c.String(maxLength: 20),
                        结余分配 = c.String(maxLength: 20),
                        应交所得税 = c.String(maxLength: 20),
                        提取专用基金 = c.String(maxLength: 20),
                        转入事业基金 = c.String(maxLength: 20),
                        其他结余分配 = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_LiabilitiesParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MonetaryFund = c.String(maxLength: 20),
                        TransactionAssets = c.String(maxLength: 20),
                        NoteReceivable = c.String(maxLength: 20),
                        AccountsReceivable = c.String(maxLength: 20),
                        AdvancePayment = c.String(maxLength: 20),
                        InterestReceivable = c.String(maxLength: 20),
                        DividendsReceivable = c.String(maxLength: 20),
                        OtherReceivables = c.String(maxLength: 20),
                        Inventory = c.String(maxLength: 20),
                        NonCurrentAssetsInYear = c.String(maxLength: 20),
                        OtherCurrentAssets = c.String(maxLength: 20),
                        TotalCurrentAssets = c.String(maxLength: 20),
                        CanSaleAsset = c.String(maxLength: 20),
                        MaturityInvestment = c.String(maxLength: 20),
                        LongEquity = c.String(maxLength: 20),
                        LongReceivables = c.String(maxLength: 20),
                        InvestmentRealEstate = c.String(maxLength: 20),
                        FixedAssets = c.String(maxLength: 20),
                        ConstructionProject = c.String(maxLength: 20),
                        EngineeringMaterials = c.String(maxLength: 20),
                        FixedAssetsLiquidation = c.String(maxLength: 20),
                        ProductiveBiologicalAssets = c.String(maxLength: 20),
                        OilGasAssets = c.String(maxLength: 20),
                        IntangibleAssets = c.String(maxLength: 20),
                        DevelopmentExpenditure = c.String(maxLength: 20),
                        Goodwill = c.String(maxLength: 20),
                        LongArepaidExpenses = c.String(maxLength: 20),
                        DeferredTaxAssets = c.String(maxLength: 20),
                        OtherNonCurrentAssets = c.String(maxLength: 20),
                        TotalNonCurrentAssets = c.String(maxLength: 20),
                        TotalAssets = c.String(maxLength: 20),
                        ShortLoan = c.String(maxLength: 20),
                        TransactionalFinancialLiabilities = c.String(maxLength: 20),
                        NotesPayable = c.String(maxLength: 20),
                        AccountsPayable = c.String(maxLength: 20),
                        AccountsAdvance = c.String(maxLength: 20),
                        InterestPayable = c.String(maxLength: 20),
                        EmployeesSalary = c.String(maxLength: 20),
                        PayTax = c.String(maxLength: 20),
                        PayDividend = c.String(maxLength: 20),
                        OtherPayable = c.String(maxLength: 20),
                        NonCurrentLiabilitiesInYear = c.String(maxLength: 20),
                        OtherCurrentLiabilities = c.String(maxLength: 20),
                        TotalCurrentLiabilities = c.String(maxLength: 20),
                        LongLoan = c.String(maxLength: 20),
                        BondPayable = c.String(maxLength: 20),
                        LongAcountsPayable = c.String(maxLength: 20),
                        SpecialPayment = c.String(maxLength: 20),
                        EstimatedLiabilities = c.String(maxLength: 20),
                        DeferredTaxLiability = c.String(maxLength: 20),
                        OtherNonCurrentLiabilities = c.String(maxLength: 20),
                        TotalNonNurrentLiabilities = c.String(maxLength: 20),
                        TotalLiabilities = c.String(maxLength: 20),
                        PaidCapital = c.String(maxLength: 20),
                        CapitalReserve = c.String(maxLength: 20),
                        Stock = c.String(maxLength: 20),
                        SurplusReserve = c.String(maxLength: 20),
                        NoProfit = c.String(maxLength: 20),
                        TotalOwnersEquity = c.String(maxLength: 20),
                        TotalLiabilitiesCapital = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_InstitutionLiabilitiesParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        现金 = c.String(maxLength: 20),
                        银行存款 = c.String(maxLength: 20),
                        应收票据 = c.String(maxLength: 20),
                        应收账款 = c.String(maxLength: 20),
                        预付账款 = c.String(maxLength: 20),
                        其他应收款 = c.String(maxLength: 20),
                        材料 = c.String(maxLength: 20),
                        产成品 = c.String(maxLength: 20),
                        对外投资 = c.String(maxLength: 20),
                        固定资产 = c.String(maxLength: 20),
                        无形资产 = c.String(maxLength: 20),
                        资产合计 = c.String(maxLength: 20),
                        拨出经费 = c.String(maxLength: 20),
                        拨出专款 = c.String(maxLength: 20),
                        专款支出 = c.String(maxLength: 20),
                        事业支出 = c.String(maxLength: 20),
                        经营支出 = c.String(maxLength: 20),
                        成本费用 = c.String(maxLength: 20),
                        销售税金 = c.String(maxLength: 20),
                        上缴上级支出 = c.String(maxLength: 20),
                        对附属单位补助 = c.String(maxLength: 20),
                        结转自筹基建 = c.String(maxLength: 20),
                        支出合计 = c.String(maxLength: 20),
                        资产部类总计 = c.String(maxLength: 20),
                        借记款项 = c.String(maxLength: 20),
                        应付票据 = c.String(maxLength: 20),
                        应付账款 = c.String(maxLength: 20),
                        预收账款 = c.String(maxLength: 20),
                        其他应付款 = c.String(maxLength: 20),
                        应缴预算款 = c.String(maxLength: 20),
                        应缴财政专户款 = c.String(maxLength: 20),
                        应交税金 = c.String(maxLength: 20),
                        负债合计 = c.String(maxLength: 20),
                        事业基金 = c.String(maxLength: 20),
                        一般基金 = c.String(maxLength: 20),
                        投资基金 = c.String(maxLength: 20),
                        固定基金 = c.String(maxLength: 20),
                        专用基金 = c.String(maxLength: 20),
                        事业结余 = c.String(maxLength: 20),
                        经营结余 = c.String(maxLength: 20),
                        净资产合计 = c.String(maxLength: 20),
                        财政补助收入 = c.String(maxLength: 20),
                        上级补助收入 = c.String(maxLength: 20),
                        拨入专款 = c.String(maxLength: 20),
                        事业收入 = c.String(maxLength: 20),
                        经营收入 = c.String(maxLength: 20),
                        附属单位缴款 = c.String(maxLength: 20),
                        其他收入 = c.String(maxLength: 20),
                        收入合计 = c.String(maxLength: 20),
                        负债部类总计 = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_ProfitsParagraph",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BusinessIncome = c.String(maxLength: 20),
                        OperatingCost = c.String(maxLength: 20),
                        SalesTax = c.String(maxLength: 20),
                        SellingExpenses = c.String(maxLength: 20),
                        ManagementExpenses = c.String(maxLength: 20),
                        FinancialExpenses = c.String(maxLength: 20),
                        AssetsimpairmentLoss = c.String(maxLength: 20),
                        FairIncome = c.String(maxLength: 20),
                        NetInvestmentIncome = c.String(maxLength: 20),
                        EnterpriseInvestmentIncome = c.String(maxLength: 20),
                        OperatingProfit = c.String(maxLength: 20),
                        OperatingIncome = c.String(maxLength: 20),
                        OperatingExpenditure = c.String(maxLength: 20),
                        NonCurrentAssetsLoss = c.String(maxLength: 20),
                        GrossProfit = c.String(maxLength: 20),
                        IncomeTaxExpense = c.String(maxLength: 20),
                        NetProfit = c.String(maxLength: 20),
                        BasicEarningsShare = c.String(maxLength: 20),
                        DilutedEarningsShare = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsSegment", t => t.Id)
                .Index(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CIDG_ProfitsParagraph", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_InstitutionLiabilitiesParagraph", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_LiabilitiesParagraph", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_IncomeExpenditureParagraph", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_CashFlowParagraph", "Id", "dbo.AbsSegment");
            DropForeignKey("dbo.CIDG_BaseParagraph", "Id", "dbo.AbsSegment");
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
            DropForeignKey("dbo.CIDG_Trace", "DatagramFileId", "dbo.CIDG_DatagramFile");
            DropForeignKey("dbo.CIDG_Datagram", "DatagramFileId", "dbo.CIDG_DatagramFile");
            DropForeignKey("dbo.CIDG_Record", "DatagramId", "dbo.CIDG_Datagram");
            DropForeignKey("dbo.AbsSegment", "RecordId", "dbo.CIDG_Record");
            DropIndex("dbo.CIDG_ProfitsParagraph", new[] { "Id" });
            DropIndex("dbo.CIDG_InstitutionLiabilitiesParagraph", new[] { "Id" });
            DropIndex("dbo.CIDG_LiabilitiesParagraph", new[] { "Id" });
            DropIndex("dbo.CIDG_IncomeExpenditureParagraph", new[] { "Id" });
            DropIndex("dbo.CIDG_CashFlowParagraph", new[] { "Id" });
            DropIndex("dbo.CIDG_BaseParagraph", new[] { "Id" });
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
            DropIndex("dbo.CIDG_Trace", new[] { "DatagramFileId" });
            DropIndex("dbo.AbsSegment", new[] { "RecordId" });
            DropIndex("dbo.CIDG_Record", new[] { "DatagramId" });
            DropIndex("dbo.CIDG_Datagram", new[] { "DatagramFileId" });
            DropTable("dbo.CIDG_ProfitsParagraph");
            DropTable("dbo.CIDG_InstitutionLiabilitiesParagraph");
            DropTable("dbo.CIDG_LiabilitiesParagraph");
            DropTable("dbo.CIDG_IncomeExpenditureParagraph");
            DropTable("dbo.CIDG_CashFlowParagraph");
            DropTable("dbo.CIDG_BaseParagraph");
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
            DropTable("dbo.CIDG_Trace");
            DropTable("dbo.AbsSegment");
            DropTable("dbo.CIDG_Record");
            DropTable("dbo.CIDG_Datagram");
            DropTable("dbo.CIDG_DatagramFile");
        }
    }
}
