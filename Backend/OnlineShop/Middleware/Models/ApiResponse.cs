namespace OnlineShop.Middleware;

public class ApiResponse<T>
{
    public T data { get; set; } = default!;
    public string? errorMessage { get; set; } = null!;
    public int? errorCode { get; set; }
    public string path { get; set; } = null!;
    public DateTime dateNow { get; set; }
}