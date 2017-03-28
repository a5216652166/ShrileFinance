namespace Core.Interfaces.Repositories.DatagramRepositories
{
    using Entities.CreditInvestigation.DatagramFile;

    public interface IDatagramFileRepository : IRepository<DatagramFile>
    {
        string AllotSerialNumber(DatagramFile datagramFile);
    }
}
