using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;


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
        #region Category Data
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            Name = "Mens_Clothes",
            ShowName = "لباس مردانه"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            Name = "Womens_Clothes",
            ShowName = "لباس زتانه"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 3,
            Name = "Mens_shoes",
            ShowName = "کفش مردانه"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 4,
            Name = "Wemens_Shoes",
            ShowName = "کفش زنانه"
        });
        
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 6,
            Name = "Digital_Prodct",
            ShowName = "محصولات دیجیتالی"
        });
        
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 7,
            Name = "Accesory",
            ShowName = "لوازم جانبی"
        });
        
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 8,
            Name = "کتاب",
            ShowName = "لوازم خودرو"
        });
        #endregion

        #region User Data
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Email = "admin@admin.com",
            IsAdmin = true,
            Password = "admin",
            RegisterDate = DateTime.MinValue,
            Wallet = 10000000 , 
        }) ;
        #endregion
        
        #region Product Data
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "تیشرت ورزشی مردانه ",
            CategoryId = 1,
            Description = "تیشرت ورزشی مردانه شرکت متفرقه",
        });
        #endregion
    }
}