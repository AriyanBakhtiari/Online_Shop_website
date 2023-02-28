namespace OnlineShop;

public class ExceptionHandler : Exception
{
    public ExceptionHandler(string message, string technicalMessage = "", int? errorCode = null)
        : base(message)
    {
        ErrorCode = errorCode;
        TechnicalMessage = technicalMessage;
        Severity = LogSeverity.Error;
    }

    public ExceptionHandler(
        string message,
        string technicalMessage,
        Exception innerException,
        int? errorCode = null)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
        TechnicalMessage = technicalMessage;
        Severity = LogSeverity.Error;
    }

    public int? ErrorCode { get; protected set; }
    public string TechnicalMessage { get; protected set; }
    public LogSeverity Severity { get; protected set; }

    public override string ToString()
    {
        var str = base.ToString();
        if (!string.IsNullOrEmpty(Message))
        {
            str = str.Replace(Message, Message + ", TechnicalMessage: " + TechnicalMessage);
        }
        else if (InnerException != null)
        {
            var startIndex = str.IndexOf("--->");
            if (startIndex >= 0)
                str = str.Insert(startIndex, "TechnicalMessage: " + TechnicalMessage);
        }
        else
        {
            str = str + " TechnicalMessage: " + TechnicalMessage;
        }

        return str;
    }
}

public enum LogSeverity
{
    Debug,
    Info,
    Warn,
    Error,
    Critical
}