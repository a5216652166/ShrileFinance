namespace Application.ViewModels.Loan.CreditViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class CreditContractViewModel
    {
        public enum CreditContractStatusEnum : byte
        {
            生效 = 0,
            失效 = 1,
            未结清 = 2,
            作废 = 3
        }

        public enum HiddenEnum : byte
        {
            审核中 = 1,
            完成 = 2,
            作废 = 3,
        }

        public Guid? Id { get; set; }

        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public string CreditContractCode { get; set; }

        public HiddenEnum Hidden { get; set; }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 授信额度
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 授信余额
        /// </summary>
        public decimal CreditBalance { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditContractStatusEnum EffectiveStatus { get; set; }

        public string OrganizationName { get; set; }

        public ICollection<LoanViewModels.LoanViewModel> Loans { get; set; }

        /// <summary>
        /// 是否有担保
        /// </summary>
        public bool HasGuarantee { get; set; }

        /// <summary>
        /// 担保合同(服务页面)
        /// </summary>
        public virtual ICollection<GuranteeContractViewModel> GuranteeContract { get; set; }

        /// <summary>
        /// 担保合同(协调后台)
        /// </summary>
        public virtual ICollection<GuarantyContractViewModel> GuarantyContract { get; set; }

        /// <summary>
        /// 贷款合同ViewModel数据对接(服务页面)
        /// </summary>
        /// <param name="model">贷款合同ViewModel</param>
        internal void DataConvertForGuranteeContract()
        {
            var model = this;

            // 担保合同（服务页面）集合
            model.GuranteeContract = new List<GuranteeContractViewModel>();

            if (model.GuarantyContract == null)
            {
                return;
            }

            // 遍历 担保合同（协调后台）集合
            foreach (var item in model.GuarantyContract)
            {
                // 担保合同(服务页面)  局部变量 
                var guranteeContractViewModel = new GuranteeContractViewModel();

                // 区分 保证/质押/抵押
                if (item is GuarantyContractPledgeViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.质押;

                    guranteeContractViewModel.PledgeGuarantyContractViewModel = (GuarantyContractPledgeViewModel)item;
                }
                else if (item is GuarantyContractMortgageViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.抵押;

                    guranteeContractViewModel.MortgageGuarantyContractViewModel = (GuarantyContractMortgageViewModel)item;
                }
                else if (item is GuarantyContractViewModel)
                {
                    guranteeContractViewModel.ContractType = GuranteeContractViewModel.ContractTypeEnum.保证;

                    guranteeContractViewModel.GuarantyContractViewModel = item;
                }

                // 区分 机构/自然人
                if (item.Guarantor is GuarantyOrganizationViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.机构;

                    guranteeContractViewModel.GuarantyOrganizationViewModel = (GuarantyOrganizationViewModel)item.Guarantor;
                }
                else if (item.Guarantor is GuarantyPersonViewModel)
                {
                    guranteeContractViewModel.GuarantorType = GuranteeContractViewModel.GuarantorTypeEnum.自然人;

                    guranteeContractViewModel.GuarantyPersonViewModel = (GuarantyPersonViewModel)item.Guarantor;
                }

                // 担保合同（服务页面）集合 接收数据
                model.GuranteeContract.Add(guranteeContractViewModel);
            }
        }

        /// <summary>
        /// 贷款合同ViewModel数据对接（协调后台）
        /// </summary>
        /// <param name="model">贷款合同ViewModel</param>
        internal void DataConvertForGurantyContract()
        {
            var model = this;

            // 担保合同（协调合同）集合
            model.GuarantyContract = new List<GuarantyContractViewModel>();

            if (model.GuranteeContract == null)
            {
                return;
            }

            // 遍历 担保合同（服务页面）集合
            foreach (var item in model.GuranteeContract)
            {
                // 区分 保证/质押/抵押
                if (item.ContractType == GuranteeContractViewModel.ContractTypeEnum.保证)
                {
                    model.GuarantyContract.Add(item.GuarantyContractViewModel);
                }
                else if (item.ContractType == GuranteeContractViewModel.ContractTypeEnum.抵押)
                {
                    model.GuarantyContract.Add(item.MortgageGuarantyContractViewModel);
                }
                else if (item.ContractType == GuranteeContractViewModel.ContractTypeEnum.质押)
                {
                    model.GuarantyContract.Add(item.PledgeGuarantyContractViewModel);
                }

                // 区分 机构/自然人
                if (item.GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.机构)
                {
                    model.GuarantyContract.Last().Guarantor = item.GuarantyOrganizationViewModel;
                }
                else if (item.GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.自然人)
                {
                    model.GuarantyContract.Last().Guarantor = item.GuarantyPersonViewModel;
                }
            }

            ////// 遍历 担保合同（服务页面）集合
            ////for (var i = 0; i < guranteeConList.Count(); i++)
            ////{
            ////    // 区分 保证/质押/抵押
            ////    if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.保证)
            ////    {
            ////        model.GuarantyContract.Add(guranteeConList[i].GuarantyContractViewModel);
            ////    }
            ////    else if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.抵押)
            ////    {
            ////        model.GuarantyContract.Add(guranteeConList[i].MortgageGuarantyContractViewModel);
            ////    }
            ////    else if (guranteeConList[i].ContractType == GuranteeContractViewModel.ContractTypeEnum.质押)
            ////    {
            ////        model.GuarantyContract.Add(guranteeConList[i].PledgeGuarantyContractViewModel);
            ////    }
            ////    // 区分 机构/自然人
            ////    if (guranteeConList[i].GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.机构)
            ////    {
            ////        model.GuarantyContract.ToList()[i].Guarantor = guranteeConList[i].GuarantyOrganizationViewModel;
            ////    }
            ////    else if (guranteeConList[i].GuarantorType == GuranteeContractViewModel.GuarantorTypeEnum.自然人)
            ////    {
            ////        model.GuarantyContract.ToList()[i].Guarantor = guranteeConList[i].GuarantyPersonViewModel;
            ////    }
            ////}
        }
    }
}
