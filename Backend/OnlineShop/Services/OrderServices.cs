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
        var sortedOrderList = orderList.OrderByDescending(x => x.Id).ToList();
        var orderHistory = new OrderHistoryViewModel
        {
            TotalOrderCount = sortedOrderList.Count,
            TotalPayment = sortedOrderList.Sum(x => x.TotalPrice).ToString().ToThousandSepratedPersianNumber(),
            OrderList = new OrderViewModel[sortedOrderList.Count]
        };

        for (var i = 0; i < sortedOrderList.Count; i++)
        {
            orderHistory.OrderList[i] = new OrderViewModel
            {
                Id = sortedOrderList[i].Id,
                FinalizeDate = Helper.ToPersianDateTime(sortedOrderList[i].FinalizeDate),
                TotalPrice = sortedOrderList[i].TotalPrice.ToString().ToThousandSepratedPersianNumber(),
                OrderDetailList = new OrderDetailViewModel[sortedOrderList[i].OrderDatail.Count]
            };

            for (var j = 0; j < sortedOrderList[i].OrderDatail.Count; j++)
            {
                var orderdetail = sortedOrderList[i].OrderDatail[j];
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