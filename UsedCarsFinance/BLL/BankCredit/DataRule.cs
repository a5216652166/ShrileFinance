using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class DataRule
    {
        /// <summary>
        /// 根据报文类型获取文件类型
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="messageTpeId"></param>
        /// <returns></returns>
        public MessageFileTypeInfo GetMessageFileTypeInfoById(int messageTpeId)
        {
            return new DAL.BankCredit.MessageFileTypeMapper().FindByMessageTypeId(messageTpeId);
        }

        /// <summary>
        /// 获取报文类型实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageFileId"></param>
        /// <returns></returns>
        public MessageFileInfo GetMessageFileInfoById(int messageFileId)
        {
            return new DAL.BankCredit.MessageFileMapper().Find(messageFileId);
        }

        /// <summary>
        /// 获取报文列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageFileId"></param>
        /// <returns></returns>
        public List<MessageTypeInfo> GetMessageTypeList(int messageFileId)
        {
            return new DAL.BankCredit.MessageTypeMapper().List(messageFileId);
        }

        /// <summary>
        /// 获取报文实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public MessageTypeInfo GetMessageTypeInfoById(int messageTypeId)
        {
            return new DAL.BankCredit.MessageTypeMapper().Find(messageTypeId);
        }

        /// <summary>
        /// 获取报文段列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<InfoTypeInfo> GetInfoTypeList(int messageTypeId)
        {
            return new DAL.BankCredit.InfoTypeMapper().List(messageTypeId);
        }

        /// <summary>
        /// 获取信息记录实体（yand修改）
        /// </summary>
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public InfoTypeInfo GetInfoTypeInfoById(int infoTypeId)
        {
            return new DAL.BankCredit.InfoTypeMapper().Find(infoTypeId);
        }

        /// <summary>
        /// 获取数据段列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<DataSegmentInfo> GetDataSegmentList(int infoTypeId)
        {
            return new DAL.BankCredit.DataSegmentMapper().FindByInfoTypeId(infoTypeId);
        }

        /// <summary>
        /// 获取数据段实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public DataSegmentInfo GetDataSegmentInfoById(int dataSegmentId)
        {
            return new DAL.BankCredit.DataSegmentMapper().Find(dataSegmentId);
        }

        /// <summary>
        /// 获取报文文件实体
        /// </summary>
        /// yaoy    16.06.02
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ReportFilesInfo GetReportFilesInfoById(int fileId)
        {
            return new DAL.BankCredit.ReportFilesMapper().Find(fileId);
        }

        /// <summary>
        /// 通过信息类型ID获取信息记录列表
        /// </summary>
        /// yaoy    16.05.30
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> GetInformationListByInfoTypeId(int infoTypeId)
        {
            return new DAL.BankCredit.InformationRecordMapper().FindByInfoTypeId(infoTypeId);
        }

        /// <summary>
        /// 通过报文ID获取信息记录列表
        /// </summary>
        /// yaoy    16.06.02
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> GetInformationListByReportId(int reportId)
        {
            return new DAL.BankCredit.InformationRecordMapper().FindByReportId(reportId);
        }

        /// <summary>
        /// 根据报文类型Id和报文记录Id获取信息记录列表
        /// </summary>
        /// yaoy    16.06.03
        /// <param name="infoTypeId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> GetInformationListByInfoTypeIdAndFileId(int infoTypeId, int fileId)
        {
            return new DAL.BankCredit.InformationRecordMapper().FindInformationListByInfoTypeIdAndFileId(infoTypeId, fileId);
        }

        

        /// <summary>
        /// 获取数据规则实体
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public SegmentRulesInfo GetSegmentRulesInfoById(int segmentRulesId)
        {
            return new DAL.BankCredit.SegmentRulesMapper().Find(segmentRulesId);
        }

        /// <summary>
        /// 获取数据规则集合
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> GetSegmentRulesList(int dataSegmentId)
        {
            return new DAL.BankCredit.SegmentRulesMapper().List(dataSegmentId);
        }

        /// <summary>
        /// 通过元数据编码获取元数据实体
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public MetaInfo GetMetaInfoByCode(int metaCode)
        {
            return new DAL.BankCredit.MetaMapper().Find(metaCode);
        }

        /// <summary>
        /// 通过元数据编码获取数据元和控件规则
        /// </summary>
        /// yaoy    16.07.11
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public MetaComponentsInfo GetMetaComponentsInfoByCode(int metaCode)
        {
            return new DAL.BankCredit.MetaComponentsMapper().Find(metaCode);
        }

        /// <summary>
        /// 获取信息记录长度
        /// </summary>
        /// yaoy    16.06.03
        /// <param name="data"></param>
        /// <returns></returns>
        public string ReplaceData(string data)
        {
            if (data != "")
            {
                if (data.Length >= 0 && data.Length <= 9999)
                {
                    string temp = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(data) .ToString();

                    if (temp.Length <= 4)
                    {
                        temp = temp.PadLeft(4, '0');
                    }

                    data = temp + data.Remove(0, 4);
                }
            }


            return data;
        }

        /// <summary>
        /// 补位
        /// </summary>
        /// yaoy 16.07.11
        /// <param name="data"></param>
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public string CoverPosition(string data, int dataSegmentId)
        {
            string str = string.Empty;

            DataSegmentInfo dataSegmentInfo = GetDataSegmentInfoById(dataSegmentId);
            List<SegmentRulesInfo> segmentRulesList = GetSegmentRulesList(dataSegmentId);

            if (segmentRulesList != null)
            {
                foreach (SegmentRulesInfo segmentRulesInfo in segmentRulesList)
                {
                    MetaInfo metaInfo = GetMetaInfoByCode(segmentRulesInfo.MetaCode);
                    MetaComponentsInfo metaComponentsInfo = GetMetaComponentsInfoByCode(segmentRulesInfo.MetaCode);

                    if (metaInfo != null && metaComponentsInfo != null)
                    {
                        var start = segmentRulesInfo.Position - 1;
                        str = new DataAndRuleComPare().ComplementBits(metaInfo, string.Empty);
                        data = data.Insert(start, str);
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// 通过信息类型ID获取数据规则对象
        /// </summary>
        /// yaoy    16.05.27
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public InfoTypeInfo GetDataRuleByInfoTypeId(int infoTypeId)
        {
            InfoTypeInfo infoTypeInfo = GetInfoTypeInfoById(infoTypeId);

            infoTypeInfo.DataSegmentList = GetDataSegmentList(infoTypeId);

            foreach (DataSegmentInfo dataSegmentInfo in infoTypeInfo.DataSegmentList)
            {
                dataSegmentInfo.SegmnetRulesList = GetSegmentRulesList(dataSegmentInfo.DataSegmentId);

                foreach (SegmentRulesInfo segmentRulesInfo in dataSegmentInfo.SegmnetRulesList)
                {
                    segmentRulesInfo.MetaInfo = GetMetaInfoByCode(segmentRulesInfo.MetaCode);
                }
            }

            return infoTypeInfo;
        }

        /// <summary>
        /// 封装报文文件
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string CombinaReportData(int fileId)
        {
            int i = 0;
            string reportData = string.Empty;

            ICombinaData combinaComData = new CombinaComMessageData();
            ICombinaData combinaPerData = new CombinaPerMessageData();

            ReportFilesInfo reportFilesInfo = GetReportFilesInfoById(fileId);

            int messageFileId = reportFilesInfo == null ? 0 : reportFilesInfo.MessageFileId;
            // 获取服务对象
            int serviceObj = reportFilesInfo == null ? 0 : reportFilesInfo.ServiceObj;

            List<MessageTypeInfo> messageTypeList = GetMessageTypeList(messageFileId);

            if (messageTypeList != null)
            {
                foreach (MessageTypeInfo messageTypeInfo in messageTypeList)
                {
                    if (serviceObj == 1)
                    {
                        string temp = combinaComData.BuildMessageBody(fileId, messageTypeInfo.MessageTypeId, out i);

                        if (temp == "")
                        {
                            reportData += combinaComData.BuildMessageTop(fileId, messageTypeInfo.MessageTypeId, i) + "\r\n" + new DataUtil().BuildMessageTail(i) + "\r\n\r\n";
                        }
                        else
                        {
                            reportData += combinaComData.BuildMessageTop(fileId, messageTypeInfo.MessageTypeId, i) + "\r\n" + temp + new DataUtil().BuildMessageTail(i) + "\r\n\r\n";
                        }
                    }
                    if (serviceObj == 2)
                    {
                        string temp = combinaPerData.BuildMessageBody(fileId, messageTypeInfo.MessageTypeId, out i);

                        if (temp != "")
                        {
                            reportData += combinaPerData.BuildMessageTop(fileId, messageTypeInfo.MessageTypeId, i) + "\r\n\r\n" + temp + "\r\n";
                        }
                    }
                }
                if (reportData.Length > 4)
                {
                    // 去掉最后一个换行符（"\r\n"）
                    reportData = reportData.Substring(0, reportData.Length - 4);
                }
            }

            return reportData;
        }
    }
}
