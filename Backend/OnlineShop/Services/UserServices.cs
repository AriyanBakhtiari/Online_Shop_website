using OnlineShop.Data;
using OnlineShop.ViewModel;

namespace OnlineShop.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetUserInfoAsync(string token)
        {
            string userEmail = Helper.GetUserEmailViaToken(token);

            var user = await _userRepository.GetUserInfoAsync(userEmail);
            //automapper
            var userModel = new UserModel
            {
                Email = user.Email,
                FirstName = user.FirstName ?? "-",
                LastName = user.LastName ?? "-",
                RegisterDate = Helper.ToPersianDateTime(user.RegisterDate),
                NationalId = user.NationalId ?? "-",
                BirthDate = Helper.ToPersianDateTime(user.BirthDate),
                Address = user.Address ?? "-",
                Gender = user.Gender,
                IsAdmin = user.IsAdmin,
                MobileNumber = user.MobileNumber ?? "-",
                Wallet = user.Wallet,
                ZapCode = user.ZapCode ?? "-",
            };
            return userModel;
        }

        public UserModel EditUserInfo(string token, EditUserModel userModel)
        {
            string userEmail = Helper.GetUserEmailViaToken(token);

            if (!_userRepository.UserIsExist(userEmail))
                return null;

            var userinfo = _userRepository.EditUserInfo(userEmail, userModel);

            var user = new UserModel
            {
                Email = userinfo.Email,
                FirstName = userinfo.FirstName ?? "-",
                LastName = userinfo.LastName ?? "-",
                RegisterDate = Helper.ToPersianDateTime(userinfo.RegisterDate),
                NationalId = userinfo.NationalId ?? "-",
                BirthDate = Helper.ToPersianDate(userinfo.BirthDate.ToString()),
                Address = userinfo.Address ?? "-",
                Gender = userinfo.Gender,
                IsAdmin = userinfo.IsAdmin,
                MobileNumber = userinfo.MobileNumber ?? "-",
                Wallet = userinfo.Wallet,
                ZapCode = userinfo.ZapCode ?? "-",
            };

            return user;
        }
    }
}