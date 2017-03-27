namespace Core.Entities.Finance.Partners
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.Finance.Financial;
    using Core.Interfaces;

    /// <summary>
    /// 合作商
    /// </summary>
    public class NewPartner : Entity, IAggregateRoot, IDeleteable
    {
        protected NewPartner()
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string PrincipalPerson { get; set; }

        /// <summary>
        /// 合作时间(开始)
        /// </summary>
        public DateTime CooperationTimeStart { get; set; }

        /// <summary>
        /// 合作时间（结束）
        /// </summary>
        public DateTime CooperationTimeEnd { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<PartnerUser> PartnerUsers { get; set; } = new HashSet<PartnerUser>();

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<NewProduce> Produces { get; set; } = new HashSet<NewProduce>();

        public bool IsDelete { get; set; } = false;

        public void AllowCreateDate()
            => CreatedDate = DateTime.Now;
    }
}
