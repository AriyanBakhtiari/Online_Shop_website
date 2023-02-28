using OnlineShop.Data;
using OnlineShop.ViewModel;

namespace OnlineShop.Services
{
    public class UserServices
    {
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserInfo(string token)
        {
            string userEmail = Helper.GetUserEmailViaToken(token);
            
            var user = _userRepository.GetUserInfo(userEmail);
            var userModel = new UserModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RegisterDate = user.RegisterDate,
                NationalId = user.NationalId,
                BirthDate = user.BirthDate,
                Address = user.Address,
                Gender = user.Gender,
                IsAdmin = user.IsAdmin,
                MobileNumber = user.MobileNumber,
                Wallet = user.Wallet,
                ZapCode = user.ZapCode,
            };
            return userModel;
        }
    }
}
