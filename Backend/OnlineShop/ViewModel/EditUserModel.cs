#nullable enable
using OnlineShop.Data.Models;

namespace OnlineShop.ViewModel;

public class EditUserModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalId { get; set; }
    public string? BirthDate { get; set; }
    public string? Address { get; set; }
    public GenderEnum Gender { get; set; }
    public string? ZapCode { get; set; }
    public string? MobileNumber { get; set; }
}