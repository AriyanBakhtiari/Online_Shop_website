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


        var orderListModel = new OrderListModel
        {
            Id = orderList.Id,
            CreateDate = orderList.CreateDate,
            IsFinaly = orderList.IsFinaly,
            OrderDatail = new List<OrderDetailModel>()
        };

        foreach (var item in orderList.OrderDatail)
        {
            orderListModel.OrderDatail.Add(new OrderDetailModel
            {
                Id = item.Id,
                Count = item.Count,
                Price = item.Price,
                ProductDetail = new ProductCartViewModel
                {
                    Name = item.Product.Name,
                    Price = item.Product.Price.ToString().ToThousandSepratedPersianNumber(),
                    Id = item.Product.Id,
                    ImagePath = item.Product.ImagePath
                }
            });
            ;
        }


        return orderListModel;
    }

    public async Task<IResult> AddProductToOrderList(string token, long productId, int quantity)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        return await _orderRepository.AddProductToOrderList(userEmail, productId, quantity);
    }

    public async Task<IResult> RemoveProductFromOrderList(string token, long orderDeailId)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        return await _orderRepository.RemoveProductFromOrderList(userEmail, orderDeailId);
    }

    public async Task<IResult> FinalizePurches(string token, long orderId)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        return await _orderRepository.FinalizePurches(userEmail, orderId);
    }
}