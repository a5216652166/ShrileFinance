using System;
using Models.Finance;
using Models.Flow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Transactions;
using Models.Notice;
using Models;
using System.Collections.Generic;
using Models.User;

namespace BLL.Flow.Script
{
    /// <summary>
    /// 业务数据保存
    /// </summary>
    public class FinanceScript
    {
        private static readonly Flow.Engine _engine = new Flow.Engine();
        private static readonly JsonSerializer _serializer = new JsonSerializer();

        /// <summary>
        /// 保存融资信息
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveFinanceData(string data)
        {
            var result = true;
            var _instance = new Instance();
            var _finance = new Finance.Finance();

            JObject jo = (JObject)JsonConvert.DeserializeObject(data);
            StringReader sr = new StringReader(jo["D1"].ToString());
            FinanceNodeGroupInfo financeNodeGroup = (FinanceNodeGroupInfo)_serializer.Deserialize(new JsonTextReader(sr), typeof(FinanceNodeGroupInfo));

            using (TransactionScope scope = new TransactionScope())
            {
                if (financeNodeGroup.FinanceInfo.FinanceId == null)
                {
                    result &= _finance.Add(financeNodeGroup);

                    _instance.SetData(financeNodeGroup.FinanceInfo.InstanceId, new { FinanceId = financeNodeGroup.FinanceInfo.FinanceId });
                }
                else
                {
                    result &= _finance.Modify(financeNodeGroup);
                }

                if (result)
                {
                    scope.Complete();
                }
            }

            return result;
        }

