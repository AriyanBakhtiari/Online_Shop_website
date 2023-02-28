using OnlineShop.Data;

namespace OnlineShop.ViewModel;

public class UserModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? NationalId { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Address { get; set; }
    public GenderEnum? Gender { get; set; }
    public string? ZapCode { get; set; }
    public string? MobileNumber { get; set; }
    public string? Email { get; set; }
    public double? Wallet { get; set; }
    public bool? IsAdmin { get; set; }
    public DateTime? RegisterDate { get; set; }
}
