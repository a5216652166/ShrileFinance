namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using Application.AppServices.VehicleAppservices;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Finance.Financial;
    using Core.Entities.Finance.Partners;
    using Core.Entities.Identity;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using Core.Produce;
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
        private readonly VehicleAppService vehicleAppService;

        public FinanceAppService(
            IFinanceRepository financeRepository,
            AppUserManager userManager,
            AppRoleManager roleManager,
            IContractRepository contractRepository,
            IPartnerRepository partnerRepository,
            IProduceRepository produceRepository,
            VehicleAppService vehicleAppService)
        {
            this.financeRepository = financeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.contractRepository = contractRepository;
            this.partnerRepository = partnerRepository;
            this.produceRepository = produceRepository;
            this.vehicleAppService = vehicleAppService;
        }

        /// <summary>
        /// 下载单身证明
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns></returns>
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
            var pair = new KeyValuePair<string, byte[]>($"单身证明书.pdf", GetFileBytes());

            byte[] GetFileBytes()
            {
                var fi = new FileInfo(path);
                var fs = fi.OpenRead();
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                return bytes;
            }

            return pair;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="value">视图</param>
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

        /// <summary>
        /// 获取合作商和用户
        /// </summary>
        /// <returns></returns>
        public PartnerAndUser GetPartnerAndUser()
        {
            var user = userManager.CurrentUser();
            var partner = partnerRepository.GetByUser(userManager.CurrentUser());

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
                Payment = Math.Round(Convert.ToDouble(finance.Principal * finance.OncePayMonths / finance.Produce.Periods), 2),
            };
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>融资审核ViewModel</returns>
        public FinanceAuidtViewModel GetFinanceAuidtByFinanceId(Guid financeId)
        {
            // 获取融资实体
            var finance = financeRepository.Get(financeId);

            // 实体转ViewModel
            var financeAuditViewModel = new FinanceAuidtViewModel()
            {
                // 融资标识
                FinanceId = finance.Id,

                // 融资项
                FinancialItem = Mapper.Map<IEnumerable<FinancialItemViewModel>>(finance.FinancialItem),

                // 厂商指导价
                ManufacturerGuidePrice = finance.Vehicle.ManufacturerGuidePrice,


                ////// 车辆销售指导价
                ////VehicleSalePrise = vehicleAppService.PostToGetVehiclePrise(finance.Vehicle.MakeCode,finance.Vehicle.FamilyCode).Result.Sale.Poor.Max,
            };

            // 部分映射
            var array = new string[] { nameof(finance.AdviceMoney), nameof(finance.AdviceRatio), nameof(finance.ApprovalMoney), nameof(finance.ApprovalRatio), nameof(finance.Payment), nameof(finance.Poundage) };

            financeAuditViewModel = PartialMapper(refObj: finance, outObj: financeAuditViewModel, array: array);

            financeAuditViewModel.Poundage = financeAuditViewModel.Poundage ?? finance.Produce.Poundage;

            return financeAuditViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        public void EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            // 获取该融资审核对应的融资实体
            var finance = financeRepository.Get(value.FinanceId);

            // 建议融资金额、审批融资金额、月供额度、手续费
            var array = new string[] { nameof(finance.AdviceMoney), nameof(finance.ApprovalMoney), nameof(finance.Payment), nameof(finance.Poundage) };
            finance = PartialMapper(refObj: value, outObj: finance, array: array);

            financeRepository.Modify(finance);
        }

        /// <summary>
        /// 通过融资标识获取运营ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>运营ViewModel</returns>
        public OperationViewModel GetOperationByFinanceId(Guid financeId)
        {
            // 获取信审报告实体
            var finance = financeRepository.Get(financeId);

            // 实体转ViewModel
            var operationReportViewModel = Mapper.Map<OperationViewModel>(finance.FinanceExtension) ?? new OperationViewModel();

            operationReportViewModel.FinanceId = finance.Id;

            // 先付月供
            operationReportViewModel.PayMonthly = finance.Payment;

            // 实际用款额
            operationReportViewModel.ActualAmount = finance.Principal;

            // 选择还款日、保证金、首次租金支付日期、一次性付息
            var array = new string[] { nameof(finance.RepaymentDate), nameof(finance.Bail), nameof(finance.RepayRentDate), nameof(finance.OnePayInterest) };
            operationReportViewModel = PartialMapper(refObj: finance, outObj: operationReportViewModel, array: array);

            // 客户保证金比例
            operationReportViewModel.CustomerBailRatio = finance.Produce.CustomerBailRatio;

            // 融资项
            operationReportViewModel.FinancialItem = Mapper.Map<IEnumerable<FinancialItemViewModel>>(finance.FinancialItem);

            // 车辆补充信息
            var array1 = new string[] { nameof(finance.Vehicle.RegisterDate), nameof(finance.Vehicle.RunningMiles), nameof(finance.Vehicle.FactoryDate), nameof(finance.Vehicle.BusinessType), nameof(finance.Vehicle.PlateNo), nameof(finance.Vehicle.FrameNo), nameof(finance.Vehicle.EngineNo), nameof(finance.Vehicle.RegisterCity), nameof(finance.Vehicle.Condition) };
            operationReportViewModel = PartialMapper(refObj: finance.Vehicle, outObj: operationReportViewModel, array: array1);

            return operationReportViewModel;
        }

        /// <summary>
        /// 编辑运营
        /// </summary>
        /// <param name="value">运营ViewModel</param>
        public void EditOperation(OperationViewModel value)
        {
            // 获取该信审对应的融资实体
            var finance = financeRepository.Get(value.FinanceId);

            finance.FinanceExtension = finance.FinanceExtension ?? new FinanceExtension();

            finance.FinanceExtension.LoanPrincipal = value.LoanPrincipal;

            if (value.NodeType.Equals("Customer"))
            {
                // 还款信息
                var customerArray = new string[] { nameof(value.CustomerAccountName), nameof(value.CustomerBankName), nameof(value.CustomerBankCard) };
                finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: customerArray);

                // 放款信息
                finance.FinanceExtension.CreditAccountName = value.CreditAccountName;

                ////var creditArray = new string[] { nameof(value.CreditAccountName), nameof(value.CreditBankName), nameof(value.CreditBankCard) };
                ////finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: creditArray);

                // 车辆补充信息
                var array1 = new string[] { nameof(value.RegisterDate), nameof(value.RunningMiles), nameof(value.FactoryDate), nameof(value.BusinessType), nameof(value.PlateNo), nameof(value.FrameNo), nameof(value.EngineNo), nameof(value.RegisterCity), nameof(value.Condition) };
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
                finance = PartialMapper(refObj: value, outObj: finance, array: new string[] { nameof(value.RepaymentDate), nameof(value.RepayRentDate), nameof(value.Bail), nameof(value.PayMonthly), nameof(value.OnePayInterest) });

                // 放款账户、放款账户开户行、放款账户卡号
                finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: new string[] { "CreditAccountName", "CreditBankName", "CreditBankCard" });
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
