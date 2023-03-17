﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository.Interface;

namespace OnlineShop.Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineShopeDbContext _context;

    public OrderRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetOrderList(string email)
    {
        return await _context.Orders
            .Where(x => !x.IsFinaly && x.User.Email == email)
            .Include(x => x.OrderDatail)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync();
    }

    public async Task<IResult> AddProductToOrderList(string email, long productId, int quantity)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        if (product == null)
            throw new ExceptionHandler("اصلاعات وارد شده صحیح نمیباشد");
        if (product.QuantityInStock == 0)
            throw new ExceptionHandler("محصول موجود نمیباشد");
        if (product.QuantityInStock < quantity)
            throw new ExceptionHandler("محصول به تعداد وارد شده موجود نمیباشد");

        var order = await _context.Orders.FirstOrDefaultAsync(x => !x.IsFinaly && x.User.Email == email);
        if (order != null)
        {
            var orderDetail =
                await _context.OrderDetails.FirstOrDefaultAsync(x =>
                    x.OrderId == order.Id && x.ProductId == product.Id);
            if (orderDetail != null)
                orderDetail.Count += quantity;
            else
                await _context.OrderDetails.AddAsync(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Price = product.Price,
                    Count = quantity
                });
        }
        else
        {
            order = new Order
            {
                CreateDate = DateTime.Now,
                IsFinaly = false,
                UserId = user.Id
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            await _context.OrderDetails.AddAsync(new OrderDetail
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Price = product.Price,
                Count = quantity
            });
        }

        await _context.SaveChangesAsync();

        return Results.Ok();
    }

    public async Task<IResult> RemoveProductFromOrderList(string email, long orderDetailId)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        var order = await _context.Orders.Include(x => x.OrderDatail)
            .SingleOrDefaultAsync(x => !x.IsFinaly && x.UserId == user.Id);

        var orderDetail = order.OrderDatail.SingleOrDefault(x => x.Id == orderDetailId);

        if (orderDetail == null)
            throw new ExceptionHandler("این محصول در سبد خرید شما وجود ندارد");

        if (orderDetail.Count == 1)
            _context.OrderDetails.Remove(orderDetail);
        else
            orderDetail.Count -= 1;

        await _context.SaveChangesAsync();

        return Results.Ok();
    }
}