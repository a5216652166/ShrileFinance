namespace Application.ViewModels.TreeGrid
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public enum CreditCountType : byte
    {
        授信 = 1,
        借据 = 2
    }

    public class CreditCountViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        [JsonProperty(PropertyName = "children")]
        public ICollection<CreditCountViewModel> Children { get; set; }
    }
}
