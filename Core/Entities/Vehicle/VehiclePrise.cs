namespace Core.Entities.Vehicle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VehiclePrise
    {
        public class Rootobject
        {
            public Rootobject()
            {
                Result = new Result();
            }

            public int Sign { get; set; }

            public Result Result { get; set; }
        }

        public class Result
        {
            public Result()
            {
                VeryGood = new Verygood();
                Good = new Good();
                Poor = new Poor();
            }

            public Verygood VeryGood { get; set; }

            public Good Good { get; set; }

            public Poor Poor { get; set; }
        }

        public class Verygood
        {
            public string Min { get; set; }

            public string Max { get; set; }
        }

        public class Good
        {
            public string Min { get; set; }

            public string Max { get; set; }
        }

        public class Poor
        {
            public string Min { get; set; }

            public string Max { get; set; }
        }
    }
}
