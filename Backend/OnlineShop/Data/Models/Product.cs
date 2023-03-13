using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models;

[Table("Products")]
public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuantityInStock { get; set; }
    public string ImagePath { get; set; }
    public int Price { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }
}