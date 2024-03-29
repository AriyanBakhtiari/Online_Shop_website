﻿using OnlineShop.Data.Models;

namespace OnlineShop.Data.Repository.Interface;

public interface IOrderRepository
{
    Task<Order> GetOrderList(string email);
    Task<IResult> AddProductToOrderList(string email, long productId, int quantity);
    Task<IResult> RemoveProductFromOrderList(string email, long orderDetailId);
    Task<IResult> FinalizePurchase(string email, long orderId);
    Task<List<Order>> GetOrderHistory(string email);
}