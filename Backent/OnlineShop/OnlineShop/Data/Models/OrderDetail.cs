using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data;
[Table("OrderDetails")]
public class OrderDetail
{
    public long Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}