using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

[ApiController]
[Authorize]
[Route("/[controller]")]
public class OrderController : Controller
{
    public OrderController(OrderServices orderServices)
    {
        OrderServices = orderServices;
    }

    private OrderServices OrderServices { get; }

    [HttpGet]
    public async Task<OrderListModel> GetOrderList()
    {
        var token = Request.Headers.Authorization;
        return await OrderServices.GetOrderList(token);
    }

    [HttpPost]
    [Route("AddProduct")]
    public async Task<IResult> AddProductToOrderList([FromBody] AddProductToOrderListModel addProductToOrderListModel)
    {
        var token = Request.Headers.Authorization;
        return await OrderServices.AddProductToOrderList(token, addProductToOrderListModel.ProductId,
            addProductToOrderListModel.Quantity);
    }

    [HttpPost]
    [Route("RemoveProduct")]
    public async Task<IResult> RemoveProductFromOrderList(
        [FromBody] RemoveProductFromOrderListModel removeProductFromOrderListModel)
    {
        var token = Request.Headers.Authorization;
        return await OrderServices.RemoveProductFromOrderList(token, removeProductFromOrderListModel.OrderDetailId);
    }
}