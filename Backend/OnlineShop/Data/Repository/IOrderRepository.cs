namespace OnlineShop.Data;

public interface IOrderRepository
{

}
public class OrderRepository : IOrderRepository
{
    private OnlineShopeDbContext _context;
    public OrderRepository(OnlineShopeDbContext context)
    {
        _context = context;

    }


}
