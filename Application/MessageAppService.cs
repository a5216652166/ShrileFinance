namespace Application
{
    using System;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Message;
    using Core.Interfaces.Repositories.MessageRepository;
    using ViewModels.Message;
    using X.PagedList;
    public class MessageAppService
    {
        private readonly IMessageTrackRepostitory respository;

        public MessageAppService(IMessageTrackRepostitory respository)
        {
            this.respository = respository;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="id">引用ID</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="name">默认名称</param>
        public void MessageTrack(Guid id, MessageOperationTypeEnum operationType, string name)
        {
            var track = new MessageTrack()
            {
                MessageStatus = MessageStatusEmum.待生成,
                Name = name,
                OperationType = operationType,
                ReferenceId = id,
            };

            respository.Create(track);
            respository.Commit();
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<MessageTrackViewModel> GetPageList(int page, int size)
        {
            var messageTrack = respository.GetAll();

            messageTrack = messageTrack.OrderByDescending(m => m.Id);
            var pageList = messageTrack.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<MessageTrackViewModel>>(pageList);

            return models;
        }
    }
}
