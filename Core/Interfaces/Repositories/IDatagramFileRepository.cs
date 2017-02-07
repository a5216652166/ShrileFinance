﻿namespace Core.Interfaces.Repositories
{
    using Entities.CreditInvestigation.DatagramFile;

    public interface IDatagramFileRepository : IRepository<DatagramFile>
    {
        string AllotSerialNumber(DatagramFile datagramFile);
    }
}
