namespace Data.Repositories
{
    using Core.Entities.Loan;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;

    public class PaymentHistoryRepository : BaseRepository<PaymentHistory>, IPaymentHistoryRepository, IProcessable
    {
        public PaymentHistoryRepository(MyContext context) : base(context)
        {
        }

        public virtual bool Hidden { get; set; }
    }
}
