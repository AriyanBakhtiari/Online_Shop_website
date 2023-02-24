using System;

namespace OnlineShop.Helper
{
    public class ExceptionHandler: Exception
    {
        public ExceptionHandler(string message, string technicalMessage = "", int? errorCode = null)
     : base(message)
        {
            this.ErrorCode = errorCode;
            this.TechnicalMessage = technicalMessage;
            this.Severity = LogSeverity.Error;
        }

        public ExceptionHandler(
          string message,
          string technicalMessage,
          Exception innerException,
          int? errorCode = null)
          : base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.TechnicalMessage = technicalMessage;
            this.Severity = LogSeverity.Error;
        }

        public int? ErrorCode { get; protected set; }
        public string TechnicalMessage { get; protected set; }
        public LogSeverity Severity { get; protected set; }

        public override string ToString()
        {
            string str = base.ToString();
            if (!string.IsNullOrEmpty(this.Message))
                str = str.Replace(this.Message, this.Message + ", TechnicalMessage: " + this.TechnicalMessage);
            else if (this.InnerException != null)
            {
                int startIndex = str.IndexOf("--->");
                if (startIndex >= 0)
                    str = str.Insert(startIndex, "TechnicalMessage: " + this.TechnicalMessage);
            }
            else
                str = str + " TechnicalMessage: " + this.TechnicalMessage;
            return str;
        }
    }
    public enum LogSeverity
    {
        Debug,
        Info,
        Warn,
        Error,
        Critical,
    }

}
