namespace Core.Interfaces.Repositories
{
    using System;
    using Entities;
    using Entities.Flow;
    using X.PagedList;

    public interface IInstanceRepository : IRepository<Instance>
    {
        /// <summary>
        /// 待办列表
        /// </summary>
        /// <param name="currentUser">当前用户</param>
        /// <param name="searchString">搜索字符串</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="flowId">所属流程</param>
        /// <param name="currentNodeId">所属节点</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        IPagedList<Instance> DoingPagedList(AppUser currentUser, string searchString, int page, int size, Guid? flowId = null, Guid? currentNodeId = null, DateTime? beginTime = null, DateTime? endTime = null);

        /// <summary>
        /// 已办列表
        /// </summary>
        /// <param name="currentUser">当前用户</param>
        /// <param name="searchString">搜索字符串</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="flowId">所属流程</param>
        /// <param name="currentNodeId">所属节点</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="status">流程状态</param>
        /// <returns></returns>
        IPagedList<Instance> DonePagedList(AppUser currentUser, string searchString, int page, int size, Guid? flowId = null, Guid? currentNodeId = null, DateTime? beginTime = null, DateTime? endTime = null, InstanceStatusEnum? status = null);
    }
}
