namespace OnlineShop.ViewModel;

public class ProductDetailModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuantityInStock { get; set; }
    public string ImagePath { get; set; }
    public string Price { get; set; }
    public string CategoryName { get; set; }
}