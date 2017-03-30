namespace Core.Entities.Finance.Partners
{
    using System;
    using Core.Entities;
    using Core.Interfaces;

    public enum LockoutEnum : byte
    {
        启用 = 1,
        禁用 = 2
    }

    /// <summary>
    /// 合作商用户
    /// </summary>
    public class NewPartnerUser : Entity, IAggregateRoot
    {
        protected NewPartnerUser()
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 合作商标识
        /// </summary>
        public Guid PartnerId { get; set; }

        public DateTime CreatedDate { get; protected set; }

        public UserTypeEnum? UserType { get; } //// => AppUser.UserType;

        public LockoutEnum LockoutEnabled => AppUser.LockoutEnabled ? LockoutEnum.禁用 : LockoutEnum.启用;

        public virtual AppUser AppUser { get; protected set; }

        public NewPartnerUser CreateInstance(string name, string pwd)
        {
            var partnerUser = new NewPartnerUser() { Name = name, Pwd = pwd };

            ////partnerUser.AppUser = new AppUser() { UserType = UserTypeEnum.合作商 };

            return partnerUser;
        }

        public void AllowCreateDate()
            => CreatedDate = DateTime.Now;
    }
}
