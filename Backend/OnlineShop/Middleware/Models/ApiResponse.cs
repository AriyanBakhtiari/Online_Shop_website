namespace OnlineShop.Middleware.Models;

public class ApiResponse<T>
{
    public T data { get; set; } = default!;
    public string? errorMessage { get; set; } = null!;
    public int? errorCode { get; set; }
}