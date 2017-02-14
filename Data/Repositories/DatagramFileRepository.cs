namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities.CreditInvestigation.DatagramFile;
    using Core.Interfaces.Repositories;

    public class DatagramFileRepository : BaseRepository<DatagramFile>, IDatagramFileRepository
    {
        public DatagramFileRepository(MyContext context) : base(context)
        {
        }

        string IDatagramFileRepository.AllotSerialNumber(DatagramFile datagramFile)
        {
            // 序列号
            var serialNumber = string.Empty;

            // 获取指定时间、指定类型的所有报文文件集合
            var files = GetAll(m => m.DateCreated.Date == datagramFile.DateCreated.Date && m.Type == datagramFile.Type);

            // 从files查找指定TraceId的报文文件集合
            var file = files.Where(m => m.TraceId == datagramFile.TraceId);

            // 若数据库已经记录该数据，则使用数据库中记录的序列号；否则，分配新序列号
            if (file.Count() == 1)
            {
                serialNumber = file.First().SerialNumber;
            }
            else
            {
                var filesMaxSerialNumber = files.Count() == 0 ? 0 : files.Max(m => Convert.ToInt32(m.SerialNumber));

                serialNumber = (Math.Max(files.Count(), filesMaxSerialNumber) + 1).ToString("D4");
            }

            return serialNumber;
        }
    }
}
