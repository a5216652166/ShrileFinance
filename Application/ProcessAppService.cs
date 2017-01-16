namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Flow;
    using Core.Entities.Identity;
    using Core.Exceptions;
    using Core.Interfaces.Repositories;
    using ViewModels.ProcessViewModels;
    using X.PagedList;

    /// <summary>
    /// 流程应用服务
    /// </summary>
    public class ProcessAppService
    {
        private readonly IFlowRepository flowRepository;
        private readonly IInstanceRepository instanceReopsitory;
        private readonly IFormRepository formRepository;
        private readonly IPartnerRepository partnerRepository;
        private readonly IFinanceRepository financeRepository;
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;
        private readonly FinanceScriptAppService scriptService;

        public ProcessAppService(
            IFlowRepository flowRepository,
            IInstanceRepository instanceReopsitory,
            IFormRepository formRepository,
            IPartnerRepository partnerRepository,
            IFinanceRepository financeRepository,
            FinanceScriptAppService scriptService,
            AppUserManager userManager,
            AppRoleManager roleManager)
        {
            this.flowRepository = flowRepository;
            this.instanceReopsitory = instanceReopsitory;
            this.formRepository = formRepository;
            this.partnerRepository = partnerRepository;
            this.financeRepository = financeRepository;
            this.scriptService = scriptService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// 获取当前登录的用户
        /// </summary>
        protected AppUser CurrentUser => userManager.CurrentUser();

        /// <summary>
        /// 发起流程
        /// </summary>
        /// <param name="flowId">流程标识</param>
        /// <returns>流程实例标识</returns>
        public Guid StartNew(Guid flowId)
        {
            var instance = GetInstance(null);

            return instance.Id;
        }

        public Guid StartNew(ProcessPostedViewModel.ProcessTypeEnum? processType)
        {
            var instance = GetInstance(processType);

            return instance.Id;
        }

        /// <summary>
        /// 流转
        /// </summary>
        /// <param name="model">提交的数据</param>
        public void Process(ProcessPostedViewModel model)
        {
            var instance = instanceReopsitory.Get(model.InstanceId);
            var action = instance.CurrentNode.Actions.Single(m => m.Id == model.ActionId);

            if ((instance.CurrentUser != CurrentUser && instance.CurrentUser != null) ||
                (instance.Status != InstanceStatusEnum.正常))
            {
                throw new InvalidOperationAppException("无法操作该流程.");
            }

            // 动态调用业务方法
            if (!string.IsNullOrEmpty(action.Method))
            {
                if (string.IsNullOrEmpty(model.Data))
                {
                    throw new ArgumentNullAppException(nameof(model.Data));
                }

                scriptService.Instance = instance;
                scriptService.Data = Newtonsoft.Json.Linq.JObject.Parse(model.Data);

                var method = scriptService.GetType().GetMethod(action.Method);

                method.Invoke(scriptService, null);
            }

            // 流转
            AppUser user;

            switch (action.AllocationType)
            {
                case ActionAllocationEnum.指定:
                    var finance = financeRepository.Get(instance.RootKey.Value);

                    var partner = finance.CreateOf;

                    user = partner.Approvers.Single(m => m.RoleId == action.Transfer.RoleId);
                    break;
                case ActionAllocationEnum.记录:
                    user = instance.Logs.Last(m => m.NodeId == action.TransferId).ProcessUser;
                    break;
                case ActionAllocationEnum.发起者:
                    user = instance.StartUser;
                    break;
                case ActionAllocationEnum.无:
                    user = null;
                    break;
                case ActionAllocationEnum.渠道经理:
                    var partner1 = partnerRepository.GetByUser(CurrentUser);
                    user = partner1.Accounts.First(m => m.RoleId == action.Transfer.RoleId);
                    break;
                default:
                    throw new InvalidOperationAppException("创建寻找用户策略失败!");
            }

            if (action.Transfer != null)
            {
                instance.CurrentNode = action.Transfer;
            }

            instance.CurrentUserId = user?.Id;

            if (action.Type == ActionTypeEnum.完成)
            {
                instance.Status = InstanceStatusEnum.完成;
            }
            else if (action.Type == ActionTypeEnum.终止)
            {
                instance.Status = InstanceStatusEnum.终止;
            }

            if (instance.Status != InstanceStatusEnum.正常)
            {
                instance.EndTime = DateTime.Now;
            }

            instance.Logs.Add(new Log
            {
                Node = action.Node,
                Action = action,
                ProcessUser = CurrentUser,
                ProcessTime = DateTime.Now,
                Opinion = new AuditOpinion
                {
                    ExnernalOpinion = model.ExnernalOpinion,
                    InternalOpinion = model.InternalOpinion
                }
            });

            instanceReopsitory.Modify(instance);
            instanceReopsitory.Commit();
        }

        /// <summary>
        /// 撤回
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        public void Withdraw(Guid instanceId)
        {
            var instance = instanceReopsitory.Get(instanceId);

            if (instance.Logs.Count > 0)
            {
                if (instance.Status != InstanceStatusEnum.正常)
                {
                    throw new InvalidOperationAppException("流程已结束，无法撤回。");
                }

                var lastLog = instance.Logs.Last();

                if (lastLog.ProcessUser != CurrentUser)
                {
                    throw new InvalidOperationAppException("流程已被其他用户处理，无法撤回流程。");
                }

                instance.CurrentNode = lastLog.Node;
                instance.CurrentUser = lastLog.ProcessUser;
                instance.Logs.Remove(lastLog);

                instanceReopsitory.Modify(instance);
            }
            else
            {
                if (instance.StartUser != CurrentUser)
                {
                    throw new InvalidOperationAppException("您不是流程的发起者，无法撤回流程。");
                }
                else
                {
                    instanceReopsitory.Remove(instance);
                }
            }

            instanceReopsitory.Commit();
        }

        /// <summary>
        /// 待办列表
        /// </summary>
        /// <param name="searchString">标题、用户</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="currentNode">当前节点</param>
        /// <param name="beginTime">开始发起时间</param>
        /// <param name="endTime">结束发起时间</param>
        /// <returns></returns>
        public IPagedList<InstanceViewModel> DoingPagedList(string searchString, int page, int size, Guid? currentNode = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            ////RemoveErrorInstance();

            var instances = instanceReopsitory.DoingPagedList(CurrentUser, searchString, page, size, currentNodeId: currentNode, beginTime: beginTime, endTime: endTime);

            var instanceViewModels = Mapper.Map<IPagedList<InstanceViewModel>>(instances);

            return instanceViewModels;
        }

        /// <summary>
        /// 已办列表
        /// </summary>
        /// <param name="searchString">标题、用户</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="currentNode">当前节点</param>
        /// <param name="beginTime">开始发起时间</param>
        /// <param name="endTime">结束发起时间</param>
        /// <param name="status">流程状态</param>
        /// <returns></returns>
        public IPagedList<InstanceViewModel> DonePagedList(string searchString, int page, int size, Guid? currentNode = null, DateTime? beginTime = null, DateTime? endTime = null, InstanceStatusEnum? status = null)
        {
            var instances = instanceReopsitory.DonePagedList(CurrentUser, searchString, page, size, currentNodeId: currentNode, beginTime: beginTime, endTime: endTime, status: status);

            var instanceViewModels = Mapper.Map<IPagedList<InstanceViewModel>>(instances);

            return instanceViewModels;
        }

        /// <summary>
        /// 获取当前实例的所以表单和行为
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="forView">表单信息是否为查看视图的</param>
        /// <returns></returns>
        public FrameViewModel GetFrame(Guid instanceId, bool forView = false)
        {
            var frame = new FrameViewModel();

            var instance = instanceReopsitory.Get(instanceId);

            var nodeForms = formRepository.GetByNode(instance.CurrentNodeId.Value)
                .Select(m => new FormViewModel
                {
                    Id = m.FormId,
                    Name = m.Form.Name,
                    Link = m.Form.Link,
                    State = m.State,
                    IsHandler = m.IsHandler,
                    IsOpen = m.IsOpen
                });
            if (!forView)
            {
                frame.Actions = Mapper.Map<IEnumerable<ActionViewModel>>(instance.CurrentNode.Actions);
                frame.Forms = nodeForms;
            }
            else
            {
                var roleForms = formRepository.GetByRole(CurrentUser.RoleId)
                    .Select(m => new FormViewModel
                    {
                        Id = m.FormId,
                        Name = m.Form.Name,
                        Link = m.Form.Link,
                        State = m.State
                    });

                frame.Forms = roleForms.Intersect(nodeForms, new FormViewModelEquality());
            }

            frame.HasInnerOpinion = roleManager.FindByIdAsync(CurrentUser.RoleId).Result.Power < 4;
            frame.ExnerOpinions = instance.Logs.Select(m => new OpinionViewModel
            {
                ProcessUser = m.ProcessUser.Name,
                Node = m.Node.Name,
                Action = m.Action.Name,
                ProcessTime = m.ProcessTime,
                Opinion = m.Opinion.ExnernalOpinion
            });

            if (frame.HasInnerOpinion)
            {
                frame.InnerOpinions = instance.Logs.Select(m => new OpinionViewModel
                {
                    ProcessUser = m.ProcessUser.Name,
                    Node = m.Node.Name,
                    Action = m.Action.Name,
                    ProcessTime = m.ProcessTime,
                    Opinion = m.Opinion.InternalOpinion
                });
            }

            frame.RootKey = instance.RootKey;

            return frame;
        }

        /// <summary>
        /// 移除错误流程
        /// </summary>
        private void RemoveErrorInstance()
        {
            var errorInstances = instanceReopsitory.GetAll(m => m.RootKey == null || m.RootKey.Value == Guid.Empty);

            foreach (var item in errorInstances)
            {
                instanceReopsitory.Remove(item);
            }

            if (errorInstances.Count() > 0)
            {
                instanceReopsitory.Commit();
            }
        }

        private Instance GetInstance(ProcessPostedViewModel.ProcessTypeEnum? processType)
        {
            var flowId = string.Empty;

            switch (processType)
            {
                default:
                    throw new ArgumentNullAppException();
                case ProcessPostedViewModel.ProcessTypeEnum.融资:
                    flowId = "228C8C80-06A4-E611-80C5-507B9DE4A488";
                    break;
                case ProcessPostedViewModel.ProcessTypeEnum.机构:
                    flowId = "04824FE1-78D1-E611-80CA-507B9DE4A488";
                    break;
                case ProcessPostedViewModel.ProcessTypeEnum.授信:
                    flowId = "05824FE1-78D1-E611-80CA-507B9DE4A488";
                    break;
                case ProcessPostedViewModel.ProcessTypeEnum.借据:
                    flowId = "06824FE1-78D1-E611-80CA-507B9DE4A488";
                    break;
                case ProcessPostedViewModel.ProcessTypeEnum.还款:
                    flowId = "07824FE1-78D1-E611-80CA-507B9DE4A488";
                    break;
            }

            Instance instance = null;

            var instances = instanceReopsitory.GetAll().Where(m => m.RootKey == null && m.CurrentUser.Id == CurrentUser.Id && (int)m.ProcessType == (int)processType.Value).ToListAsync().Result;

            if (instances.Count == 0)
            {
                var flow = flowRepository.Get(Guid.Parse(flowId));

                var startNode = flow.Nodes.Single(m => m.Actions.Any(n => n.Type == ActionTypeEnum.发起));

                instance = new Instance
                {
                    Flow = flow,
                    CurrentNode = startNode,
                    CurrentUser = CurrentUser,
                    StartUser = CurrentUser,
                    StartTime = DateTime.Now,
                    Status = InstanceStatusEnum.正常
                };

                instanceReopsitory.Create(instance);
                instanceReopsitory.Commit();
            }
            else
            {
                instance = instances.Single();
            }

            return instance;
        }
    }
}
