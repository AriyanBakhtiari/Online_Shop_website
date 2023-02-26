using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Data;

public interface IProductRepository
{
    IEnumerable<Product> GetProductsList();
    IEnumerable<Product> GetProductsList(string category);
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
        return _context.Products;
    }
    public IEnumerable<Product> GetProductsList(string category)
    {
        return _context.Products.Include(x => x.Category).Where(x => x.Category.Name == category);
    }
}
