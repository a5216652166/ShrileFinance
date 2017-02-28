namespace TimeService
{
    using System.ServiceProcess;

    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static void Main()
        {
            var servicesToRun = default(ServiceBase[]);

            servicesToRun = new ServiceBase[]
            {
                new Service()
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
