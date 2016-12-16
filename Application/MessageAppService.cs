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

        public void Credit(Guid id, MessageOperationTypeEnum operationType, string name)
        {
            var track = new MessageTrack()
            {
                // 报文数据
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