        /// <summary>
        /// 保存初审信息
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveCreditExamineReportData(string data)
        {
            var result = true;
            var _review = new Finance.Review();
            var _finance = new Finance.Finance();
            var _creditExamine = new Finance.CreditExamineReport();

            JObject jo = (JObject)JsonConvert.DeserializeObject(data);

            StringReader sr1 = new StringReader(jo["D3"]["CreditExamineReportInfo"].ToString());
            CreditExamineReportInfo creditExamine = (CreditExamineReportInfo)_serializer.Deserialize(new JsonTextReader(sr1), typeof(CreditExamineReportInfo));

            StringReader sr2 = new StringReader(jo["D4"]["ReviewInfo"].ToString());
            ReviewInfo reviewInfo = (ReviewInfo)_serializer.Deserialize(new JsonTextReader(sr2), typeof(ReviewInfo));

            using (TransactionScope scope = new TransactionScope())
            {
                if (_creditExamine.Get(creditExamine.FinanceId) == null)
                {
                    result &= _creditExamine.Add(creditExamine);
                }
                else
                {
                    result &= _creditExamine.Modify(creditExamine);
                }

                reviewInfo.ReviewType = (byte)ReviewType.初审;

                if (_review.Get(reviewInfo.FinanceId) == null)
                {
                    // 初审添加
                    result &= _review.Add(reviewInfo);
                }
                else
                {
                    // 初审修改
                    result &= _review.Modify(reviewInfo);
                }

                if (result) scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 保存复审信息
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveAuditOptionData(string data)
        {
            bool result = true;
            var _review = new Finance.Review();

            JObject jo = (JObject)JsonConvert.DeserializeObject(data);
            StringReader sr = new StringReader(jo["D4"]["ReviewInfo"].ToString());
            ReviewInfo reviewInfo = (ReviewInfo)_serializer.Deserialize(new JsonTextReader(sr), typeof(ReviewInfo));

            using (TransactionScope scope = new TransactionScope())
            {
                reviewInfo.ReviewType = (byte)ReviewType.复审;

                // 复审修改
                result &= _review.Modify(reviewInfo);

                if (result) scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 保存合同信息
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveContrantData(string data)
        {
            bool result = true;
            var _instance = new Flow.Instance();
            var _contract = new Contract.PdfContract();

            var financeId = Convert.ToInt32(data);

            using (TransactionScope scope = new TransactionScope())
            {
                // 保存合同信息~生成合同id
                result &= _contract.SaveFile(financeId);

                // 生成合同
                result &= _contract.CreateContrant(financeId);

                if (result) scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 保存运营节点录入信息
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveOperationData(string data)
        {
            bool result = true;
            var _operate = new Finance.Operating();
            var _finance = new Finance.Finance();

            JObject jo = (JObject)JsonConvert.DeserializeObject(data);

            StringReader sr = new StringReader(jo["D8"].ToString());
            OperatingInfo operatingInfo = (OperatingInfo)_serializer.Deserialize(new JsonTextReader(sr), typeof(OperatingInfo));

            using (TransactionScope scope = new TransactionScope())
            {
                result &= _finance.ModifyOptionInfo(operatingInfo);

                if (result) scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveInfoAdditionalData(string data)
        {
            bool result = true;
            var _operate = new Finance.Operating();
            var _finance = new Finance.Finance();

            JObject jo = (JObject)JsonConvert.DeserializeObject(data);

            StringReader sr = new StringReader(jo["D11"].ToString());
            OperatingInfo operatingInfo = (OperatingInfo)_serializer.Deserialize(new JsonTextReader(sr), typeof(OperatingInfo));

            using (TransactionScope scope = new TransactionScope())
            {
                result &= _finance.ModifyInfoAdditional(operatingInfo);

                if (result) scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 节点邮件通知
        /// </summary>
        /// <param name="actionInfo">节点通知</param>
        /// <returns></returns>
        public bool EamlNotice(ActionNoticeInfo actionNotice, int instanceId,string customerName)
        {
            int actionId = actionNotice.ActionId;
            // 通知消息
            NoticeInfo noticeinfo = new NoticeInfo();

            // 邮件内容配置
            List<Mail> mail = new List<Mail>();

            // 通知人
            List<UserInfo> userList = new List<UserInfo>();

            // 根据节点通知的寻找用户类型2表示通知下一个操作者1表示通知所有人，3表示通知所有人和下一个操作者
            //1表示通知所有人
            if (actionNotice.FindPeopleType == 1)
            {
                userList = FindDoneUser(instanceId);
            }
            else if (actionNotice.FindPeopleType == 2)
            {
                userList.Add(FindLastUser(actionId, instanceId));
            }
            else if (actionNotice.FindPeopleType == 3)
            {
                userList = FindDoneUser(instanceId);
                userList.Add(FindLastUser(actionId, instanceId));
            }

            foreach (UserInfo user in userList)
            {
                if (user.Email != null)
                {
                    mail.Add(new Mail()
                    {
                        // 邮件配置
                        UserId = user.UserId,
                        Title = actionNotice.Title,
                        From = "ywtongzhi@ywsoftware.com",
                        FromPassword = "Meihu0728",
                        SmtpServer = "smtp.qiye.163.com",
                        Subject = "通知邮件服务提醒",
                        To = user.Email,
                        Body = "主要申请人为：" + customerName + "的信息，" + actionNotice.Content + "。   审批时间为：" + DateTime.Now,
                        BodyFormat = "html",
                    });
                }
            }

            if (mail.Count > 0)
            {
                return new Notice.Notice().SendEmail(mail);
            }
            else
            {
                return true;
            }

        }

        // 系统通知
        public bool SystemNotice(ActionNoticeInfo actionNotice, int instanceId,string customerName)
        {
            int actionId = actionNotice.ActionId;
            // 通知消息
            List<NoticeInfo> noticeList = new List<NoticeInfo>();

            // 通知人
            List<UserInfo> userList = new List<UserInfo>();


            // 根据节点通知的寻找用户类型2表示通知下一个操作者1表示通知所有人，3表示通知所有人和下一个操作者
            //1表示通知所有人
            if (actionNotice.FindPeopleType == 1)
            {
                userList = FindDoneUser(instanceId);
            }
            else if (actionNotice.FindPeopleType == 2)
            {
                userList.Add(FindLastUser(actionId, instanceId));
            }
            else if(actionNotice.FindPeopleType == 3)
            {
                userList = FindDoneUser(instanceId);
                userList.Add(FindLastUser(actionId, instanceId));
            }

            foreach (UserInfo user in userList)
            {
                noticeList.Add(new NoticeInfo()
                {
                    NoticeType = NoticeType.系统提示,
                    Time = DateTime.Now,
                    Title = actionNotice.Title,
                    Content ="主要申请人为："+ customerName+"的信息，"+ actionNotice.Content+"。   审批时间为："+DateTime.Now,
                    IsRead = false,
                    UserId = user.UserId
                }); 
            }
         
            return new Notice.Notice().SendSystem(noticeList);
        }


        /// <summary>
        /// 获取操作实例的所有用户（排除自己）
        /// </summary>
        /// yand    16.09.13
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public List<UserInfo> FindDoneUser(int instanceId)
        {
            // 获取当前操作者排除给自己系统通知
            int userId = BLL.User.User.CurrentUserId;
            List<UserInfo> userList = new List<UserInfo>();

            List<LogInfo> loginfo = new Log().GetListByUserId(instanceId, userId);
            for (int i = 0; i < loginfo.Count; i++)
            {
                UserInfo user = new BLL.User.User().GetUser(loginfo[i].ProcessUser);
                userList.Add(user);
            }
            return userList;
        }

        /// <summary>
        /// 查找下一个处理者
        /// </summary>
        /// yand    16.09.13
        /// <param name="actionId"></param>
        /// <returns></returns>
        public UserInfo FindLastUser(int actionId ,int instanceId)
        {
            UserInfo userinfo = new UserInfo();
            //根据行为ID查找对应的通知用户
            ActionInfo action = new BLL.Flow.Action().Get(actionId);
            IFindUser finduser = FindUser.CreateStrategy(action);

            //根据行为ID和实例ID查找下一个处理者
            FlowData flowData = new FlowData()
            {
                InstanceId = instanceId,
                ActionId = actionId
            };
            // 判断是否查到人,查不到分配总经理账户
            int userId = finduser.FindUser(flowData) == null ? new DAL.User.UserInfoMapper().FindByRole("总经理").UserId : finduser.FindUser(flowData).Value;

            userinfo = new BLL.User.User().GetUser(userId);

            return userinfo;
        }

        #region 
        ///// <summary>
        ///// 流程流转
        ///// </summary>
        ///// yand    16.09.11（添加通知处理）
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public bool Transfer(FlowData data)
        //{
        //    bool result = true;
        //    result &= _engine.Process(data);
        //    result &= new BLL.Notice.Notice().SendNotice(data.InstanceId.Value, data.ActionId);
        //    return result;
        //}
        #endregion
    }
}
