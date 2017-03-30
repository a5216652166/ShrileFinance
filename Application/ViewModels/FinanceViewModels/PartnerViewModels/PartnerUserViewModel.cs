namespace Application.ViewModels.FinanceViewModels.PartnerViewModels
{
    using System;
    using Core.Entities;
    using Core.Entities.Finance.Partners;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class PartnerUserViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserTypeEnum? UserType { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LockoutEnum LockoutEnabled { get; set; }
    }
}
