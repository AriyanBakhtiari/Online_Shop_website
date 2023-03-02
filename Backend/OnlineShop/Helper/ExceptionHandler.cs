namespace OnlineShop;

public class ExceptionHandler : Exception
{
    public ExceptionHandler(string message, string technicalMessage = "", int? errorCode = null)
        : base(message)
    {
        ErrorCode = errorCode;
        TechnicalMessage = technicalMessage;
    }

    public int? ErrorCode { get; protected set; }
    public string TechnicalMessage { get; protected set; }
}
