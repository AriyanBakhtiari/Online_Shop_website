using Microsoft.Extensions.Primitives;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.ViewModel;

namespace OnlineShop.Services;

public class OrderServices
{
    private readonly IOrderRepository _orderRepository;

    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderListModel> GetOrderList(string token)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);

        var orderList = await _orderRepository.GetOrderList(userEmail);
        if (orderList == null)
            throw new ExceptionHandler("سبد خرید شما خالی است");


        var orderListModel = new OrderListModel()
        {
            Id = orderList.Id,
            CreateDate = orderList.CreateDate,
            IsFinaly = orderList.IsFinaly,
            OrderDatail = new List<OrderDetailModel>(),
        };

        foreach(var item in orderList.OrderDatail)
        {
            orderListModel.OrderDatail.Add(new OrderDetailModel()
            {
                Count = item.Count,
                Price = item.Price,
                ProductDetail = new ProductCartViewModel()
                {
                    Name = item.Product.Name,
                    Price = item.Product.Price.ToString().ToThousandSepratedPersianNumber(),
                    Id = item.Product.Id,
                    ImagePath = item.Product.ImagePath,
                }
            }); ;
        }
        

        return orderListModel;
    }

    public async Task<IResult> AddProductToOrderList(string token, long productId, int quantity)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        return await _orderRepository.AddProductToOrderList(userEmail, productId, quantity);
    }
}