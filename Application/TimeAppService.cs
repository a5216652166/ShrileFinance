namespace Application
{
    using System;
    using System.Linq;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using Data;
    using Data.Repositories;

    public class TimeAppService
    {
        private readonly ICreditContractRepository contractRepository;
        private readonly ILoanRepository loanRepostiory;
        private readonly ITraceRepostitory traceRepostitory;

        public TimeAppService()
        {
            MyContext context = new MyContext();
            this.contractRepository = new CreditContractRepository(context);
            loanRepostiory = new LoanRepository(context);
            traceRepostitory = new TraceRepository(context);
        }

        public void TimeService()
        {
            ContractEnd();
        }

        /// <summary>
        /// 合同到期定时终止
        /// </summary>
        private void ContractEnd()
        {
            var aaa = contractRepository.GetAll();
            var contract = contractRepository.GetAll(m => m.EffectiveStatus == CreditContractStatusEnum.生效);

            if (contract.Count() > 0)
            {
                foreach (var item in contract)
                {
                    if (item.ExpirationDate <= DateTime.Now)
                    {
                        item.EffectiveStatus = CreditContractStatusEnum.失效;
                        contractRepository.Modify(item);
                        var count = traceRepostitory.CountByDateCreatedAndReference(DateTime.Now.Date, item.Id, TraceTypeEnum.签订授信合同);
                        if (count == 0)
                        {
                            var trace = new Trace(item.Id, TraceTypeEnum.签订授信合同, item.EffectiveDate, item.Organization.Property.InstitutionChName, "贷款合同：" + item.CreditContractCode + "终止");
                            traceRepostitory.Create(trace);
                        }
                    }
                }
            }

            contractRepository.Commit();
        }
    }
}
