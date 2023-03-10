using OnlineShop.Data.Models;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.ViewModel;

namespace OnlineShop.Services;

public class MainServices
{
    private readonly IProductRepository _productRepository;

    public MainServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductCartViewModel>> GetProductsList()
    {
        // throw new ExceptionHandler("محصولی یافت نشد");
        var product = await _productRepository.GetProductsList();
        if (product == null || product.Count == 0) throw new ExceptionHandler("محصولی یافت نشد");
        return product;
    }

    public async Task<List<ProductCartViewModel>> GetProductsList(string category)
    {
        var product = await _productRepository.GetProductsList(category);
        if (product.Count == 0 || product == null)
            throw new ExceptionHandler("برای دسته بندی وارد شده محصولی یافت نشد");
        return product;
    }

    public async Task<ProductDetailModel> GetProductsDetail(long productId)
    {
        var product = await _productRepository.GetProductDetail(productId);
        if (product == null) throw new ExceptionHandler(" محصولی یافت نشد");

        var productDetail = new ProductDetailModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryName = product.Category.ShowName,
            Price = product.Price.ToString().ToThousandSepratedInt(),
            ImagePath = product.ImagePath,
            QuantityInStock = product.QuantityInStock,
        };
        return productDetail;
    }
}