namespace OnlineShop.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetProductsList();
}
public class ProductRepository : IProductRepository
{
    private OnlineShopeDbContext _context;
    public ProductRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Product> GetProductsList()
    {
        return _context.Products.Select(x => x);
    }
}
