namespace Core.Entities.Vehicle
{
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
                Sale = new Sale();
                Buy = new Buy();
            }

            public Sale Sale { get; set; }

            public Buy Buy { get; set; }
        }

        public class Sale
        {
            public Sale()
            {
                VeryGood = new VeryGood();
                Good = new Good();
                Poor = new Poor();
            }

            public VeryGood VeryGood { get; set; }

            public Good Good { get; set; }

            public Poor Poor { get; set; }
        }     

        public class Buy
        {
            public Buy()
            {
                VeryGood = new VeryGood();
                Good = new Good();
                Poor = new Poor();
            }

            public VeryGood VeryGood { get; set; }

            public Good Good { get; set; }

            public Poor Poor { get; set; }
        }

        public class VeryGood
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
