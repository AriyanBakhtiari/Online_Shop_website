using OnlineShop.Data.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.Data.Repository.Interface;

public interface IProductRepository
{
    Task<List<ProductCartViewModel>> GetProductsList();
    Task<List<ProductCartViewModel>> GetProductsList(string category);
    Task<Product?> GetProductDetail(long productId);
}