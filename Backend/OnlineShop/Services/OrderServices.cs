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
            TotalPrice = orderList.TotalPrice.ToString().ToThousandSepratedPersianNumber(),
            ProductCount = orderList.OrderDatail.Count,
            OrderDetail = new List<OrderDetailModel>()
        };

        foreach (var item in orderList.OrderDatail)
            orderListModel.OrderDetail.Add(new OrderDetailModel
            {
                Id = item.Id,
                Count = item.Count.ToString().ToPersianNumber(),
                Price = item.Price.ToString().ToThousandSepratedPersianNumber(),
                ProductDetail = new ProductCartViewModel
                {
                    Name = item.Product.Name,
                    Price = item.Product.Price.ToString().ToThousandSepratedPersianNumber(),
                    Id = item.Product.Id,
                    ImagePath = item.Product.ImagePath
                }
            });

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

    public async Task<IResult> FinalizePurchase(string token, long orderId)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        return await _orderRepository.FinalizePurchase(userEmail, orderId);
    }

    public async Task<OrderHistoryViewModel> GetOrderHistory(string token)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);
        var orderList = await _orderRepository.GetOrderHistory(userEmail);

        var orderHistory = new OrderHistoryViewModel
        {
            TotalOrderCount = orderList.Count,
            TotalPayment = orderList.Sum(x => x.TotalPrice).ToString().ToThousandSepratedPersianNumber(),
            OrderList = new OrderViewModel[orderList.Count]
        };

        for (var i = 0; i < orderList.Count; i++)
        {
            orderHistory.OrderList[i] = new OrderViewModel
            {
                Id = orderList[i].Id,
                FinalizeDate = Helper.ToPersianDateTime(orderList[i].FinalizeDate),
                TotalPrice = orderList[i].TotalPrice.ToString().ToThousandSepratedPersianNumber(),
                OrderDetailList = new OrderDetailViewModel[orderList[i].OrderDatail.Count]
            };

            for (var j = 0; j < orderList[i].OrderDatail.Count; j++)
            {
                var orderdetail = orderList[i].OrderDatail[j];
                orderHistory.OrderList[i].OrderDetailList[j] = new OrderDetailViewModel
                {
                    Price = orderdetail.Price.ToString().ToThousandSepratedPersianNumber(),
                    Count = orderdetail.Count,
                    ProductName = orderdetail.Product.Name,
                    ProductPrice = orderdetail.Product.Price.ToString().ToThousandSepratedPersianNumber(),
                    ProductImage = orderdetail.Product.ImagePath
                };
            }
        }

        return orderHistory;
    }
}