namespace Data
{
    using System.Data.Entity;

    public class CarHomeContext : DbContext
    {
        public CarHomeContext() : base("name=connHomeCar")
        {
        }
    }
}
