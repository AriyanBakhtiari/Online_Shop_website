using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data;

[Table("Users")]
public class User
{
    public long Id { get; set; }
    [DataType("Nvarchar(20)")]
    public string FirstName { get; set; }
    [DataType("Nvarchar(20)")]
    public string LastName { get; set; }
    [DataType("Nvarchar(100)")]
    public string? Address { get; set; }
    public GenderEnum Gender { get; set; }
    [DataType("Varchar(20)")]
    public string? ZapCode { get; set; }
    [DataType("Varchar(13)")]
    public string? MobileNumber { get; set; }
    [DataType("Varchar(50)")]
    public string Email { get; set; }
    [DataType("Varchar(50)")]
    public string Password { get; set; }
    public double Wallet { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime RegisterDate { get; set; }
    public string? NationalId { get; set; }
    public DateTime? BirthDate { get; set; }

    public List<Order> Orders { get; set; }
}

