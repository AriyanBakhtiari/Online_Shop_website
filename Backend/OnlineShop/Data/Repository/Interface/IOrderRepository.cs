using OnlineShop.Data.Models;

namespace OnlineShop.Data.Repository.Interface;

public interface IOrderRepository
{
    Task<Order> GetOrderList(string email);
    Task<IResult> AddProductToOrderList(string email, long productId, int quantity);
    Task<IResult> RemoveProductFromOrderList(string email, long orderDetailId);
    Task<IResult> FinalizePurches(string email, long orderId);
}