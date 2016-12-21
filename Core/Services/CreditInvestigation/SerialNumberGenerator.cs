namespace Core.Services.CreditInvestigation
{
    using System;

    public sealed class SerialNumberGenerator
    {
        private static SerialNumberGenerator instance;
        private readonly DateTime date;
        private int seed;

        static SerialNumberGenerator()
        {
            instance = new SerialNumberGenerator(0);
        }

        private SerialNumberGenerator(int baseSeed)
        {
            seed = baseSeed;
            date = DateTime.Now.Date;
        }

        public static SerialNumberGenerator GetInstance(Func<int> getBaseSeed)
        {
            if (!instance.IsToday())
            {
                var baseSeed = getBaseSeed();

                instance = new SerialNumberGenerator(baseSeed);
            }

            return instance;
        }

        public int GetNext()
        {
            return seed++;
        }

        private bool IsToday()
        {
            return DateTime.Now.Date.Equals(date);
        }
    }
}
