namespace Application
{
    using System;
    using Core.Entities.Message;
    using Core.Interfaces.Repositories.MessageRepository;

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
        public void Credit(Guid id, MessageOperationTypeEnum operationType, string name)
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
    }
}
