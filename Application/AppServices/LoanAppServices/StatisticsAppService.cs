namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.TreeGrid;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class StatisticsAppService
    {
        private readonly ICreditContractRepository repository;

        public StatisticsAppService(ICreditContractRepository repository)
        {
            this.repository = repository;
        }

        public List<CreditCountViewModel> GetByCreditCount(List<CreditContract> creditCount)
        {
            List<CreditCountViewModel> creditCountList = new List<CreditCountViewModel>();
            if (creditCount != null)
            {
                foreach (var credit in creditCount)
                {
                    List<CreditCountViewModel> children = new List<CreditCountViewModel>();

                    // 添加子项
                    if (credit.Loans != null)
                    {
                        foreach (var loan in credit.Loans)
                        {
                            children.Add(new CreditCountViewModel
                            {
                                Id = loan.Id,
                                Amount = loan.Principle,
                                Balance = loan.Balance,
                                Code = loan.ContractNumber,
                                CreateDate = loan.SpecialDate,
                                EndDate = loan.MatureDate,
                                Type = CreditCountType.借据.ToString(),
                            });
                        }
                    }

                    creditCountList.Add(new CreditCountViewModel
                    {
                        Code = credit.CreditContractCode,
                        Amount = credit.CreditLimit,
                        Balance = credit.CalculateCreditBalance(),
                        CreateDate = credit.EffectiveDate,
                        EndDate = credit.ExpirationDate,
                        Id = credit.Id,
                        Children = children,
                        Type = CreditCountType.授信.ToString(),
                        InstitutionChName = credit.Organization.Property.InstitutionChName,
                        State = "closed"
                    });
                }
            }

            return creditCountList;
        }

        public IPagedList<CreditCountViewModel> TreeGridPageList(Guid? organizateId, int page, int rows)
        {
            var creditContract = repository.GetAll().ToList();
            List<CreditCountViewModel> creditCountList = new List<CreditCountViewModel>();
            IEnumerable<CreditContract> creditCount;

            if (!string.IsNullOrEmpty(organizateId.ToString()))
            {
                creditCount = creditContract.Where(m => m.OrganizationId == organizateId);
                creditCountList = GetByCreditCount(creditCount.ToList());
            }
            else
            {
                creditCountList = GetByCreditCount(creditContract);
            }

            creditCountList = creditCountList.OrderByDescending(m => m.Id).ToList();
            var pagedList = creditCountList.ToPagedList(page, rows);

            return pagedList;
        }
    }
}
