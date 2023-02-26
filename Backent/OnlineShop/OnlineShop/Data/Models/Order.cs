using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data;

[Table("Orders")]
public class Order
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public bool IsFinaly { get; set; }
    public DateTime CreateDate { get; set; }

    public User User { get; set; }
    public List<OrderDetail> OrderDatail { get; set; }
}