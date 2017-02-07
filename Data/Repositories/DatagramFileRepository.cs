namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.CreditInvestigation.DatagramFile;
    using Core.Interfaces.Repositories;

    public class DatagramFileRepository : BaseRepository<DatagramFile>, IDatagramFileRepository
    {
        public DatagramFileRepository(MyContext context) : base(context)
        {
        }

        public string AllotSerialNumber(DatagramFile datagramFile)
        {
            var files = GetAll(m => m.DateCreated.Date == datagramFile.DateCreated.Date && m.Type == datagramFile.Type);

            var file = files.Where(m => m.TraceId == datagramFile.TraceId);

            var serialNumber = file.Count() > 0 ? file.First().SerialNumber : (files.Count() + 1).ToString("D4");

            return serialNumber;
        }
    }
}
