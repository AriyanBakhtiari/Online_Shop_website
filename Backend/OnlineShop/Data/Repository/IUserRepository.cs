using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OnlineShop.ViewModel;

namespace OnlineShop.Data;
public interface IUserRepository
{
    bool UsernamePasswordIsCorrect(LoginModel user);
    bool UserIsExist(string userEmail);
    bool RegisterUser(RegisterModel user);
    User GetUserInfo(string userEmail);
    User EditUserInfo(string userEmail, EditUserModel user);
}
public class UserRepository : IUserRepository
{
    private OnlineShopeDbContext _context;
    public UserRepository(OnlineShopeDbContext context)
    {
        _context = context;
    }


    public bool UsernamePasswordIsCorrect(LoginModel user)
    {
        if (!_context.Users.Any(x => x.Email == user.Email))
            return false;

        var userAccount = _context.Users.FirstOrDefault(x => x.Email == user.Email);

        if (userAccount.Password != user.Password)
            return false;

        return true;
    }

    public bool UserIsExist(string userEmail)
    {
        return _context.Users.Any(x => x.Email == userEmail);
    }
    public bool RegisterUser(RegisterModel user)
    {
        var userModel = new User
        {
            Email = user.Email,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.FirstName,
            RegisterDate= DateTime.Now,
        };
        var test = _context.Users.Add(userModel);
        _context.SaveChanges();
        return true;
    }
    public User GetUserInfo(string userEmail)
    {
        var user = _context.Users.FirstOrDefault(x=> x.Email == userEmail);
       

        return user;
    }
    public User EditUserInfo(string userEmail , EditUserModel userModel)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
        
        user.FirstName = userModel.FirstName ?? user.FirstName;
        user.Address = userModel.Address ?? user.Address;
        user.BirthDate = userModel.BirthDate ?? user.BirthDate;
        user.MobileNumber = userModel.MobileNumber ?? user.MobileNumber;
        user.Gender = userModel.Gender == GenderEnum.Unkhown ? user.Gender : userModel.Gender;
        user.LastName = userModel.LastName ?? user.LastName;
        user.ZapCode = userModel.ZapCode ?? user.ZapCode;
        user.NationalId = userModel.NationalId ?? user.NationalId;

        _context.SaveChanges();

        return user;
    }
}
