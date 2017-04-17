namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Identity;
    using Core.Entities.Loan;
    using Core.Entities.Process;
    using Core.Exceptions;
    using Core.Interfaces.Repositories;
    using Core.Interfaces.Repositories.DatagramRepositories;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using Newtonsoft.Json.Linq;
    using ViewModels.ProcessViewModels;
    using X.PagedList;

    /// <summary>
    /// 流程应用服务
    /// </summary>
    public class InstanceAppService
    {
        private readonly IProcessRepository flowRepository;
        private readonly IInstanceRepository instanceReopsitory;
        private readonly IFormRepository formRepository;
        private readonly IPartnerRepository partnerRepository;
        private readonly IFinanceRepository financeRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IPaymentHistoryRepository paymentRepository;
        private readonly ICreditContractRepository creditContractRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ITraceRepostitory traceRepository;
        private readonly ProcessScriptAppService processScriptAppService;
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;

        public InstanceAppService(
            IProcessRepository flowRepository,
            IInstanceRepository instanceReopsitory,
            IFormRepository formRepository,
            IPartnerRepository partnerRepository,
            IFinanceRepository financeRepository,
            ILoanRepository loanRepository,
            IPaymentHistoryRepository paymentRepository,
            ICreditContractRepository creditContractRepository,
            IOrganizationRepository organizationRepository,
            ITraceRepostitory traceRepository,
            ProcessScriptAppService processScriptAppService,
            AppUserManager userManager,
            AppRoleManager roleManager)
        {
            this.flowRepository = flowRepository;
            this.instanceReopsitory = instanceReopsitory;
            this.formRepository = formRepository;
            this.partnerRepository = partnerRepository;
            this.financeRepository = financeRepository;
            this.loanRepository = loanRepository;
            this.creditContractRepository = creditContractRepository;
            this.organizationRepository = organizationRepository;
            this.traceRepository = traceRepository;
            this.paymentRepository = paymentRepository;
            this.processScriptAppService = processScriptAppService;
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
        /// <param name="processType">流程类型</param>
        /// <returns>流程实例标识</returns>
        public Guid StartNew(ProcessPostedViewModel.ProcessTypeEnum processType)
        {
            // 拦截非法流程发起请求
            InterceptIllegalRequest();

            // 流程标识
            var processId = Instance.GetProcessIdByType((ProcessTypeEnum)((int)processType));

            // 分配流程实例
            var instance = AllotInstance(processId);

            return instance.Id;
        }

        /// <summary>
        /// 流转
        /// </summary>
        /// <param name="model">提交的数据</param>
        public void Transfer(ProcessPostedViewModel model)
        {
            var instance = instanceReopsitory.Get(model.InstanceId);

            var action = instance.CurrentNode.Actions.Single(m => m.Id == model.ActionId);

            ////if ((instance.CurrentUser != CurrentUser && instance.CurrentUser != null) ||
            ////    (instance.Status != InstanceStatusEnum.正常))
            ////{
            ////    throw new InvalidOperationAppException("无法操作该流程.");
            ////}

            if (instance.Status != InstanceStatusEnum.正常)
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

                processScriptAppService.Instance = instance;
                processScriptAppService.Data = JObject.Parse(model.Data);

                var method = processScriptAppService.GetType().GetMethod(action.Method);

                method.Invoke(processScriptAppService, null);
            }

            // 流转
            var user = default(AppUser);

            switch (action.AllocationType)
            {
                case ActionAllocationEnum.指定:
                    if (instance.ProcessType == ProcessTypeEnum.融资)
                    {
                        // 若流转至总经理，直接设置用户为null;
                        var presidentRoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488";
                        if (action.Transfer.RoleId.Equals(presidentRoleId) == false)
                        {
                            // 合作商
                            var partner = financeRepository.Get(instance.RootKey.Value).CreateOf;

                            // 审核人
                            user = partner.Approvers.SingleOrDefault(m => m.RoleId == action.Transfer.RoleId);

                            // 客户经理
                            user = user ?? partner.Accounts.SingleOrDefault(m => m.RoleId == action.Transfer.RoleId && m.Id == instance.StartUserId);

                            if (user == default(AppUser) || user.LockoutEnabled)
                            {
                                throw new AppException(message: $"合作商{partner.Name}不存在正常启用的{action.Transfer.Role.Name}");
                            }
                        }
                    }
                    else if (action.TransferId != null)
                    {
                        // 根据角色设置下一位流程操作者(若存在同角色的多位用户，默认取第一位)
                        var userIds = from item in action.Transfer.Role.Users select item.UserId;
                        var users = userManager.Users.Where(item => userIds.Contains(item.Id) && item.LockoutEnabled == false);

                        if (users.Count() == 0)
                        {
                            throw new ArgumentNullAppException(message: $"系统中不存在正常启用的“{action.Transfer.Role.Name}”");
                        }

                        user = users.First();
                    }

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
                default:
                    throw new InvalidOperationAppException("创建寻找用户策略失败!");
            }

            instance.CurrentUserId = user?.Id;

            if (action.Transfer != null)
            {
                instance.CurrentNode = action.Transfer;
            }

            switch (action.Type)
            {
                case ActionTypeEnum.发起:
                    break;
                case ActionTypeEnum.流转:
                    break;
                case ActionTypeEnum.完成:
                    instance.Status = InstanceStatusEnum.完成;
                    break;
                case ActionTypeEnum.终止:
                    instance.Status = InstanceStatusEnum.终止;
                    break;
                default:
                    break;
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
        public void Revoke(Guid instanceId)
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
        /// 获取当前实例的所有表单和行为
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <param name="forView">表单信息是否为查看视图的</param>
        /// <returns></returns>
        public FrameViewModel GetFrame(Guid instanceId, bool forView = false)
        {
            var frame = new FrameViewModel();

            var instance = instanceReopsitory.Get(instanceId);

            var nodeForms = formRepository.GetByNode(instance.CurrentNodeId.Value)
                .OrderBy(m => m.Form.Sort)
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
        /// 分配流程实例
        /// </summary>
        /// <param name="processId">流程类型</param>
        /// <returns>流程实例</returns>
        private Instance AllotInstance(Guid processId)
        {
            // 流程实例
            Instance instance = null;

            // 获取指定用户下，指定类型的临时流程实例
            var instances = instanceReopsitory.GetAll(m => m.RootKey == null).ToList().Where(m => m.CurrentUserId == CurrentUser.Id && m.FlowId == processId).ToListAsync().Result;

            // 临时流程实例存在一个，则返回该流程实例，否则，新增流程实例（若存在多个，则清除）
            if (instances.Count == 1)
            {
                instance = instances.Single();
                instance.StartTime = DateTime.Now;

                instanceReopsitory.Modify(instance);
            }
            else
            {
                // 清除错误流程实例
                instances.ForEach(item =>
                {
                    instanceReopsitory.Remove(item);
                });

                var process = flowRepository.Get(processId);

                var startNode = process.Nodes.Single(m => m.Actions.Any(n => n.Type == ActionTypeEnum.发起));

                instance = new Instance
                {
                    Flow = process,
                    CurrentNode = startNode,
                    CurrentUser = CurrentUser,
                    StartUser = CurrentUser,
                    StartTime = DateTime.Now,
                    Status = InstanceStatusEnum.正常,
                };

                instanceReopsitory.Create(instance);
            }

            instanceReopsitory.Commit();

            return instance;
        }

        /// <summary>
        /// 拦截非法流程发起请求
        /// </summary>
        private void InterceptIllegalRequest()
        {
            // 当前用户的角色
            var curentRole = roleManager.FindByIdAsync(CurrentUser.RoleId).Result;

            // 若当前角色的标识与客户经理不同，则认为该请求非法
            if (!curentRole.Id.Equals("C342BEE1-05A4-E611-80C5-507B9DE4A488"))
            {
                throw new ArgumentOutOfRangeAppException(message: $"亲爱的{curentRole.Name}宝宝，您没有权限发起流程！");
            }
        }
    }
}
