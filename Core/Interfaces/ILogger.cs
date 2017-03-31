namespace Core.Interfaces
{
    using System;

    public interface ILogger
    {
        void Debug(object message, Exception exception = null);

        void Info(object message, Exception exception = null);

        void Warn(object message, Exception exception = null);

        void Error(object message, Exception exception = null);

        void Fatal(object message, Exception exception = null);
    }
}
