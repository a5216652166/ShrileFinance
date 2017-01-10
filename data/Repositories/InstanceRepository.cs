namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class InstanceRepository : BaseRepository<Instance>, IInstanceRepository
    {
        public InstanceRepository(MyContext context) : base(context)
        {
        }

        public IPagedList<Instance> DoingPagedList(AppUser currentUser, string searchString, int page, int size, Guid? flowId = null, Guid? currentNodeId = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            // 筛选 1.状态为正常
            //      2.当前用户的角色可处理的节点
            //      3.该实例限定于角色而非用户
            var instances = GetAll(m =>
                m.Status == InstanceStatusEnum.正常
                && m.CurrentNode.RoleId == currentUser.RoleId
                && (m.CurrentUserId == null || m.CurrentUserId == currentUser.Id));

            // 标题模糊搜索
            if (!string.IsNullOrEmpty(searchString))
            {
                instances = instances.Where(m => m.Title.Contains(searchString));
            }

            // 流程筛选
            if (flowId.HasValue)
            {
                instances = instances.Where(m => m.FlowId == flowId);
            }

            // 节点筛选
            if (currentNodeId.HasValue)
            {
                instances = instances.Where(m => m.CurrentNodeId == currentNodeId);
            }

            // 开始时间筛选
            if (beginTime.HasValue)
            {
                instances = instances.Where(m => m.StartTime >= beginTime);
            }

            // 结束时间筛选
            if (endTime.HasValue)
            {
                instances = instances.Where(m => m.StartTime < endTime);
            }

            // 排序(发起时间降序)
            instances = instances.OrderByDescending(m => m.StartTime);

            // 分页查询
            return instances.ToPagedList(page, size);
        }

        public IPagedList<Instance> DonePagedList(AppUser currentUser, string searchString, int page, int size, Guid? flowId = null, Guid? currentNodeId = null, DateTime? beginTime = null, DateTime? endTime = null, InstanceStatusEnum? status = null)
        {
            // 筛选 1.获取当前用户处理过的流程
            var instances = GetAll(m =>
                m.Logs.Any(n => n.ProcessUserId == currentUser.Id));

            // 标题模糊搜索
            if (!string.IsNullOrEmpty(searchString))
            {
                instances = instances.Where(m => m.Title.Contains(searchString));
            }

            // 流程筛选
            if (flowId.HasValue)
            {
                instances = instances.Where(m => m.FlowId == flowId);
            }

            // 节点筛选
            if (currentNodeId.HasValue)
            {
                instances = instances.Where(m => m.CurrentNodeId == currentNodeId);
            }

            // 开始时间筛选
            if (beginTime.HasValue)
            {
                instances = instances.Where(m => m.StartTime >= beginTime);
            }

            // 结束时间筛选
            if (endTime.HasValue)
            {
                instances = instances.Where(m => m.StartTime < endTime);
            }

            // 状态筛选
            if (status.HasValue)
            {
                instances = instances.Where(m => m.Status == status);
            }

            // 排序(处理时间降序)
            instances = instances.OrderByDescending(m => m.ProcessTime);

            // 分页查询
            return instances.ToPagedList(page, size);
        }
    }
}
