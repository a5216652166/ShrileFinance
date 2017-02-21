namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 牌照登记至 枚举
    /// </summary>
    public enum LicenseRegistrationEnum
    {
        /// <summary>
        /// 承租人名下
        /// </summary>
        承租人名下 = 0,

        /// <summary>
        /// 渠道个人名下
        /// </summary>
        渠道个人名下 = 1,

        /// <summary>
        /// 渠道企业名下
        /// </summary>
        渠道企业名下 = 2,

        /// <summary>
        /// 晟融名下
        /// </summary>
        晟融名下 = 3
    }

    /// <summary>
    /// 客户类别 枚举
    /// </summary>
    public enum CustomerCategoryEnum
    {
        /// <summary>
        /// 优良职业
        /// </summary>
        优良职业 = 0,

        /// <summary>
        /// 标准受薪
        /// </summary>
        标准受薪 = 1,

        /// <summary>
        /// 自雇人士
        /// </summary>
        自雇人士 = 2,

        /// <summary>
        /// 自由职业
        /// </summary>
        自由职业 = 3
    }

    /// <summary>
    /// 户籍所在地 枚举
    /// </summary>
    public enum CensusRegisterSeatEnum
    {
        /// <summary>
        /// 本地户籍
        /// </summary>
        本地户籍 = 0,

        /// <summary>
        /// 异地户籍
        /// </summary>
        异地户籍 = 1
    }

    /// <summary>
    /// 居住 枚举
    /// </summary>
    public enum LiveEnum
    {
        /// <summary>
        /// 自有房产
        /// </summary>
        自有房产 = 0,

        /// <summary>
        /// 亲属房产
        /// </summary>
        亲属房产 = 1,

        /// <summary>
        /// 租房
        /// </summary>
        租房 = 2,

        /// <summary>
        /// 其它
        /// </summary>
        其它 = 3
    }

    /// <summary>
    /// 工作 枚举
    /// </summary>
    public enum WorkEnum
    {
        /// <summary>
        /// 同一单位5年以上
        /// </summary>
        同一单位5年以上 = 0,

        /// <summary>
        /// 营业执照满3年
        /// </summary>
        营业执照满3年 = 1,

        /// <summary>
        /// 其它
        /// </summary>
        其它 = 2
    }

    /// <summary>
    /// 家访 枚举
    /// </summary>
    public enum FamilyVisitEnum
    {
        /// <summary>
        /// 无需家访
        /// </summary>
        无需家访 = 0,

        /// <summary>
        /// 需要家访
        /// </summary>
        需要家访 = 1,

        /// <summary>
        /// 信息符合
        /// </summary>
        信息符合 = 2,

        /// <summary>
        /// 信息不符合
        /// </summary>
        信息不符合 = 3
    }

    /// <summary>
    /// 调查意见 枚举
    /// </summary>
    public enum SurveyOpinionEnum
    {
        /// <summary>
        /// 通过
        /// </summary>
        通过 = 0,

        /// <summary>
        /// 建议通过
        /// </summary>
        建议通过 = 1,

        /// <summary>
        /// 例外通过
        /// </summary>
        例外通过 = 2,

        /// <summary>
        /// 拒单
        /// </summary>
        拒单 = 3
    }

    /// <summary>
    /// 信审报告
    /// </summary>
    public class CreditExamineViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 递交资料渠道
        /// </summary>
        public string SubmitDataChannel { get; set; }

        /// <summary>
        /// 牌照登记至
        /// </summary>
        public LicenseRegistrationEnum LicenseRegistration { get; set; }

        /// <summary>
        /// 产品标识
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 产品种类
        /// </summary>
        public string ProductCategorie { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// 产品详解
        /// </summary>
        public string ProductExplain { get; set; }

        /// <summary>
        /// 承租人姓名
        /// </summary>
        public string LesseeName { get; set; }

        /// <summary>
        /// 承租人身份证
        /// </summary>
        public string LesseeIdCard { get; set; }

        /// <summary>
        /// 承租人手机号
        /// </summary>
        public string LesseeMobile { get; set; }

        /// <summary>
        /// 共借人姓名
        /// </summary>
        public string CommonBorrwerName { get; set; }
        
        /// <summary>
        /// 保证人姓名
        /// </summary>
        public IEnumerable<string> Guarantor { get; set; }

        /// <summary>
        /// 客户类别
        /// </summary>
        [Required(ErrorMessage = "客户类别 不可为空")]
        public CustomerCategoryEnum CustomerCategory { get; set; }

        /// <summary>
        /// 客户具体行业
        /// </summary>
        [Required(ErrorMessage = "客户具体行业 不可为空")]
        public string DetailedIndustry { get; set; }

        /// <summary>
        /// 户籍所在地
        /// </summary>
        public CensusRegisterSeatEnum CensusRegisterSeat { get; set; }

        /// <summary>
        /// 居住情况
        /// </summary>
        [Required(ErrorMessage = "居住情况 不可为空")]
        public string LivingSituation { get; set; }

        /// <summary>
        /// 工作情况
        /// </summary>
       [Required(ErrorMessage = "工作情况 不可为空")]
        public string WorkingCondition { get; set; }

        /// <summary>
        /// 收入来源类型（经营）
        /// </summary>
        public string IncomeSourceBusiness { get; set; }

        /// <summary>
        /// 收入来源类型（工资）
        /// </summary>
        public string IncomeSourceWage { get; set; }

        /// <summary>
        /// 月收入
        /// </summary>
        [Required(ErrorMessage = "月收入 不可为空")]
        public string MonthlyIncome { get; set; }

        /// <summary>
        /// 核算依据
        /// </summary>
        [Required(ErrorMessage = "核算依据 不可为空")]
        public string AccountingBasis { get; set; }

        /// <summary>
        /// 网核价格
        /// </summary>
        [Required(ErrorMessage = "网核价格 不可为空")]
        public string NetnuclearPrice { get; set; }

        /// <summary>
        /// 核批价格
        /// </summary>
        [Required(ErrorMessage = "核批价格 不可为空")]
        public string NuclearGroupPrice { get; set; }

        /// <summary>
        /// 终审额度
        /// </summary>
        [Required(ErrorMessage = "终审额度 不可为空")]
        public string FinalLine { get; set; }

        /// <summary>
        /// 信用状况
        /// </summary>
        [Required(ErrorMessage = "信用状况 不可为空")]
        [FinanceValid.CreditConditionRang(ErrorMessage = "信用状况 值错误")]
        public string CreditCondition { get; set; }

        /// <summary>
        /// 特别说明
        /// </summary>
        [Required(ErrorMessage = "特别说明 不可为空")]
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// 保证金5%
        /// </summary>
        public string Margin1 { get; set; }

        /// <summary>
        /// 保证金10%
        /// </summary>
        public string Margin2 { get; set; }

        /// <summary>
        /// 增加保证金原因
        /// </summary>
        public string IncreaseMarginReson { get; set; }

        /// <summary>
        /// 年龄区间
        /// </summary>
        [Required(ErrorMessage = "年龄 不可为空")]
        [FinanceValid.AgeRange(ErrorMessage = "年龄 值错误")]
        public string AgeRange { get; set; }

        /// <summary>
        /// 年龄（其他值）
        /// </summary>
        public string AgeRangeOther { get; set; }

        /// <summary>
        /// 婚姻
        /// </summary>
        public string MarriageState { get; set; }

        /// <summary>
        /// 居住
        /// </summary>
        public LiveEnum Live { get; set; }

        /// <summary>
        /// 房产
        /// </summary>
        [Required(ErrorMessage = "房产 不可为空")]
        [FinanceValid.RealEstate(ErrorMessage = "房产 值错误")]
        public string RealEstate { get; set; }

        /// <summary>
        /// 工作
        /// </summary>
        public WorkEnum Work { get; set; }

        /// <summary>
        /// 家访
        /// </summary>
        public FamilyVisitEnum FamilyVisit { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        [Required(ErrorMessage = "用途 不可为空")]
        public string CapitalUse { get; set; }

        /// <summary>
        /// 电询
        /// </summary>
        [Required(ErrorMessage = "电询 不可为空")]
        public string CableInquiry { get; set; }

        /// <summary>
        /// 结论
        /// </summary>
        [Required(ErrorMessage = "结论 不可为空")]
        public string Conclusion { get; set; }

        /// <summary>
        /// 调查意见
        /// </summary>
        public SurveyOpinionEnum SurveyOpinion { get; set; }

        /// <summary>
        /// 拒单 原因
        /// </summary>
        public string SurveyOpinionReson { get; set; }

        /// <summary>
        /// 初审人
        /// </summary>
        public KeyValuePair<string, string> TrialPerson { get; set; }

        /// <summary>
        /// 复审人
        /// </summary>
        public KeyValuePair<string, string> ReviewPerson { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public KeyValuePair<string, string> ApprovePerson { get; set; }

        /// <summary>
        /// 终审人
        /// </summary>
        public KeyValuePair<string, string> FinalPerson { get; set; }
    }
}
