namespace OnlineShop.ViewModel;

public class OrderHistoryViewModel
{
    public string TotalPayment { get; set; }
    public int TotalOrderCount { get; set; }
    public OrderViewModel[] OrderList { get; set; }
}

public class OrderViewModel
{
    public long Id { get; set; }
    public string FinalizeDate { get; set; }
    public string TotalPrice { get; set; }
    public OrderDetailViewModel[] OrderDetailList { get; set; }
}

public class OrderDetailViewModel
{
    public string Price { get; set; }
    public int Count { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public string ProductPrice { get; set; }
}