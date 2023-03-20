using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.ViewModel;

namespace OnlineShop.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly OnlineShopeDbContext _context;

    public UserRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UsernamePasswordIsCorrect(LoginModel user)
    {
        var userAccount = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
        return userAccount != null && PasswordHashManager.VerifyHash(user.Password, "SHA512", userAccount?.Password);
    }

    public Task<bool> UserIsExist(string userEmail)
    {
        return _context.Users.AnyAsync(x => x.Email == userEmail);
    }

    public async Task<bool> RegisterUser(SignUpViewModel user)
    {
        var userModel = new User
        {
            Email = user.Email,
            Password = PasswordHashManager.ComputeHash(user.Password, "SHA512"),
            FirstName = user.FirstName.ToSafePersianString(),
            LastName = user.LastName.ToSafePersianString(),
            RegisterDate = DateTime.Now
        };
        await _context.Users.AddAsync(userModel);
        await _context.SaveChangesAsync();

        return true;
    }

    public Task<User> GetUserInfo(string userEmail)
    {
        return _context.Users.FirstOrDefaultAsync(x => x.Email == userEmail);
    }

    public async Task<User> EditUserInfo(string userEmail, EditUserModel userModel)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userEmail);

        user.FirstName = string.IsNullOrEmpty(userModel.FirstName)
            ? user.FirstName
            : userModel.FirstName.ToSafePersianString();
        user.Address = string.IsNullOrEmpty(userModel.Address) ? user.Address : userModel.Address.ToSafePersianString();
        user.BirthDate = string.IsNullOrEmpty(userModel.BirthDate) ?  user.BirthDate : Helper.ShamsiYYYYMMDDDateTimeToGregorianDateTime(userModel.BirthDate); 
        user.MobileNumber = string.IsNullOrEmpty(userModel.MobileNumber) ? user.MobileNumber : userModel.MobileNumber;
        user.Gender = userModel.Gender == GenderEnum.Unkhown ? user.Gender : userModel.Gender;
        user.LastName = string.IsNullOrEmpty(userModel.LastName)
            ? user.LastName
            : userModel.LastName.ToSafePersianString();
        user.ZapCode = string.IsNullOrEmpty(userModel.ZapCode) ? user.ZapCode : userModel.ZapCode.ToEnglishNumber();
        user.NationalId = string.IsNullOrEmpty(userModel.NationalId) ? user.NationalId : userModel.NationalId;

        await _context.SaveChangesAsync();

        return user;
    }
}