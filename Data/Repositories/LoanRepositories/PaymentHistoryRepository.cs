namespace Data.Repositories
{
    using System;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class PaymentHistoryRepository : BaseRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(MyContext context) : base(context)
        {
        }

        public override Guid Create(PaymentHistory entity)
        {
            if (Guid.Empty.Equals(entity.Id))
            {
                entity.Id = Guid.NewGuid();
            }

            return base.Create(entity);
        }
    }
}
