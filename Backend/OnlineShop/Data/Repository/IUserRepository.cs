using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OnlineShop.ViewModel;

namespace OnlineShop.Data;
public interface IUserRepository
{
    bool UsernamePasswordIsCorrect(LoginModel user);
    bool UserIsExist(RegisterModel user);
    bool RegisterUser(RegisterModel user);
    User GetUserInfo(string userEmail);
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

    public bool UserIsExist(RegisterModel user)
    {
        return _context.Users.Any(x => x.Email == user.Email);
    }
    public bool RegisterUser(RegisterModel user)
    {
        var userModel = new User
        {
            Id = 10,
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
}
