namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class CarHomeContext : DbContext
    {
        public CarHomeContext() : base("name=connHomeCar")
        {

        }
    }
}
