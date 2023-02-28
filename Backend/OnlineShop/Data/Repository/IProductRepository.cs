using Microsoft.EntityFrameworkCore;
using OnlineShop.ViewModel;

namespace OnlineShop.Data;

public interface IProductRepository
{
    IEnumerable<ProductCartViewModel> GetProductsList();
    IEnumerable<ProductCartViewModel> GetProductsList(string category);
    Product? GetProductDetail(long productId);
}
public class ProductRepository : IProductRepository
{
    private OnlineShopeDbContext _context;
    public ProductRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductCartViewModel> GetProductsList()
    {
        return _context.Products.Select(x => new ProductCartViewModel { Name = x.Name , Id = x.Id , ImagePath = x.ImagePath , Price = x.Price});
    }
    public IEnumerable<ProductCartViewModel> GetProductsList(string category)
    {
        return _context.Products.Include(x => x.Category).Where(x => x.Category.Name == category).Select(x => new ProductCartViewModel { Name = x.Name, Id = x.Id, ImagePath = x.ImagePath, Price = x.Price });
    }
    public Product? GetProductDetail(long productId)
    {
        return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == productId);
    }
}
