﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Models;

[Table("OrderDetails")]
public class OrderDetail
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}