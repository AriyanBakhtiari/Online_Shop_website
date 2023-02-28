using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

public class MainController : Controller
{
    public MainServices MainServices { get; set; }

    public MainController(MainServices mainServices)
    {
        MainServices = mainServices;
    }

    [HttpGet]
    [Route("/Products")]
    public async Task<List<ProductCartViewModel>> GetProductsList()
    {
        return await Task.Run(MainServices.GetProductsList);
    }

    [HttpGet]
    [Route("/Products/Category/{categoryName}")]
    public async Task<List<ProductCartViewModel>> GetProductsList([FromRoute]string categoryName)
    {
        return await Task.Run(() => MainServices.GetProductsList(categoryName));
    }

    [HttpGet]
    [Route("/Products/Id/{productId}")]
    public async Task<Product> GetProductsDetail([FromRoute] long productId)
    {
        return await Task.Run(() => MainServices.GetProductsDetail(productId));
    }
}