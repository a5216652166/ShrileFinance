namespace Core.Entities.Finance.Partners
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.Finance.Financial;
    using Core.Interfaces;

    /// <summary>
    /// 合作商
    /// </summary>
    public class Partner : Entity, IAggregateRoot, IDeleteable
    {
        protected Partner()
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<PartnerUser> PartnerUsers { get; protected set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ICollection<NewProduce> Produces { get; protected set; }

        public bool IsDelete { get; set; } = false;
    }
}
