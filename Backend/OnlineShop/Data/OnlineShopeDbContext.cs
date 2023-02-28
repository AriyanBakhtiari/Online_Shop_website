using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data;

public class OnlineShopeDbContext : DbContext
{
    public OnlineShopeDbContext(DbContextOptions<OnlineShopeDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(b =>
        {
            b.ToTable("Users");
            b.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1000, 1);
        });

        modelBuilder.ApplyConfiguration(new UserSeedData());
        modelBuilder.ApplyConfiguration(new ProductSeedData());
        modelBuilder.ApplyConfiguration(new CategorySeedData());
    }
}