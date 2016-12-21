namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditInvestigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CIDG_MessageTrack",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        ReferenceId = c.Guid(nullable: false),
                        OperationType = c.Byte(nullable: false),
                        MessageStatus = c.Byte(nullable: false),
                        MessageData = c.String(),
                        TrackDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_BigEventSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BigEventNumber = c.String(maxLength: 60),
                        BigEventDescription = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_ConcernBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 8),
                        借款人名称 = c.String(maxLength: 80),
                        贷款卡编码 = c.String(maxLength: 16),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_LitigationSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ChargedSerialNumber = c.String(maxLength: 60),
                        ProsecuteName = c.String(maxLength: 80),
                        Money = c.String(maxLength: 20),
                        DateTime = c.String(maxLength: 8),
                        Result = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_AssociatedEnterpriseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AssociatedType = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_BaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_FamilySegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MianName = c.String(maxLength: 80),
                        MainType = c.String(maxLength: 2),
                        MainCode = c.String(maxLength: 20),
                        Relationship = c.String(maxLength: 1),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_ManagerSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(maxLength: 2),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_OrganizationContactSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        OfficeAddress = c.String(maxLength: 80),
                        ContactPhone = c.String(maxLength: 35),
                        FinancialContactPhone = c.String(maxLength: 35),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_OrganizationStateSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        EnterpriseScale = c.String(maxLength: 1),
                        InstitutionsState = c.String(maxLength: 1),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_ParentSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SuperInstitutionsName = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_PropertySegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CUST_StockholderSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShareholdersType = c.String(maxLength: 1),
                        ShareholdersName = c.String(maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        SharesProportion = c.String(maxLength: 10),
                        信息更新日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 2),
                        LoanCardCode = c.String(maxLength: 16),
                        CreditContractCode = c.String(maxLength: 60),
                        CreateDate = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditContractAmountSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreditLimit = c.String(maxLength: 20),
                        CreditBalance = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_CreditContractSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        InstitutionChName = c.String(maxLength: 80),
                        EffectiveDate = c.String(maxLength: 8),
                        ExpirationDate = c.String(maxLength: 8),
                        EffectiveStatus = c.String(maxLength: 1),
                        HasGuarantee = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_DebitInterestBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        信息记录长度 = c.String(maxLength: 4),
                        LoanCardCode = c.String(maxLength: 16),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_DebitInterestSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        欠息余额 = c.String(maxLength: 20),
                        欠息余额改变日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeBaseSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        信息记录长度 = c.String(maxLength: 4),
                        信息记录类型 = c.String(maxLength: 2),
                        LoanCardCode = c.String(maxLength: 16),
                        CreditId = c.String(maxLength: 60),
                        业务发生日期 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeMortgageSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteePledgeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_GuaranteeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        保证合同编号 = c.String(maxLength: 60),
                        Name = c.String(maxLength: 80),
                        CreditcardCode = c.String(maxLength: 16),
                        Margin = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        GuaranteeForm = c.String(maxLength: 1),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_LoanSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalGuaranteeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        保证合同编号 = c.String(maxLength: 60),
                        Name = c.String(maxLength: 80),
                        CertificateType = c.String(maxLength: 1),
                        CertificateNumber = c.String(maxLength: 18),
                        Margin = c.String(maxLength: 20),
                        SigningDate = c.String(maxLength: 8),
                        GuaranteeForm = c.String(maxLength: 1),
                        EffectiveState = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalMortgageSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_NaturalPledgeSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CIDG_RepaymentSegment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanId = c.String(maxLength: 60),
                        DatePayment = c.String(maxLength: 8),
                        还款次数 = c.String(maxLength: 4),
                        PaymentTypes = c.String(maxLength: 2),
                        ActualPaymentPrincipal = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
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
            DropTable("dbo.CUST_StockholderSegment");
            DropTable("dbo.CUST_PropertySegment");
            DropTable("dbo.CUST_ParentSegment");
            DropTable("dbo.CUST_OrganizationStateSegment");
            DropTable("dbo.CUST_OrganizationContactSegment");
            DropTable("dbo.CUST_ManagerSegment");
            DropTable("dbo.CUST_FamilySegment");
            DropTable("dbo.CUST_BaseSegment");
            DropTable("dbo.CIDG_AssociatedEnterpriseSegment");
            DropTable("dbo.CIDG_LitigationSegment");
            DropTable("dbo.CIDG_ConcernBaseSegment");
            DropTable("dbo.CIDG_BigEventSegment");
            DropTable("dbo.CIDG_MessageTrack");
        }
    }
}
