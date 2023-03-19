namespace OnlineShop.ViewModel;

public class OrderListModel
{
    public long Id { get; set; }
    public bool IsFinaly { get; set; }
    public string TotalPrice { get; set; }
    public int ProductCount { get; set; }
    

    public List<OrderDetailModel> OrderDetail { get; set; }
}

public class OrderDetailModel
{
    public long Id { get; set; }
    public string Price { get; set; }
    public string Count { get; set; }
    public ProductCartViewModel ProductDetail { get; set; }
}