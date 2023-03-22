using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

public class MainController : Controller
{
    public MainController(MainServices mainServices)
    {
        MainServices = mainServices;
    }

    private MainServices MainServices { get; }

    [HttpGet]
    [Route("/Products")]
    public async Task<List<ProductCartViewModel>> GetProductsList()
    {
        return await MainServices.GetProductsList();
    }

    [HttpGet]
    [Route("/Products/Category/{categoryName}")]
    public async Task<List<ProductCartViewModel>> GetProductsList([FromRoute] string categoryName)
    {
        return await MainServices.GetProductsList(categoryName);
    }

    [HttpGet]
    [Route("/Products/Id/{productId:long}")]
    public async Task<ProductDetailModel> GetProductsDetail([FromRoute] long productId)
    {
        return await MainServices.GetProductsDetail(productId);
    }

    [HttpGet]
    [Route("/CurrencyInquiry")]
    public async Task<CurrencyInquieyViewModel[]> CurrencyInquiry()
    {
        return await MainServices.CurrencyInquiry();
    }

    [HttpGet]
    [Route("/CryptoCurrencyInquiry")]
    public async Task<CryptoCurrencyViewModel[]> CryptoCurrencyInquiey()
    {
        return await MainServices.CryptoCurrencyInquiey();
    }
}