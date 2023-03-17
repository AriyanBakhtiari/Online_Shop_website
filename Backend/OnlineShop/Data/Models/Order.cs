using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models;

[Table("Orders")]
public class Order
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public bool IsFinaly { get; set; }
    public int TotalPrice { get; set; }
    public DateTime? FinalizeDate { get; set; }

    public User User { get; set; }
    public List<OrderDetail> OrderDatail { get; set; }
}