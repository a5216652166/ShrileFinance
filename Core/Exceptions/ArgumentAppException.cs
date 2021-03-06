﻿namespace Core.Exceptions
{
    using System;

    /// <summary>
    /// 参数异常
    /// </summary>
    public class ArgumentAppException : AppException
    {
        private string paramName;

        public ArgumentAppException(string message = null, string paramName = null, Exception innerException = null) : base(message, innerException)
        {
            this.paramName = paramName;
        }

        public virtual string ParamName
        {
            get { return paramName; }
        }
    }
}
