namespace Core.Entities.Finance.BranchOffices
{
    using Core.Interfaces;

    /// <summary>
    /// 分公司
    /// </summary>
    public class BranchOffice : Entity, IAggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; private set; }
    }
}
