using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.ViewModel;

namespace OnlineShop.Data.Repository;

public class ProductRepository : IProductRepository
{
    private readonly OnlineShopeDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(OnlineShopeDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<List<ProductCartViewModel>> GetProductsList()
    {
        _logger.LogInformation("#######################################################");
        return _context.Products.Select(x => new ProductCartViewModel
                {Name = x.Name, Id = x.Id, ImagePath = x.ImagePath, Price = x.Price.ToString().ToThousandSepratedInt()})
            .ToListAsync();
    }

    public Task<List<ProductCartViewModel>> GetProductsList(string category)
    {
        return _context.Products.Include(x => x.Category).Where(x => x.Category.Name == category).Select(x =>
                new ProductCartViewModel
                {
                    Name = x.Name, Id = x.Id, ImagePath = x.ImagePath,
                    Price = x.Price.ToString().ToThousandSepratedInt()
                })
            .ToListAsync();
    }

    public Task<Product> GetProductDetail(long productId)
    {
        return _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == productId);
    }
}