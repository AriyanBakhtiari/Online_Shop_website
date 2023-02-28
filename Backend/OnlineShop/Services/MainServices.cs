using OnlineShop.Data;
using OnlineShop.Helper;
using OnlineShop.ViewModel;

namespace OnlineShop.Services
{
    public class MainServices
    {
        private IProductRepository _productRepository;
        public MainServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductCartViewModel> GetProductsList()
        {
            try
            {
                var product = _productRepository.GetProductsList().ToList();
                return product;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductCartViewModel> GetProductsList(string category)
        {
            try
            {
                var product = _productRepository.GetProductsList(category).ToList();
                if (product.Count == 0 || product == null)
                {
                    throw new ExceptionHandler("برای دسته بندی وارد شده محصولی یافت نشد");
                }
                return product;
            }
            catch(ExceptionHandler ex)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Product GetProductsDetail(long productId)
        {
            try
            {
                var product = _productRepository.GetProductDetail(productId);
                if (product == null)
                {
                    throw new ExceptionHandler("برای دسته بندی وارد شده محصولی یافت نشد");
                }
                return product;
            }
            catch (ExceptionHandler ex)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
