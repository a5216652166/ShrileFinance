namespace Data.Repositories
{
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class PaymentHistoryRepository : BaseRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(MyContext context) : base(context)
        {
        }
    }
}
