namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    /// <summary>
    /// 信审报告
    /// </summary>
    public class CreditExamineConfiguration : EntityTypeConfiguration<CreditExamine>
    {
        public CreditExamineConfiguration()
        {
            // 信审标识
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 递交资料渠道
            Property(m => m.SubmitDataChannel).HasMaxLength(200);

            // 牌照登记至
            Property(m => m.LicenseRegistration).HasMaxLength(20);

            // 客户类别
            Property(m => m.CustomerCategory).HasMaxLength(20);

            // 客户具体行业
            Property(m => m.DetailedIndustry).HasMaxLength(20);

            // 户籍所在地
            Property(m => m.CensusRegisterSeat).HasMaxLength(20);

            // 居住情况
            Property(m => m.LivingSituation).HasMaxLength(20);

            // 工作情况
            Property(m => m.WorkingCondition).HasMaxLength(20);

            // 收入来源类型（经营）
            Property(m => m.IncomeSourceBusiness);

            // 收入来源类型（工资）
            Property(m => m.IncomeSourceWage);

            // 月收入
            Property(m => m.MonthlyIncome);

            // 核算依据
            Property(m => m.AccountingBasis).HasMaxLength(20);

            // 网核价格
            Property(m => m.NetnuclearPrice);

            // 核批价格
            Property(m => m.NuclearGroupPrice);
            
            // 终审额度
            Property(m => m.FinalLine);

            // 信用状况
            Property(m => m.CreditCondition).HasMaxLength(10);

            // 特别说明
            Property(m => m.SpecialInstructions).HasMaxLength(200);
            
            // 保证金
            Property(m => m.Margin).HasMaxLength(20);

            // 增加保证金原因
            Property(m => m.IncreaseMarginReson).HasMaxLength(400);
            
            // 年龄区间
            Property(m => m.AgeRange).HasMaxLength(20);

            // 年龄（其他）
            Property(m => m.AgeRangeOther).HasMaxLength(20);
            
            // 居住
            Property(m => m.Live).HasMaxLength(20);
            
            // 房产
            Property(m => m.RealEstate).HasMaxLength(20);
            
            // 工作
            Property(m => m.Work).HasMaxLength(20);

            // 家访
            Property(m => m.FamilyVisit).HasMaxLength(20);
            
            // 用途
            Property(m => m.CapitalUse).HasMaxLength(400);

            // 电询
            Property(m => m.CableInquiry).HasMaxLength(400);

            // 结论
            Property(m => m.Conclusion).HasMaxLength(400);

            // 调查意见
            Property(m => m.SurveyOpinion).HasMaxLength(20);

            // 拒单 原因
            Property(m => m.SurveyOpinionReson).HasMaxLength(400);

            // 初审人标识
            HasOptional(m => m.TrialUser).WithMany()
                .Map(m => m.MapKey("TrialPersonId"));

            // 复审人标识
            HasOptional(m => m.ReviewUser).WithMany()
                .Map(m => m.MapKey("ReviewPersonId"));

            // 审批人标识
            HasOptional(m => m.ApproveUser).WithMany()
                .Map(m => m.MapKey("ApprovePersonId"));

            // 终审人标识
            HasOptional(m => m.FinalUser).WithMany()
                .Map(m => m.MapKey("FinalPersonId"));

            // 设置表名
            ToTable("FANC_CreditExamine");
        }
    }
}
