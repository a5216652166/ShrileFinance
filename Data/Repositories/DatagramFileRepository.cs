namespace Data.Repositories
{
    using Core.Entities.CreditInvestigation.DatagramFile;
    using Core.Interfaces.Repositories;

    public class DatagramFileRepository : BaseRepository<DatagramFile>, IDatagramFileRepository
    {
        public DatagramFileRepository(MyContext context) : base(context)
        {
        }
    }
}
