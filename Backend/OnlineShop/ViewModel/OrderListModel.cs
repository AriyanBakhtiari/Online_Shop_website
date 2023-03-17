namespace OnlineShop.ViewModel;

public class OrderListModel
{
    public long Id { get; set; }
    public bool IsFinaly { get; set; }
    public DateTime CreateDate { get; set; }

    public List<OrderDetailModel> OrderDatail { get; set; }
}

public class OrderDetailModel
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public ProductCartViewModel ProductDetail { get; set; }
}