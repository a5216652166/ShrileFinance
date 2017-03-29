////namespace Core.Entities.Finance
////{
////    using System;

////    /// <summary>
////    /// 信审报告
////    /// </summary>
////    public class CreditExamine : Entity
////    {
////        /// <summary>
////        /// 递交资料渠道
////        /// </summary>
////        public string SubmitDataChannel { get; set; }

////        /// <summary>
////        /// 牌照登记至
////        /// </summary>
////        public string LicenseRegistration { get; set; }

////        /// <summary>
////        /// 客户类别
////        /// </summary>
////        public string CustomerCategory { get; set; }

////        /// <summary>
////        /// 客户具体行业
////        /// </summary>
////        public string DetailedIndustry { get; set; }

////        /// <summary>
////        /// 户籍所在地
////        /// </summary>
////        public string CensusRegisterSeat { get; set; }

////        /// <summary>
////        /// 居住情况
////        /// </summary>
////        public string LivingSituation { get; set; }

////        /// <summary>
////        /// 工作情况
////        /// </summary>
////        public string WorkingCondition { get; set; }

////        /// <summary>
////        /// 收入来源类型（经营）
////        /// </summary>
////        public int? IncomeSourceBusiness { get; set; }

////        /// <summary>
////        /// 收入来源类型（工资）
////        /// </summary>
////        public int? IncomeSourceWage { get; set; }

////        /// <summary>
////        /// 月收入
////        /// </summary>
////        public decimal MonthlyIncome { get; set; }

////        /// <summary>
////        /// 核算依据
////        /// </summary>
////        public string AccountingBasis { get; set; }

////        /// <summary>
////        /// 网核价格
////        /// </summary>
////        public decimal NetnuclearPrice { get; set; }

////        /// <summary>
////        /// 核批价格
////        /// </summary>
////        public decimal NuclearGroupPrice { get; set; }

////        /// <summary>
////        /// 终审额度
////        /// </summary>
////        public decimal FinalLine { get; set; }

////        /// <summary>
////        /// 信用状况
////        /// </summary>
////        public string CreditCondition { get; set; }

////        /// <summary>
////        /// 特别说明
////        /// </summary>
////        public string SpecialInstructions { get; set; }

////        /// <summary>
////        /// 保证金
////        /// </summary>
////        public string Margin { get; set; }

////        /// <summary>
////        /// 增加保证金原因
////        /// </summary>
////        public string IncreaseMarginReson { get; set; }

////        /// <summary>
////        /// 年龄区间
////        /// </summary>
////        public string AgeRange { get; set; }

////        /// <summary>
////        /// 年龄（其他）
////        /// </summary>
////        public string AgeRangeOther { get; set; }

////        /// <summary>
////        /// 居住
////        /// </summary>
////        public string Live { get; set; }

////        /// <summary>
////        /// 房产
////        /// </summary>
////        public string RealEstate { get; set; }

////        /// <summary>
////        /// 工作
////        /// </summary>
////        public string Work { get; set; }

////        /// <summary>
////        /// 家访
////        /// </summary>
////        public string FamilyVisit { get; set; }

////        /// <summary>
////        /// 用途
////        /// </summary>
////        public string CapitalUse { get; set; }

////        /// <summary>
////        /// 电询
////        /// </summary>
////        public string CableInquiry { get; set; }

////        /// <summary>
////        /// 结论
////        /// </summary>
////        public string Conclusion { get; set; }

////        /// <summary>
////        /// 调查意见
////        /// </summary>
////        public string SurveyOpinion { get; set; }

////        /// <summary>
////        /// 拒单 原因
////        /// </summary>
////        public string SurveyOpinionReson { get; set; }

////        /// <summary>
////        /// 初审人
////        /// </summary>
////        public virtual AppUser TrialUser { get; set; }

////        /// <summary>
////        /// 复审人
////        /// </summary>
////        public virtual AppUser ReviewUser { get; set; }

////        /// <summary>
////        /// 审批人
////        /// </summary>
////        public virtual AppUser ApproveUser { get; set; }

////        /// <summary>
////        /// 终审人
////        /// </summary>
////        public virtual AppUser FinalUser { get; set; }
////    }
////}
