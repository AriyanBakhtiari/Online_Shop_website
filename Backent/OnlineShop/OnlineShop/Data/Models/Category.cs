using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data;

[Table("Categories")]
public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ShowName { get; set; }
}