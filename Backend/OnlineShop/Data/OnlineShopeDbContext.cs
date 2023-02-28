using Microsoft.EntityFrameworkCore;


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
        modelBuilder.ApplyConfiguration(new UserSeedData());
        modelBuilder.ApplyConfiguration(new ProductSeedData());
        modelBuilder.ApplyConfiguration(new CategorySeedData());
    }
}