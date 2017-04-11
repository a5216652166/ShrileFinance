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
        private readonly FileSystemAppService fileSystemAppService;

        public FinanceAppService(
            IFinanceRepository financeRepository,
            AppUserManager userManager,
            AppRoleManager roleManager,
            IContractRepository contractRepository,
            IPartnerRepository partnerRepository,
            IProduceRepository produceRepository,
            VehicleAppService vehicleAppService,
            FileSystemAppService fileSystemAppService)
        {
            this.financeRepository = financeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.contractRepository = contractRepository;
            this.partnerRepository = partnerRepository;
            this.produceRepository = produceRepository;
            this.vehicleAppService = vehicleAppService;
            this.fileSystemAppService = fileSystemAppService;
        }

        public KeyValuePair<string, byte[]> DownloadFiles(Guid financeId, int sign)
        {
            var file = default(KeyValuePair<string, byte[]>);
            switch (sign)
            {
                case 1:
                    file = DownloadSignle(financeId);
                    break;
                case 2:
                    file = DownLoadApproval(financeId);
                    break;
                default:
                    throw new Core.Exceptions.ArgumentAppException("下载标识异常");
            }

            return file;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="value">视图</param>
        public void Create(FinanceApplyViewModel value)
        {
            var finance = Mapper.Map<Finance>(value);

            finance.FinanceItems = Mapper.Map<ICollection<FinanceItem>>(value.FinanceItems);

            finance.Applicant = Mapper.Map<ICollection<Applicant>>(value.Applicant);

            finance.CreateBy = userManager.CurrentUser();
            finance.CreateOf = partnerRepository.GetByUser(userManager.CurrentUser());

            finance.Produce = produceRepository.Get(value.ProduceId);

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

            new UpdateBind().Bind(finance.FinanceItems, model.FinanceItems);

            new UpdateBind().Bind(finance.Applicant, model.Applicant);

            finance.Produce = produceRepository.Get(model.ProduceId);
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
                CustomerBail = finance.Margin,
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

            var seriesCode = vehicleAppService.GetSeriesCode(finance.Vehicle.VehicleKey) ?? string.Empty;

            var vehicleSalePrice = vehicleAppService.PostToGetVehiclePrise(finance.Vehicle.VehicleKey, seriesCode).Result.Sale.Good;

            var vehicleBuyPrice = vehicleAppService.PostToGetVehiclePrise(finance.Vehicle.VehicleKey, seriesCode).Result.Buy.Good;

            // 实体转ViewModel
            var financeAuditViewModel = new FinanceAuidtViewModel()
            {
                // 融资标识
                FinanceId = finance.Id,

                // 融资项
                FinancialItem = Mapper.Map<IEnumerable<FinanceItemViewModel>>(finance.FinanceItems),

                // 厂商指导价
                ManufacturerGuidePrice = finance.Vehicle.ManufacturerGuidePrice,

                // 车辆销售指导价
                VehicleSalePriseMin = vehicleSalePrice.Min,
                VehicleSalePriseMax = vehicleSalePrice.Max,

                // 车辆收购指导价
                VehicleBuyPriseMin = vehicleBuyPrice.Min,
                VehicleBuyPriseMax = vehicleBuyPrice.Max,

                ProduceRateMonth = finance.Produce.RateMonth,
                ProducePeriods = finance.Produce.Periods
            };

            // 部分映射
            var array = new string[] { nameof(finance.Margin), nameof(finance.ApprovalMargin), nameof(finance.ApprovalMoney), nameof(finance.Payment), nameof(finance.ApprovalPoundage), nameof(finance.Poundage), nameof(finance.SelfPrincipal) };

            financeAuditViewModel = PartialMapper(refObj: finance, outObj: financeAuditViewModel, array: array);

            financeAuditViewModel.Poundage = financeAuditViewModel.Poundage ?? finance.Produce.CustomerCostRatio * finance.FinanceItems.Sum(m => m.FinancialAmount);

            // 审批保证金、审批手续费设置默认值
            financeAuditViewModel.ApprovalMargin = financeAuditViewModel.ApprovalMargin ?? financeAuditViewModel.Margin;
            financeAuditViewModel.ApprovalPoundage = financeAuditViewModel.ApprovalPoundage ?? financeAuditViewModel.Poundage;

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

            // 保证金、审批融资金额、月供额度、手续费
            var array = new string[] { nameof(value.Margin), nameof(value.ApprovalMargin), nameof(value.ApprovalMoney), nameof(value.Payment), nameof(value.Poundage), nameof(value.ApprovalPoundage) };
            finance = PartialMapper(refObj: value, outObj: finance, array: array);

            finance.Bail = finance.Margin;

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
            operationReportViewModel.FinancialItem = Mapper.Map<IEnumerable<FinanceItemViewModel>>(finance.FinanceItems);

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
                ////// 还款信息
                ////var customerArray = new string[] { nameof(value.CustomerAccountName), nameof(value.CustomerBankName), nameof(value.CustomerBankCard) };
                ////finance.FinanceExtension = PartialMapper(refObj: value, outObj: finance.FinanceExtension, array: customerArray);

                // 放款信息
                finance.FinanceExtension.CreditAccountName = value.CreditAccountName;

                // 还款信息
                finance.FinanceExtension.CustomerAccountName = value.CustomerAccountName;

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

        private KeyValuePair<string, byte[]> DownloadSignle(Guid financeId)
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
            if (info.Identity.Length == 18)
            {
                param.Add("[@年@]", info.Identity.Substring(6, 4));
                param.Add("[@月@]", info.Identity.Substring(10, 2));
                param.Add("[@日@]", info.Identity.Substring(12, 2));
            }
            else
            {
                param.Add("[@年@]", string.Empty.PadLeft(4));
                param.Add("[@月@]", string.Empty.PadLeft(2));
                param.Add("[@日@]", string.Empty.PadLeft(2));
            }

            param.Add("[@合作商@]", finance.CreateOf.Name);

            var car = new VehicleAppService();
            param.Add("[@品牌@]", car.GetCarBrand(finance.Vehicle.VehicleKey));
            param.Add("[@车牌号@]", string.IsNullOrWhiteSpace(finance.Vehicle.PlateNo) ? string.Empty.PadLeft(8) : finance.Vehicle.PlateNo);
            param.Add("[@识别号@]", finance.Vehicle.FrameNo);

            var pair = CreatPDF("UnmarriedStatement.docx", "单身证明.pdf", param);

            return pair;
        }

        private KeyValuePair<string, byte[]> CreatPDF(string templateName, string fileName, Dictionary<string, string> param)
        {
            var wtp = new WordToPDF();
            var virtualPath = wtp.GetPath(@"~\Upload\");

            var tempFile = fileSystemAppService.CreatFile(virtualPath + "Template\\" + templateName, true);

            var count = tempFile.Path.LastIndexOf("\\");
            var ss = tempFile.Path.Substring(0, count);

            var path = wtp.TransformWordToPDF(wtp.GetPath(ss) + tempFile.Path.Substring(count, tempFile.Path.Length - count), virtualPath + "Temps\\" + Guid.NewGuid() + ".pdf", param);

            var pdfFile = fileSystemAppService.CreatFile(path);
            var pair = new KeyValuePair<string, byte[]>(fileName, pdfFile.Stream.GetBuffer());

            return pair;
        }

        private KeyValuePair<string, byte[]> DownLoadApproval(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);

            var param = new Dictionary<string, string>();
            var info = finance.Applicant.Where(m => m.Type == TypeEnum.担保人).ToArray();

            param.Add("【[@合同编号1@]】", string.Empty);
            if (info.Length >= 1)
            {
                param.Add("[@保证人1@]", info[0].Name);
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

            var applicant = finance.Applicant.SingleOrDefault(m => m.Type == TypeEnum.共同申请人);
            var customer = finance.Applicant.Single(m => m.Type == TypeEnum.主要申请人);
            param.Add("[@客户@]", customer.Name);

            if (applicant == null)
            {
                param.Add("【[@承租人@]】", string.Empty);
            }
            else
            {
                param.Add("[@承租人@]", applicant.Name);
            }

            param.Add("[@渠道商@]", finance.CreateOf.Name);
            param.Add("[@所在区域@]", finance.CreateOf.ProxyArea);
            param.Add("【[@抵押要求@]】", string.Empty);
            param.Add("【[@上牌要求@]】", string.Empty);

            var upper = new MoneyToUpper();
            param.Add("[@人民币1@]", upper.RMBToUpper(finance.ApprovalMoney == null ? 0 : finance.ApprovalMoney.Value));
            param.Add("[@金额1@]", Convert.ToString(finance.ApprovalMoney == null ? 0 : finance.ApprovalMoney.Value));
            param.Add("[@人民币2@]", upper.RMBToUpper(finance.Poundage == null ? 0 : finance.Poundage.Value));
            param.Add("[@金额2@]", Convert.ToString(finance.Poundage == null ? 0 : finance.Poundage.Value));
            param.Add("[@人民币3@]", upper.RMBToUpper(finance.Margin == null ? 0 : finance.Margin.Value));
            param.Add("[@金额3@]", Convert.ToString(finance.Margin == null ? 0 : finance.Margin.Value));
            param.Add("[@人民币4@]", string.Empty.PadLeft(12));
            param.Add("[@金额4@]", string.Empty.PadLeft(8));
            param.Add("[@人民币5@]", string.Empty.PadLeft(12));
            param.Add("[@金额5@]", string.Empty.PadLeft(8));

            var ratio = finance.Produce.PrincipalRatios.ToList();

            for (int i = 0; i < ratio.Count; i++)
            {
                var value = Math.Round((finance.ApprovalMoney / 10000 * ratio[i].Factor).Value, 2);
                param.Add($"[@人民币{i + 6}@]", upper.RMBToUpper(value));
                param.Add($"[@金额{i + 6}@]", Convert.ToString(value));
            }

            param.Add("[@融资期限@]", finance.Produce.Periods.ToString());
            ////param.Add("[@人民币6@]", string.Empty.PadLeft(12));
            ////param.Add("[@金额6@]", string.Empty.PadLeft(8));
            ////param.Add("[@人民币7@]", string.Empty.PadLeft(12));
            ////param.Add("[@金额7@]", string.Empty.PadLeft(8));
            ////param.Add("[@人民币8@]", string.Empty.PadLeft(12));
            ////param.Add("[@金额8@]", string.Empty.PadLeft(8));
            ////param.Add("[@人民币9@]", string.Empty.PadLeft(12));
            ////param.Add("[@金额9@]", string.Empty.PadLeft(8));
            ////param.Add("[@人民币10@]", string.Empty.PadLeft(12));
            ////param.Add("[@金额10@]", string.Empty.PadLeft(8));

            param.Add("[@还款日@]", Convert.ToString(finance.RepaymentDate == null ? 15 : finance.RepaymentDate.Value));

            var date = finance.RepayRentDate;
            param.Add("[@年1@]", date.Value.Year.ToString());
            param.Add("[@月1@]", date.Value.Month.ToString());
            param.Add("[@日1@]", date.Value.Day.ToString());
            param.Add("【[@年2@]】", string.Empty.PadLeft(4));
            param.Add("【[@月2@]】", string.Empty.PadLeft(2));
            param.Add("【[@日2@]】", string.Empty.PadLeft(2));
            param.Add("[@产品大类@]", finance.Produce.ProduceType.ToString());
            param.Add("[@产品代码@]", finance.Produce.Code);

            var pair = CreatPDF("Approval.docx", "个人按揭客户审批通知书.pdf", param);

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
    }
}
