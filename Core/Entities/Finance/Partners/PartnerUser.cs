namespace Core.Entities.Finance.Partners
{
    using Core.Interfaces;

    public enum LockoutEnum : byte
    {
        启用=1,
        禁用=2
    }

    /// <summary>
    /// 合作商用户
    /// </summary>
    public class PartnerUser : Entity, IAggregateRoot
    {
        protected PartnerUser()
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; protected set; }

        public LockoutEnum LockoutEnabled => AppUser.LockoutEnabled ? LockoutEnum.禁用 : LockoutEnum.启用;

        public virtual AppUser AppUser { get; protected set; }
    }
}
