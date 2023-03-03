using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Models;

namespace OnlineShop.Data.SeedData;

public class CategorySeedData : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category
            {
                Id = 1,
                Name = "Mens_Clothes",
                ShowName = "لباس مردانه"
            },
            new Category
            {
                Id = 2,
                Name = "Womens_Clothes",
                ShowName = "لباس زتانه"
            },
            new Category
            {
                Id = 3,
                Name = "Mens_shoes",
                ShowName = "کفش مردانه"
            },
            new Category
            {
                Id = 4,
                Name = "Wemens_Shoes",
                ShowName = "کفش زنانه"
            },
            new Category
            {
                Id = 5,
                Name = "Digital_Prodct",
                ShowName = "محصولات دیجیتالی"
            },
            new Category
            {
                Id = 6,
                Name = "Accesory",
                ShowName = "لوازم جانبی"
            });
    }
}