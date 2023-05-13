using System.Text;
using AutoMapper;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.ViewModel;

namespace OnlineShop.Services;

public class MainServices
{
    private readonly IProductRepository _productRepository;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClient;
    private readonly IMapper _mapper;
    private readonly ILogger<MainServices> _logger;

    public MainServices(IProductRepository productRepository, IHttpClientFactory httpClient,IMapper mapper,IConfiguration configuration, ILogger<MainServices> logger)
    {
        _productRepository = productRepository;
        _configuration = configuration;
        _httpClient = httpClient;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ProductCartViewModel>> GetProductsList()
    {
        _logger.LogCritical("this is the test");
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

        var productDetail = new ProductDetailModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryName = product.Category.ShowName,
            Price = product.Price.ToString().ToThousandSepratedInt(),
            ImagePath = product.ImagePath,
            QuantityInStock = product.QuantityInStock
        };
        return productDetail;
    }

    public async Task<CurrencyInquieyViewModel[]> CurrencyInquiry()
    {
        var body = new
        {
            Identity = new
            {
                Token = _configuration["CoreToken"]
            },
            Parameters = new
            {
            }
        };
        var content = new StringContent(Helper.JsonSerializer(body), Encoding.UTF8, "application/json");
        var client = _httpClient.CreateClient("CoreClient");
        var response = await client.PostAsync("CurrencyInquiry",content);
        var responseString = await response.Content.ReadAsStringAsync();

        var jsonObject = Helper.JsonDeserializer<CurrencyInquiryJsonModel>(responseString);

        var currencyInquiry = new CurrencyInquieyViewModel[jsonObject.Parameters.CurrencyInquiryDataList.Length];
        for (var i = 0; i < jsonObject.Parameters.CurrencyInquiryDataList.Length; i++)
        {
            currencyInquiry[i] = _mapper.Map<CurrencyInquieyViewModel>(jsonObject.Parameters.CurrencyInquiryDataList[i]);
            currencyInquiry[i].Price = currencyInquiry[i].Price.ToPersianNumber();
        }

        return currencyInquiry;
    }

    public async Task<CryptoCurrencyViewModel[]> CryptoCurrencyInquiey()
    {
        var body = new
        {
            Identity = new
            {
                Token = _configuration["CoreToken"]
            },
            Parameters = new
            {
            }
        };
        var content = new StringContent(Helper.JsonSerializer(body), Encoding.UTF8, "application/json");
        var client = _httpClient.CreateClient("CoreClient");
        var response = await client.PostAsync("CryptoCurrencyInquiry",content);
        var responseString = await response.Content.ReadAsStringAsync();

        var jsonObject = Helper.JsonDeserializer<CryptoCurrencyInquiryJsonModel>(responseString);

        var currencyInquiry = new CryptoCurrencyViewModel[jsonObject.Parameters.CryptoCurrencyInquiryDataList.Length];
        for (var i = 0; i < jsonObject.Parameters.CryptoCurrencyInquiryDataList.Length; i++)
        {
            currencyInquiry[i] = _mapper.Map<CryptoCurrencyViewModel>(jsonObject.Parameters.CryptoCurrencyInquiryDataList[i]);
            currencyInquiry[i].Price = currencyInquiry[i].Price.ToPersianNumber();
        }

        return currencyInquiry;
    }
}