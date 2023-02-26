using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Services;

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
    public async Task<List<Product>> GetProductsList()
    {
        return await Task.Run(() => MainServices.GetProductsList());
    }

    [HttpGet]
    [Route("/Products/{categoryName}")]
    public async Task<List<Product>> GetProductsList([FromRoute]string categoryName)
    {
        return await Task.Run(() => MainServices.GetProductsList(categoryName));
    }
}