namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using Core.Entities.Identity;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using Data.PDF;
    using Infrastructure.PDF;
    using ViewModels.FinanceViewModels;
    using static Core.Entities.Finance.Applicant;

    /// <summary>
    /// 融资
    /// </summary>
    public class FinanceAppService
    {
        private readonly IFinanceRepository financeRepository;
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;
        private readonly IContractRepository contractRepository;
        private readonly IPartnerRepository partnerRepository;
        private readonly IProduceRepository produceRepository;

        public FinanceAppService(
            IFinanceRepository financeRepository,
            AppUserManager userManager,
            AppRoleManager roleManager,
            IContractRepository contractRepository,
            IPartnerRepository partnerRepository,
            IProduceRepository produceRepository)
        {
            this.financeRepository = financeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.contractRepository = contractRepository;
            this.partnerRepository = partnerRepository;
            this.produceRepository = produceRepository;
        }

        public KeyValuePair<string, byte[]> DownLoadApproval(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);

            var param = new Dictionary<string, string>();
            var info = finance.Applicant.Where(m => m.Type == TypeEnum.担保人).ToArray();            

            param.Add("【[@合同编号1@]】",string.Empty );
            if (info.Length >= 1)
            {
                param.Add("[@保证人1@]",info[0].Name);
                param.Add("【[@合同编号2@]】", string.Empty);
                if (info.Length >= 2)
                {
                    param.Add("[@保证人2@]", info[1].Name);
                    param.Add("【[@合同编号3@]】", string.Empty);
                }
            }
            else
            {
                param.Add("【[@保证人1@]】", string.Empty);
                param.Add("【[@合同编号2@]】", string.Empty);
                param.Add("【[@保证人2@]】", string.Empty);
                param.Add("【[@合同编号3@]】", string.Empty);
            }

            param.Add("【[@合同编号4@]】", string.Empty);
            param.Add("【[@还车条款@]】", string.Empty);

            var applicant = finance.Applicant.Single(m => m.Type == TypeEnum.共同申请人);
            var customer = finance.Applicant.Single(m => m.Type == TypeEnum.主要申请人);
            param.Add("[@客户@]", customer.Name);
            param.Add("[@承租人@]", applicant.Name);
            param.Add("[@渠道商@]", finance.CreateOf.Name);
            param.Add("[@所在区域@]", finance.CreateOf.ProxyArea);
            param.Add("【[@抵押要求@]】", string.Empty);
            param.Add("【[@上牌要求@]】", string.Empty);

            var upper = new MoneyToUpper();
            param.Add("[@人民币1@]", upper.RMBToUpper(finance.Financing == null ? 0 : finance.Financing.Value));
            param.Add("[@金额1@]", Convert.ToString(finance.Financing == null ? 0 : finance.Financing.Value));
            param.Add("[@人民币2@]", upper.RMBToUpper(finance.Poundage == null ? 0 : finance.Poundage.Value));
            param.Add("[@金额2@]", Convert.ToString(finance.Poundage == null ? 0 : finance.Poundage.Value));
            param.Add("[@人民币3@]", upper.RMBToUpper(finance.Bail == null ? 0 : finance.Bail.Value)); 
            param.Add("[@金额3@]", Convert.ToString(finance.Bail == null ? 0 : finance.Bail.Value));
            param.Add("[@人民币4@]", "             ");
            param.Add("[@金额4@]", "         ");
            param.Add("[@人民币5@]", "             ");
            param.Add("[@金额5@]", "         ");

            param.Add("[@融资期限@]", finance.Produce.TimeLimit.ToString());
            param.Add("[@人民币6@]", "             ");
            param.Add("[@金额6@]", "         ");
            param.Add("[@人民币7@]", "             ");
            param.Add("[@金额7@]", "         ");
            param.Add("[@人民币8@]", "             ");
            param.Add("[@金额8@]", "         ");
            param.Add("[@人民币9@]", "             ");
            param.Add("[@金额9@]", "         ");
            param.Add("[@人民币10@]", "             ");
            param.Add("[@金额10@]", "         ");

            var date = finance.RepayRentDate;

            param.Add("[@年1@]", date.Value.Year.ToString());
            param.Add("[@月1@]", date.Value.Month.ToString());
            param.Add("[@日1@]", date.Value.Day.ToString());
            param.Add("【[@年2@]】", string.Empty);
            param.Add("【[@月2@]】", string.Empty);
            param.Add("【[@日2@]】", string.Empty);
            param.Add("[@产品大类@]", finance.Produce.ProduceType.ToString());
            param.Add("[@产品代码@]",finance.Produce.Code );


            var path = new WordToPDF().TransformWordToPDF(@"~\upload\PDF\", "Approval", param, "个人按揭客户审批通知书");
            var pair = new KeyValuePair<string, byte[]>($"个人按揭客户审批通知书.pdf", GetFileBytes(path));

            return pair;
        }
        
        public KeyValuePair<string, byte[]> DownloadSignle(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);

            ////var finance = new Finance();
            ////finance.Applicant = new List<Applicant>() { new Applicant() { Type = TypeEnum.主要申请人 } };

            ////var ssss = finance.Applicant.Single(m => m.Type == TypeEnum.主要申请人);
            ////ssss.Name = "钟洪伟";
            ////ssss.Sex = "男";
            ////ssss.LiveHouseAddress = "浙江省杭州市萧山区缤纷小区8幢3单元601";
            ////ssss.IdentityType = "身份证";
            ////ssss.Identity = "339116199907158354";

            ////finance.CreateOf = new Partner();
            ////finance.CreateOf.Name = "杭州西湖法拉利4S店";
            ////finance.Vehicle = new Core.Entities.Vehicle.Vehicle();
            ////finance.Vehicle.MakeCode = "法拉利";
            ////finance.Vehicle.PlateNo = "浙A888AA";
            ////finance.Vehicle.FrameNo = "1589654E756542A69";

            var param = new Dictionary<string, string>();
            var info = finance.Applicant.Single(m => m.Type == TypeEnum.主要申请人);
            param.Add("[@姓名@]", info.Name);
            param.Add("[@性别@]", info.Sex);
            param.Add("[@住址@]", info.LiveHouseAddress);
            param.Add("[@证件类型@]", info.IdentityType);
            param.Add("[@证件号码@]", info.Identity);
            param.Add("[@年@]", info.Identity.Substring(6, 4));
            param.Add("[@月@]", info.Identity.Substring(10, 2));
            param.Add("[@日@]", info.Identity.Substring(12, 2));
            param.Add("[@合作商@]", finance.CreateOf.Name);
            param.Add("[@品牌@]", finance.Vehicle.MakeCode);
            param.Add("[@车牌号@]", finance.Vehicle.PlateNo);
            param.Add("[@识别号@]", finance.Vehicle.FrameNo);

            var path = new WordToPDF().TransformWordToPDF(@"~\upload\PDF\", "UnmarriedStatement", param, "单身证明书");
            var pair = new KeyValuePair<string, byte[]>($"单身证明书.pdf", GetFileBytes(path));            

            return pair;            
        }

        private byte[] GetFileBytes(string path)
        {
            var fi = new FileInfo(path);
            var fs = fi.OpenRead();
            var bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return bytes;
        }

        public void Create(FinanceApplyViewModel value)
        {
            var finance = Mapper.Map<Finance>(value);

            finance.FinancialItem = Mapper.Map<ICollection<FinancialItem>>(value.FinancialItem);

            finance.Applicant = Mapper.Map<ICollection<Applicant>>(value.Applicant);

            finance.CreateBy = userManager.CurrentUser();
            finance.CreateOf = partnerRepository.GetByUser(userManager.CurrentUser());

            finance.Produce = produceRepository.Get(value.Produce.Id.Value);

            financeRepository.Create(finance);
            financeRepository.Commit();

            value.Id = finance.Id;
        }

        public PartnerAndUser GetPartnerAndUser()
        {
            AppUser user = userManager.CurrentUser();
            Partner partner = partnerRepository.GetByUser(userManager.CurrentUser());
            return new PartnerAndUser()
            {
                PartnerName = partner.Name,
                UserName = user.Name,
                Phone = user.PhoneNumber,
            };
        }

        public void Modify(FinanceApplyViewModel model)
        {
            var finance = financeRepository.Get(model.Id.Value);

            Mapper.Map(model, finance);

            new UpdateBind().Bind(finance.FinancialItem, model.FinancialItem);

            new UpdateBind().Bind(finance.Applicant, model.Applicant);

            finance.CreateBy = userManager.CurrentUser();
            finance.CreateOf = partnerRepository.GetByUser(userManager.CurrentUser());
            financeRepository.Modify(finance);
            financeRepository.Commit();
        }

        public Contract GetContract(Guid contractId)
        {
            return contractRepository.Get(contractId);
        }

        public FinanceApplyViewModel Get(Guid id)
        {
            var entity = financeRepository.Get(id);

            var model = Mapper.Map<FinanceApplyViewModel>(entity);

            return model;
        }

        public string CreateLeaseInfoPdf(Guid financeId, string newPath)
        {
            var finance = financeRepository.Get(financeId);

            // 合同pdf地址
            string pdfPath = string.Empty;

            var mainApplicant = finance.Applicant.Where(m => m.Type == Applicant.TypeEnum.主要申请人).First();

            // 融资租赁合同编号代码
            string hz = GetContractNum("HZ", financeId);

            // 获取融资信息
            SqlParameter[] sqlparams = new SqlParameter[1];
            sqlparams[0] = new SqlParameter("FinanceId", financeId);
            DataTable dt = financeRepository.LeaseeContract(sqlparams);

            // 合同参数
            string contractParams = string.Empty;

            // 保存的PDF名称(以合同编号命名)
            string pdfName = string.Empty;

            // 合同模板名称
            string contractName = "FinancingLease.docx";

            CreatePdf pdf = new CreatePdf();

            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["[融资租赁合同]"] = hz;
                contractParams = pdf.DataRowToParams(dt.Rows[0]);
                pdfName = hz;
            }

            pdfPath = pdf.TransformPdf(newPath, contractName, contractParams, pdfName);

            if (finance.Contact.FirstOrDefault(m => m.Name == "融资租赁合同") == null)
            {
                if (pdfPath != null)
                {
                    finance.Contact.Add(new Contract
                    {
                        Date = DateTime.Now,
                        Name = "融资租赁合同",
                        Number = pdfName,
                        Path = "~\\upload\\PDF\\"
                    });

                    financeRepository.Modify(finance);
                    financeRepository.Commit();
                }
            }

            return pdfPath;
        }

        public string GetContractNum(string type, Guid financeid)
        {
            string error = string.Empty;
            string aaaa = string.Empty;
            string cccc = string.Empty;
            string dddd = string.Empty;
            string contractNumber = string.Empty;

            // 合作商编码
            var partnerCode = "01";

            var finance = financeRepository.Get(financeid);
            var contract = finance.Contact.FirstOrDefault(m => m.Name == "融资租赁合同");

            if (contract != null)
            {
                contractNumber = contract.Number;
            }
            else
            {
                // 查询合作商ID
                Guid bb = FindByCreateOf(financeid, ref error);
                if (bb != null && error == string.Empty)
                {
                    aaaa = GetCityCode(bb);

                    cccc = GetYYMM();

                    // 获取月初
                    DateTime time = DateTime.Now.AddDays(1 - DateTime.Now.Day);

                    // 月当渠道的流水号
                    // contract.FindCount(Time, BB).ToString();
                    int countBymonth = contractRepository.GetAll(m => m.Date >= time && m.Date <= DateTime.Now && m.Number.Contains(partnerCode)).ToList().Count;

                    int ddlength = countBymonth + 1;
                    dddd = ddlength.ToString().PadLeft(3, '0');
                }

                // 组成AAAABBCCCCDDD
                contractNumber = type + aaaa + partnerCode + cccc + dddd;
            }

            return contractNumber;
        }

        /// <summary>
        /// 查找系统渠道ID
        /// </summary>
        /// <param name="financeId">融资ID</param>
        /// <param name="error">错误提示</param>
        /// <returns></returns>
        public Guid FindByCreateOf(Guid financeId, ref string error)
        {
            Guid varCreateOf = new Guid();

            var finance = financeRepository.Get(financeId);
            if (finance.CreateOf == null)
            {
                error = "未找到系统[渠道编码]";
            }
            else
            {
                varCreateOf = finance.CreateOf.Id;
            }

            return varCreateOf;
        }

        /// <summary>
        /// 获得当前年月
        /// </summary>
        /// <returns>yyMM</returns>
        public string GetYYMM()
        {
            return DateTime.Now.ToString("yyMM");
        }

        /// <summary>
        /// 获得城市代码1200天津市
        /// </summary>
        /// <param name="partnerId">合作商ID</param>
        /// <returns></returns>
        public string GetCityCode(Guid partnerId)
        {
            var partner = partnerRepository.Get(partnerId);

            // 由于没有城市代码先手动赋值
            // return partner.City;
            return "1010";
        }

        /// <summary>
        /// 获取财务信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>财务Model</returns>
        public LoanViewModel GetLoan(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);
            LoanViewModel loan = Mapper.Map<LoanViewModel>(finance);
            return new LoanViewModel()
            {
                CreditAccountName = finance.FinanceExtension.CreditAccountName,
                ApprovalMoney = finance.Principal,
                CreditBankCard = finance.FinanceExtension.CreditBankCard,
                CreditBankName = finance.FinanceExtension.CreditBankName,
                CustomerAccountName = finance.FinanceExtension.CustomerAccountName,
                CustomerBail = finance.Bail,
                CustomerBankCard = finance.FinanceExtension.CustomerBankCard,
                CustomerBankName = finance.FinanceExtension.CustomerBankName,
                OnePayInterest = finance.OnePayInterest,
                Payment = Math.Round(Convert.ToDouble(finance.Principal * finance.OncePayMonths / finance.Produce.TimeLimit), 2),
            };
        }

        /////// <summary>
        /////// 通过融资标识获取信审ViewModel
        /////// </summary>
        /////// <param name="financeId">融资标识</param>
        /////// <returns>信审ViewModel</returns>
        ////public CreditExamineViewModel GetCreditExamineByFinanceId(Guid financeId)
        ////{
        ////    ////if (financeId == null)
        ////    ////{
        ////    ////    return null;
        ////    ////}

        ////    ////// 获取融资实体
        ////    ////var finance = repository.Get(financeId);

        ////    ////if (finance == null)
        ////    ////{
        ////    ////    return null;
        ////    ////}

        ////    ////// 当前用户
        ////    ////var curentUser = userManager.CurrentUser();

        ////    ////if (curentUser == null)
        ////    ////{
        ////    ////    return null;
        ////    ////}

        ////    ////////finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

        ////    ////////// 实体转ViewModel
        ////    ////////var creditExamineReportViewModel = Mapper.Map<CreditExamineViewModel>(finance.CreditExamine);

        ////    ////// 融资标识
        ////    ////creditExamineReportViewModel.FinanceId = finance.Id;

        ////    ////// 婚姻状况
        ////    ////creditExamineReportViewModel.MarriageState = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.主要申请人).MaritalStatus;

        ////    ////////// 保证金
        ////    ////////if (!string.IsNullOrEmpty(finance.CreditExamine.Margin))
        ////    ////////{
        ////    ////////    var array = finance.CreditExamine.Margin.Split('-');
        ////    ////////    creditExamineReportViewModel.Margin1 = array[0];
        ////    ////////    creditExamineReportViewModel.Margin2 = array[1];
        ////    ////////}

        ////    ////////// 产品编号
        ////    ////////creditExamineReportViewModel.ProductNumber = finance.Produce.Code;

        ////    ////////// 产品详解
        ////    ////////creditExamineReportViewModel.ProductExplain = finance.Produce.Code;

        ////    ////////// 产品种类
        ////    ////////creditExamineReportViewModel.ProductCategorie = finance.Vehicle.BusinessType.ToString();

        ////    ////// 承租人
        ////    ////var lessee = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.主要申请人);
        ////    ////////creditExamineReportViewModel.LesseeName = lessee.Name;
        ////    ////////creditExamineReportViewModel.LesseeIdCard = lessee.IdentityType.Equals("身份证") ? lessee.Identity : null;
        ////    ////////creditExamineReportViewModel.LesseeMobile = lessee.Mobile;

        ////    ////// 共借人(最多一个)
        ////    ////var commonBorrwer = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.共同申请人) ?? new Applicant() { Name = string.Empty };
        ////    ////////creditExamineReportViewModel.CommonBorrwerName = commonBorrwer.Name;

        ////    ////// 保证人
        ////    ////////creditExamineReportViewModel.Guarantor = from applicant
        ////    ////                                         in finance.Applicant.ToList().FindAll(m => m.Type == Applicant.TypeEnum.担保人)
        ////    ////                                         select applicant.Name;

        ////    ////// 当前角色
        ////    ////var curentRole = roleManager.FindByIdAsync(curentUser.RoleId).Result;

        ////    ////if (curentRole != null)
        ////    ////{
        ////    ////    ////var trialUser = finance.CreditExamine.TrialUser ?? new AppUser();
        ////    ////    ////var reviewUser = finance.CreditExamine.ReviewUser ?? new AppUser();
        ////    ////    ////var approveUser = finance.CreditExamine.ApproveUser ?? new AppUser();
        ////    ////    ////var finalUser = finance.CreditExamine.FinalUser ?? new AppUser();

        ////    ////    ////creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(trialUser.Id, trialUser.Name);
        ////    ////    ////creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(reviewUser.Id, reviewUser.Name);
        ////    ////    ////creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(approveUser.Id, approveUser.Name);
        ////    ////    ////creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finalUser.Id, finalUser.Name);

        ////    ////    if (curentRole.Name.Equals("初审员"))
        ////    ////    {
        ////    ////        creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(curentUser.Id, curentUser.Name);
        ////    ////    }

        ////    ////    if (curentRole.Name.Equals("复审员"))
        ////    ////    {
        ////    ////        creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(curentUser.Id, curentUser.Name);
        ////    ////    }

        ////    ////    if (curentRole.Name.Equals("总经理"))
        ////    ////    {
        ////    ////        creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(curentUser.Id, curentUser.Name);
        ////    ////        creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(curentUser.Id, curentUser.Name);
        ////    ////    }
        ////    ////}

        ////    return null;
        ////}

        /////// <summary>
        /////// 编辑信审报告
        /////// </summary>
        /////// <param name="value">信审ViewModel</param>
        ////public void EditCreditExamine(CreditExamineViewModel value)
        ////{
        ////    if (value == null || value.FinanceId == null)
        ////    {
        ////        return;
        ////    }

        ////    // 获取该信审对应的融资实体
        ////    var finance = repository.Get(value.FinanceId);

        ////    if (finance == null)
        ////    {
        ////        return;
        ////    }

        ////    ////finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

        ////    ////// 信审ViewModel转信审实体，更新信审
        ////    ////Mapper.Map(value, finance.CreditExamine);

        ////    ////// 保证金
        ////    ////finance.CreditExamine.Margin = value.Margin1 + "-" + value.Margin2;

        ////    repository.Modify(finance);
        ////}

        /////// <summary>
        /////// 信审报告设置审批人
        /////// </summary>
        /////// <param name="financeId">融资标识</param>
        ////public void SetApprover(Guid financeId)
        ////{
        ////    var currentUser = userManager.CurrentUser();
        ////    var finance = repository.Get(financeId);

        ////    ////switch (currentUser.RoleId)
        ////    ////{
        ////    ////    case "BD42BEE1-05A4-E611-80C5-507B9DE4A488":
        ////    ////        finance.CreditExamine.TrialUser = currentUser;
        ////    ////        break;
        ////    ////    case "BE42BEE1-05A4-E611-80C5-507B9DE4A488":
        ////    ////        finance.CreditExamine.ReviewUser = currentUser;
        ////    ////        break;
        ////    ////    case "C242BEE1-05A4-E611-80C5-507B9DE4A488":
        ////    ////        finance.CreditExamine.ApproveUser = currentUser;
        ////    ////        finance.CreditExamine.FinalUser = currentUser;
        ////    ////        break;
        ////    ////    default:
        ////    ////        break;
        ////    ////}

        ////    repository.Modify(finance);
        ////}

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>融资审核ViewModel</returns>
        public FinanceAuidtViewModel GetFinanceAuidtByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取融资实体
            var finance = financeRepository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var financeAuditViewModel = new FinanceAuidtViewModel()
            {
                // 融资标识
                FinanceId = finance.Id,

                // 厂商指导价
                ManufacturerGuidePrice = finance.Vehicle.ManufacturerGuidePrice,

                // 融资项（Id、<Name_Maney>）
                FinancingItems = GetFinancingItemsOrCosts(finance)
            };

            // 部分映射
            var array = new string[] { "AdviceMoney", "AdviceRatio", "ApprovalMoney", "ApprovalRatio", "Payment", "Poundage" };
            financeAuditViewModel = PartialMapper(refObj: finance, outObj: financeAuditViewModel, array: array);

            if (financeAuditViewModel.Poundage == null)
            {
                financeAuditViewModel.Poundage = decimal.Parse("0.00");
            }

            // 映射 融资比例区间
            financeAuditViewModel = PartialMapper(refObj: finance.Produce, outObj: financeAuditViewModel, array: new string[] { "MinFinancingRatio", "MaxFinancingRatio" });

            return financeAuditViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        public void EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该融资审核对应的融资实体
            var finance = financeRepository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            // 建议融资金额、建议融资比例、审批融资金额、审批融资比例、月供额度、手续费
            var array = new string[] { "AdviceMoney", "AdviceRatio", "ApprovalMoney", "ApprovalRatio", "Payment", "Poundage" };
            finance = PartialMapper(refObj: value, outObj: finance, array: array);

            // 初审 修改融资项各金额
            if (!value.IsReview)
            {
                // 修改融资项各金额
                // finance.FinancialItem = EditFinanceAuidts(financingItems: finance.FinancialItem, financingItemCollection: value.FinancingItems);
            }

            financeRepository.Modify(finance);
        }

        /// <summary>
        /// 通过融资标识获取运营ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>运营ViewModel</returns>
        public OperationViewModel GetOperationByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = financeRepository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var operationReportViewModel = Mapper.Map<OperationViewModel>(finance.FinanceExtension) ?? new OperationViewModel();

            operationReportViewModel.FinanceId = finance.Id;

            // 先付月供
            operationReportViewModel.PayMonthly = finance.Payment;

            // 实际用款额
            operationReportViewModel.ActualAmount = finance.Principal;

            // 选择还款日、保证金、首次租金支付日期、一次性付息、
            var array = new string[] { "RepaymentDate", "Bail", "RepayRentDate", "OnePayInterest" };
            operationReportViewModel = PartialMapper(refObj: finance, outObj: operationReportViewModel, array: array);

            // 客户保证金比例
            operationReportViewModel.CustomerBailRatio = finance.Produce.MarginRate;

            // 融资项
            operationReportViewModel.FinancingItems = GetFinancingItemsOrCosts(finance);

            // 手续费
            operationReportViewModel.FinanceCosts = GetFinancingItemsOrCosts(finance, false);

            // 车辆补充信息
            var array1 = new string[] { "RegisterDate", "RunningMiles", "FactoryDate", "BusinessType", "PlateNo", "FrameNo", "EngineNo", "RegisterCity", "Condition" };
            operationReportViewModel = PartialMapper(refObj: finance.Vehicle, outObj: operationReportViewModel, array: array1);

            return operationReportViewModel;
        }

        /// <summary>
        /// 编辑运营
        /// </summary>
        /// <param name="value">运营ViewModel</param>
        public void EditOperation(OperationViewModel value)
        {
            if (value == null || value.FinanceId == null || !(new string[] { "Customer", "Channel" }).Contains(value.LoanPrincipal))
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = financeRepository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            finance.FinanceExtension = finance.FinanceExtension ?? new FinanceExtension();

            finance.FinanceExtension.LoanPrincipal = value.LoanPrincipal;

            if (value.NodeType.Equals("Customer"))
            {
                // 还款信息
                var customerArray = new string[] { "CustomerAccountName", "CustomerBankName", "CustomerBankCard" };
                finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: customerArray);

                if (!value.LoanPrincipal.Equals("Channel"))
                {
                    // 放款信息
                    var creditArray = new string[] { "CreditAccountName", "CreditBankName", "CreditBankCard" };
                    finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: creditArray);
                }

                // 车辆补充信息
                var array1 = new string[] { "RegisterDate", "RunningMiles", "FactoryDate", "BusinessType", "PlateNo", "FrameNo", "EngineNo", "RegisterCity", "Condition" };
                finance.Vehicle = PartialMapper(refObj: value, outObj: finance.Vehicle, array: array1);
            }
            else
            {
                // 先付月供
                finance.Payment = value.PayMonthly;

                // 实际用款额
                finance.Principal = value.ActualAmount;

                // 合同Json
                finance.FinanceExtension.ContactJson = value.ContactJson;

                // 选择还款日、首次租金支付日期、保证金、先付月供、一次性付息、实际用款额
                finance = PartialMapper(refObj: value, outObj: finance, array: new string[] { "RepaymentDate", "RepayRentDate", "Bail", "Payment", "OnePayInterest" });

                // 放款账户、放款账户开户行、放款账户卡号
                if (value.LoanPrincipal.Equals("Channel"))
                {
                    finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: new string[] { "CreditAccountName", "CreditBankName", "CreditBankCard" });
                }
            }

            financeRepository.Modify(finance);

            // 执行修改
            financeRepository.Commit();
        }

        /// <summary>
        ///  获取融资项或手续费
        /// </summary>
        /// <param name="finance">融资实体</param>
        /// <param name="isFinancing">是否为融资项</param>
        /// <returns>融资项</returns>
        private ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> GetFinancingItemsOrCosts(Finance finance, bool isFinancing = true)
        {
            var financingItemsOrCosts = new List<KeyValuePair<Guid, KeyValuePair<string, decimal?>>>();

            //// finance.FinancialItem.ToList().FindAll(m => m.IsFinancing == isFinancing).ForEach(item =>
            ////  {
            ////      financingItemsOrCosts.Add(new KeyValuePair<Guid, KeyValuePair<string, decimal?>>(item.Id, new KeyValuePair<string, decimal?>(item.Name, item.Money)));
            ////  });

            return financingItemsOrCosts;
        }

        /// <summary>
        /// 部分映射
        /// </summary>
        /// <typeparam name="refT">输入类型</typeparam>
        /// <typeparam name="outT">输出类型</typeparam>
        /// <param name="refObj">输入对象</param>
        /// <param name="outObj">输出对象</param>
        /// <param name="array">属性名数组</param>
        /// <returns>输出对象（地址不变）</returns>
        private outT PartialMapper<refT, outT>(refT refObj, outT outObj, string[] array = null) where outT : new()
        {
            if (refObj == null)
            {
                return outObj;
            }

            if (outObj == null)
            {
                ////outObj = Activator.CreateInstance<outT>();
                outObj = new outT();
            }

            // 字典记录属性的值
            var container = new Dictionary<object, object>();
            foreach (var item in refObj.GetType().GetProperties())
            {
                if (array == null || array.Contains(item.Name))
                {
                    container.Add(item.Name, item.GetValue(refObj));
                }
            }

            // 从字典取值，并对输出对象对应的属性赋值
            var outObjType = outObj.GetType();
            container.ToList().ForEach(item =>
                    {
                        var outObjPropertyInfo = outObjType.GetProperty(item.Key.ToString());

                        try
                        {
                            outObjPropertyInfo.SetValue(outObj, item.Value, null);
                        }
                        catch
                        {
                        }
                    });

            return outObj;
        }
    }
}
