using OnlineShop.Data.Repository.Interface;

namespace OnlineShop.Data.Repository;

public class OrderRepository : IOrderRepository
{
    private OnlineShopeDbContext _context;

    public OrderRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }
}