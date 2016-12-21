namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Interfaces.Repositories.MessageRepository;
    using Core.Services.CreditInvestigation;
    using ViewModels.CreditInvesitigation.TraceViewModels;
    using ViewModels.Message;
    using X.PagedList;

    /// <summary>
    /// 报文追踪服务
    /// </summary>
    public class MessageAppService
    {
        private readonly IMessageTrackRepostitory respository;
        private readonly DatagramFactoryService factory;

        public MessageAppService(IMessageTrackRepostitory respository, DatagramFactoryService factory)
        {
            this.respository = respository;
            this.factory = factory;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="id">引用ID</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="name">默认名称</param>
        public void MessageTrack(Guid id, MessageOperationTypeEnum operationType, string name)
        {
            var messageTrack = respository.Get(id);

            if (messageTrack != null)
            {
                messageTrack.MessageData = PackagingMessageData(referenceId: id, operationType: operationType);
                respository.Modify(messageTrack);
            }
            else
            {
            //var serialNumber = SerialNumberGenerator.GetInstance(() => respository.Get()).GetNext();
                messageTrack = new MessageTrack() {
                    MessageStatus = MessageStatusEmum.待生成,
                    Name = name,
                    OperationType = operationType,
                    ReferenceId = id,
                    MessageData = PackagingMessageData(referenceId: id, operationType: operationType)
                };

                respository.Create(messageTrack);
            }

            ////var track = new MessageTrack()
            ////{
            ////    MessageStatus = MessageStatusEmum.待生成,
            ////    Name = name,
            ////    OperationType = operationType,
            ////    ReferenceId = id,
            ////};

            ////respository.Create(track);
            respository.Commit();
        }

        public void Generate()
        {
            var df = factory.Generate(new List<MessageTrack> {
                new MessageTrack { ReferenceId = Guid.Parse("0727FF76-8BC2-E611-80C7-507B9DE4A488"), OperationType = MessageOperationTypeEnum.借款 } });

            df.Packaging();
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<MessageTrackViewModel> GetPageList(string search, int page, int size)
        {
            var messageTrack = respository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                messageTrack = messageTrack.Where(m => m.Name.Contains(search));
            }

            messageTrack = messageTrack.OrderByDescending(m => m.Id);
            var pageList = messageTrack.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<MessageTrackViewModel>>(pageList);

            return models;
        }

        /// <summary>
        /// 修改名称后保存(修改Name)
        /// </summary>
        /// <param name="model">视图模型</param>
        public void ModifyName(ModifyNameViewModel model)
        {
            var trace = respository.Get(model.Id);

            trace.Name = model.Name;

            respository.Modify(trace);
            respository.Commit();
        }

        /// <summary>
        /// 封装报文数据
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="operationType">操作类型</param>
        /// <returns>报文数据</returns>
        private string PackagingMessageData(Guid referenceId, MessageOperationTypeEnum operationType)
        {
            var traces = new List<MessageTrack>() {
                new MessageTrack { ReferenceId = referenceId, OperationType = operationType }
            };

            var datagramFile = factory.Generate(traces);

            return datagramFile.Packaging();
        }
    }
}
