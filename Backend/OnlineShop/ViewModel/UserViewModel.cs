using OnlineShop.Data.Models;

namespace OnlineShop.ViewModel;

public class UserViewModel
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalId { get; set; }
    public string? BirthDate { get; set; }
    public string? Address { get; set; }
    public string Gender { get; set; }
    public string? ZipCode { get; set; }
    public string? MobileNumber { get; set; }
    public string Wallet { get; set; }
    public bool IsAdmin { get; set; }
    public string? RegisterDate { get; set; }
}