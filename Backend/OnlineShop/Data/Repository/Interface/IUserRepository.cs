using OnlineShop.Data.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.Data.Repository.Interface;

public interface IUserRepository
{
    Task<bool> UsernamePasswordIsCorrect(LoginModel user);
    Task<bool> UserIsExist(string userEmail);
    Task<bool> RegisterUser(SignUpViewModel user);
    Task<User> GetUserInfo(string userEmail);
    Task<User> EditUserInfo(string userEmail, EditUserModel user);
}