namespace Application
{
    using System;
    using System.Linq;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using Data;
    using Data.Repositories;

    public class TimeAppService
    {
        private readonly ICreditContractRepository contractRepository;
        private readonly ILoanRepository loanRepostiory;

        public TimeAppService()
        {
            MyContext context = new MyContext();
            this.contractRepository = new CreditContractRepository(context); ;
            loanRepostiory = new LoanRepository(context);
        }

        public void TimeService()
        {
            var contract = contractRepository.GetAll(m => m.EffectiveStatus == Core.Entities.Loan.CreditContractStatusEnum.生效);

            //var loans = loanRepostiory.GetAll(m => m.Status == LoanStatusEnum.正常);
            if (contract.Count()>0)
            {
                foreach (var item in contract)
                {
                    if(item.ExpirationDate <= DateTime.Now)
                    {
                        item.EffectiveStatus = CreditContractStatusEnum.失效;
                        contractRepository.Modify(item);
                    }
                }
            }
            contractRepository.Commit();
        }
    }
}
