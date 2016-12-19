namespace Core.Entities.CreditInvestigation.DatagramFile
{
    /// <summary>
    /// 信贷业务信息文件
    /// </summary>
    public class LoanDatagramFile : AbsDatagramFile
    {
        public LoanDatagramFile(string serialNumber) : base(serialNumber)
        {
        }

        public override DatagramFileType Type
        {
            get
            {
                return DatagramFileType.信贷业务信息文件;
            }
        }
    }
}
