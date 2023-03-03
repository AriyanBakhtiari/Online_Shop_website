namespace OnlineShop.Middleware.Models;

public class ApiResponse<T>
{
    public string? errorMessage { get; set; } = null!;
    public int? errorCode { get; set; }
}