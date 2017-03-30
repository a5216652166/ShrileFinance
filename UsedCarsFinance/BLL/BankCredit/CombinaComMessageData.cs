namespace BLL.BankCredit
{
    using System;
    using System.Collections.Generic;
    using Models.BankCredit;

    public class CombinaComMessageData : ICombinaData
    {
        private const string path = @"~\upload\messageFile\";
        private readonly static DataRule _dataRule = new DataRule();

        /// <summary>
        /// 生成报文文件名
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string BuildMessageName(int fileId)
        {
            string messageName = string.Empty;
            string messageFileType = string.Empty;
            int fileCount = 0;
            // 企业金融机构代码
            string comFinancialInstitutionCode = "33207991216";

            ReportFilesInfo reportFilesInfo = _dataRule.GetReportFilesInfoById(fileId);
            int messageFileId = reportFilesInfo == null ? 0 : reportFilesInfo.MessageFileId;
            int serviceObj = reportFilesInfo == null ? 0 : reportFilesInfo.ServiceObj;

            switch (messageFileId)
            {
                case 1:
                    messageFileType = "11";
                    break;
                case 2:
                    messageFileType = "12";
                    break;
                case 3:
                    messageFileType = "14";
                    break;
                case 4:
                    messageFileType = "31";
                    break;
                default:
                    return string.Empty;
            }
            string partnerName = "11" + comFinancialInstitutionCode + DateTime.Now.ToString("yyMMdd") + messageFileType + "1";

            fileCount = new DAL.BankCredit.ReportFilesMapper().FindFileCount(partnerName);

            List<ReportFilesInfo> reportFileInfo = new DAL.BankCredit.ReportFilesMapper().FindFileByPartnerName(partnerName);
            if (reportFileInfo.Count == 0)
            {
                partnerName += "1".PadLeft(4, '0');
            }
            else
            {
                partnerName += ((Convert.ToInt32(reportFileInfo[0].ReportTextName.Substring(22, 4))) + 1).ToString().PadLeft(4, '0');
            }

            messageName = partnerName + "00";

            return messageName;
        }

        /// <summary>
        /// 生成报文头
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public string BuildMessageTop(int fileId, int messageTypeId, int i)
        {
            // 报文头临时变量
            string messageTopData = string.Empty;
            // 补位码临时变量
            string complementBits = string.Empty;
            // 版本号
            string version = "A2.1";
            // 企业金融机构代码
            string comFinancialInstitutionCode = "33207991216";
            // 获取报文文件信息
            ReportFilesInfo reportFilesInfo = _dataRule.GetReportFilesInfoById(fileId);
            int messageFileId = reportFilesInfo == null ? 0 : reportFilesInfo.MessageFileId;
            MessageFileInfo messageFileInfo = _dataRule.GetMessageFileInfoById(messageFileId);
            int messageFileTypeId = messageFileInfo == null ? 0 : messageFileInfo.MessageFileTypeId;
            MessageTypeInfo messageTypeInfo = _dataRule.GetMessageTypeInfoById(messageTypeId);
            string messageTypeCode = messageTypeInfo == null ? string.Empty : messageTypeInfo.BMP_Code;

            // 采集类报文文件
            if (messageFileTypeId == 1)
            {
                messageTopData = version + comFinancialInstitutionCode + DateTime.Now.ToString("yyyyMMddHHmmss") + messageTypeCode + complementBits.PadRight(30, ' ');
            }
            // 业务管理类报文文件
            if (messageFileTypeId == 2)
            {

            }
            // 反馈类报文文件
            if (messageFileTypeId == 3)
            {

            }

            return messageTopData;
        }

        /// <summary>
        /// 生成报文体
        /// </summary>
        /// yaoy    16.07.05
        /// <param name="fileId"></param>
        /// <param name="messageTypeId"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public string BuildMessageBody(int fileId, int messageTypeId, out int i)
        {
            int j = 0;
            string messageBodyData = string.Empty;

            DataAndRuleComPare compare = new DataAndRuleComPare();
            List<InfoTypeInfo> infoTypeList = _dataRule.GetInfoTypeList(messageTypeId);

            // 遍历信息类型
            foreach (InfoTypeInfo infoTypeInfo in infoTypeList)
            {
                InfoTypeInfo infoType = _dataRule.GetDataRuleByInfoTypeId(infoTypeInfo.InfoTypeId);
                List<InformationRecordInfo> informationRecordList = _dataRule.GetInformationListByInfoTypeIdAndFileId(infoTypeInfo.InfoTypeId, fileId);

                if (informationRecordList != null)
                {
                    // 遍历信息记录
                    foreach (InformationRecordInfo informationRecordInfo in informationRecordList)
                    {
                        j++;

                        var context = informationRecordInfo.Context;
                        messageBodyData += new DataRule().ReplaceData(compare.EncapsulateData(infoType, context)) + "\r\n";
                    }
                }
            }

            i = j;

            return messageBodyData;
        }
    }
}
