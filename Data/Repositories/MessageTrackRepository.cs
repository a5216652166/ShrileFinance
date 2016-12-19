using Core.Entities.CreditInvestigation;
namespace Data.Repositories
{
    using Core.Interfaces.Repositories.MessageRepository;

    class MessageTrackRepository :BaseRepository<MessageTrack>, IMessageTrackRepostitory
    {
        public MessageTrackRepository(MyContext context) : base(context)
        {
        }
    }
}
