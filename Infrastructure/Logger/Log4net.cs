namespace Infrastructure.Logger
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using log4net;
    using log4net.Config;

    public class Log4net : ILogger.ILogger
    {
        private readonly ILog log;

        public Log4net()
        {
            var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}log4net.config";
            var fileinfo = new FileInfo(filepath);

            XmlConfigurator.Configure(fileinfo);

            log = LogManager.GetLogger("Logger");
        }

        void ILogger.ILogger.Debug(object message, Exception exception)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Debug(message);
                }
                else
                {
                    log.Debug(message, exception);
                }
            });
        }

        void ILogger.ILogger.Info(object message, Exception exception)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Info(message);
                }
                else
                {
                    log.Info(message, exception);
                }
            });
        }

        void ILogger.ILogger.Warn(object message, Exception exception)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Warn(message);
                }
                else
                {
                    log.Warn(message, exception);
                }
            });
        }

        void ILogger.ILogger.Error(object message, Exception exception)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Error(message);
                }
                else
                {
                    log.Error(message, exception);
                }
            });
        }

        void ILogger.ILogger.Fatal(object message, Exception exception)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Fatal(message);
                }
                else
                {
                    log.Fatal(message, exception);
                }
            });
        }
    }
}
