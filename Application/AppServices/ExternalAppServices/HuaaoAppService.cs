namespace Application.AppServices.ExternalAppServices
{
    using System;
    using System.Linq;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;

    public class HuaaoAppService
    {
        private readonly IFinanceRepository financeRepository;
        private readonly IPartnerRepository partnerRepository;

        public HuaaoAppService(
            IFinanceRepository financeRepository,
            IPartnerRepository partnerRepository)
        {
            this.financeRepository = financeRepository;
            this.partnerRepository = partnerRepository;
        }

        /// <summary>
        /// 获取融资信息
        /// </summary>
        /// <param name="partnerName">合作商名</param>
        /// <param name="identity">证件号</param>
        /// <param name="frameNo">车架号</param>
        /// <returns></returns>
        public Finance GetFinance(string partnerName, string identity, string frameNo)
        {
            var query = financeRepository
                .GetAll(m =>
                    m.Bail != null &&
                    m.Applicant.Any(ma => ma.Identity == identity && ma.Type == Applicant.TypeEnum.主要申请人) &&
                    m.Vehicle.FrameNo == frameNo);

            if (!string.IsNullOrEmpty(partnerName))
            {
                query.Where(m => m.CreateOf.Name == partnerName);
            }

            var finance = query
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
            
            return finance;
        }

        /// <summary>
        /// 保证金缴费
        /// </summary>
        /// <param name="financeId">融资标识</param>
        public void PayBail(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);

            finance.PayBail();
            financeRepository.Commit();
        }

        /// <summary>
        /// 撤销已缴保证金
        /// </summary>
        /// <param name="financeId">融资标识</param>
        public void RevertBail(Guid financeId)
        {
            var finance = financeRepository.Get(financeId);

            finance.RevertBail();
            financeRepository.Commit();
        }
    }
}
