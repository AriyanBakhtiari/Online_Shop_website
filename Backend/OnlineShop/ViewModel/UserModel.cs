using OnlineShop.Data;

namespace OnlineShop.ViewModel;

public class UserModel
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalId { get; set; }
    public string? BirthDate { get; set; }
    public string? Address { get; set; }
    public GenderEnum Gender { get; set; }
    public string? ZapCode { get; set; }
    public string? MobileNumber { get; set; }
    public double Wallet { get; set; }
    public bool IsAdmin { get; set; }
    public string? RegisterDate { get; set; }
}
