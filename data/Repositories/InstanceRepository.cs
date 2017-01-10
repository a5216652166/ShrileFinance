﻿namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
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
            instances = FiterForTitle(instances, searchString);

            // 流程筛选
            instances = FiterForFlowId(instances, flowId);

            // 节点筛选
            instances = FiterForNodeId(instances, currentNodeId);

            // 开始时间筛选
            instances = FiterForBeginTime(instances, beginTime);

            // 结束时间筛选
            instances = FiterForEndTime(instances, endTime);

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
            instances = FiterForTitle(instances, searchString);

            // 流程筛选
            instances = FiterForFlowId(instances, flowId);

            // 节点筛选
            instances = FiterForNodeId(instances, currentNodeId);

            // 开始时间筛选
            instances = FiterForBeginTime(instances, beginTime);

            // 结束时间筛选
            instances = FiterForEndTime(instances, endTime);

            // 状态筛选
            instances = FiterForStatus(instances, status);

            // 排序(处理时间降序)
            instances = instances.OrderByDescending(m => m.ProcessTime);

            // 分页查询
            return instances.ToPagedList(page, size);
        }

        private IQueryable<Instance> FiterForTitle(IQueryable<Instance> refSource, string searchString)
        {
            searchString = searchString?.Trim();

            if (string.IsNullOrEmpty(searchString) || refSource == null)
            {
                return refSource;
            }

            var outSource = new List<Instance>();

            foreach (var item in refSource)
            {
                if (item.Title != null && item.Title.Contains(searchString))
                {
                    outSource.Add(item);
                }
            }

            return outSource.AsQueryable();
        }

        private IQueryable<Instance> FiterForFlowId(IQueryable<Instance> refSource, Guid? flowId) =>
            IsNull(refSource, flowId) ? refSource : refSource.Where(m => m.FlowId == flowId);

        private IQueryable<Instance> FiterForNodeId(IQueryable<Instance> refSource, Guid? nodeId) =>
            IsNull(refSource, nodeId) ? refSource : refSource.Where(m => m.CurrentNodeId == nodeId);

        private IQueryable<Instance> FiterForBeginTime(IQueryable<Instance> refSource, DateTime? beginTime) =>
            IsNull(refSource, beginTime) ? refSource : refSource.Where(m => m.StartTime == beginTime);

        private IQueryable<Instance> FiterForEndTime(IQueryable<Instance> refSource, DateTime? endTime) =>
            IsNull(refSource, endTime) ? refSource : refSource.Where(m => m.EndTime == endTime);

        private IQueryable<Instance> FiterForStatus(IQueryable<Instance> refSource, InstanceStatusEnum? status) =>
            IsNull(refSource, status) ? refSource : refSource.Where(m => m.Status == status);

        private bool IsNull<T>(IQueryable<Instance> refSource, T obj)
        {
            if (refSource != null && obj != null)
            {
                return false;
            }

            return true;
        }
    }
}
