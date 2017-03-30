namespace BLL.BankCredit
{
    using Models.BankCredit;

    public class BusinessLogicScript
    {
        /// <summary>
        /// 添加信息记录数据校验
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="postmessage"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool AddInfomationData(PostMessage postmessage, ref string message)
        {
            var result = true;

            MessageInfo messageInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(postmessage.Value);

            InfoTypeInfo infoType = new DataRule().GetDataRuleByInfoTypeId(postmessage.InfoTypeId);
            MessageFileTypeInfo messageFileTypeInfo = new DataRule().GetMessageFileTypeInfoById(postmessage.messageTypeID);

            // 数据合法性校验
            result &= new DataAndRuleComPare().Compare(infoType, postmessage.recordID, postmessage.ReportId, messageInfo, postmessage, ref message);

            // 数据规则校验
            // 企业通用规则校验
            if (messageFileTypeInfo.FileType == 1)
            {
                result &= new Validates.ComInformationValidate(infoType.InfoTypeId, messageInfo).BaseValidateMethod();
            }

            // 个人通用规则校验
            else
            {
                result &= new Validates.PerInformationValidate(infoType.InfoTypeId, messageInfo).BaseValidateMethod();
            }

            return result;
        }
    }
}
