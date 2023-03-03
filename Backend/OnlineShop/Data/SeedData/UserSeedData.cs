using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Data.Models;

namespace OnlineShop.Data.SeedData;

public class UserSeedData : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
        {
            Id = 1,
            Email = "admin@admin.com",
            IsAdmin = true,
            Password = "admin",
            RegisterDate = DateTime.MinValue,
            Wallet = 10000000,
            Address = "تهران",
            BirthDate = new DateTime(2001, 1, 1),
            FirstName = "ارین",
            LastName = "بختیاری",
            Gender = GenderEnum.Male,
            MobileNumber = "+989194888834",
            NationalId = "0025566456",
            ZapCode = "135649"
        });
    }
}