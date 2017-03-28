namespace Application
{
    using System;
    using System.Linq;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories.DatagramRepositories;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Data;
    using Data.Repositories;

    public class TimeAppService
    {
        private readonly ICreditContractRepository creditContractRepository;
        private readonly ILoanRepository loanRepostiory;
        private readonly ITraceRepostitory traceRepostitory;

        public TimeAppService()
        {
            var context = new MyContext();

            creditContractRepository = new CreditContractRepository(context);
            loanRepostiory = new LoanRepository(context);
            traceRepostitory = new TraceRepository(context);
        }

        public void TimeService()
        {
            // 合同到期定时终止
            ContractEnd();

            // 借据到期失效
            ////LoanEnd();
        }

        /// <summary>
        /// 合同到期定时终止
        /// </summary>
        private void ContractEnd()
        {
            var creditContracts = creditContractRepository.GetAll(m => m.EffectiveStatus == CreditContractStatusEnum.生效);

            foreach (var item in creditContracts)
            {
                if (item.ExpirationDate <= DateTime.Now)
                {
                    item.EffectiveStatus = CreditContractStatusEnum.失效;
                    creditContractRepository.Modify(item);

                    var count = traceRepostitory.CountByDateCreatedAndReference(DateTime.Now.Date, item.Id, TraceTypeEnum.签订授信合同);
                    if (count == 0)
                    {
                        var trace = new Trace(item.Id, TraceTypeEnum.签订授信合同, item.EffectiveDate, item.Organization.Property.InstitutionChName, "贷款合同：" + item.CreditContractCode + "终止");
                        traceRepostitory.Create(trace);
                    }
                }

                creditContractRepository.Commit();
            }
        }

        /// <summary>
        /// 借据到期失效（根据借据余额进行判断，当到期之后借据余额为已还清，则设置为作废，否则不作废，只改变业务数据状态不发送报文）
        /// </summary>
        private void LoanEnd()
        {
            var loans = loanRepostiory.GetAll(m => m.Status == LoanStatusEnum.正常 || m.Status == LoanStatusEnum.逾期);
            if (loans.Count() > 0)
            {
                foreach (var item in loans)
                {
                    if (item.Balance == item.Principle && item.MatureDate < DateTime.Now.Date)
                    {
                        item.Status = LoanStatusEnum.已还清;
                        loanRepostiory.Modify(item);
                    }
                }

                loanRepostiory.Commit();
            }
        }
    }
}
