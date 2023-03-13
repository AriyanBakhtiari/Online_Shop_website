
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Models;
using OnlineShop.Services;
using OnlineShop.ViewModel;
using System.Diagnostics.Eventing.Reader;

namespace OnlineShop.Controllers;

[ApiController]
[Authorize]
[Route("/[controller]")]
public class OrderController : Controller
{
    private OrderServices _orderServices { get; }

    public OrderController(OrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet]
    public async Task<OrderListModel> GetOrderList()
    {
        var token = Request.Headers.Authorization;
        return await _orderServices.GetOrderList(token);
    }

    [HttpPost]
    [Route("AddProduct")]
    public async Task<IResult> AddProductToOrderList([FromBody] AddProductToOrderListModel addProductToOrderListModel)
    {
        var token = Request.Headers.Authorization;
        return await _orderServices.AddProductToOrderList(token, addProductToOrderListModel.ProductId, addProductToOrderListModel.Quantity);
    }
}