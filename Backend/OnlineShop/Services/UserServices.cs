using AutoMapper;
using Microsoft.OpenApi.Extensions;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.Validation;
using OnlineShop.ViewModel;

namespace OnlineShop.Services;

public class UserServices
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserViewModel> GetUserInfoAsync(string token)
    {
        var userEmail = Helper.GetUserEmailViaToken(token);

        var user = await _userRepository.GetUserInfo(userEmail);
        //automapper
        var userModel = new UserViewModel
        {
            Email = user.Email,
            FirstName = user.FirstName ?? "-",
            LastName = user.LastName ?? "-",
            RegisterDate = Helper.ToPersianDateTime(user.RegisterDate),
            NationalId = user.NationalId ?? "-",
            BirthDate = Helper.ToPersianDateTime(user.BirthDate),
            Address = user.Address ?? "-",
            Gender = user.Gender.GetDisplayName(),
            IsAdmin = user.IsAdmin,
            MobileNumber = user.MobileNumber ?? "-",
            Wallet = user.Wallet.ToString().ToThousandSepratedInt(),
            ZipCode = user.ZapCode ?? "-"
        };
        return userModel;
    }

    public async Task<UserViewModel> EditUserInfo(string token, EditUserModel userModel)
    {
        var editUserValidation = new EditUserValidation();
        var validResult = await editUserValidation.ValidateAsync(userModel);
        if (!validResult.IsValid) throw new ExceptionHandler(validResult.Errors[0].ErrorMessage, errorCode: 400);

        var userEmail = Helper.GetUserEmailViaToken(token);
        if (!await _userRepository.UserIsExist(userEmail))
            throw new ExceptionHandler("لطفا مجدد وارد سایت شوید");

        var userinfo = await _userRepository.EditUserInfo(userEmail, userModel);
        var user = new UserViewModel
        {
            Email = userinfo.Email,
            FirstName = userinfo.FirstName ?? "-",
            LastName = userinfo.LastName ?? "-",
            RegisterDate = Helper.ToPersianDateTime(userinfo.RegisterDate),
            NationalId = userinfo.NationalId ?? "-",
            BirthDate = Helper.ToPersianDate(userinfo.BirthDate.ToString()),
            Address = userinfo.Address ?? "-",
            Gender = userinfo.Gender.GetDisplayName(),
            IsAdmin = userinfo.IsAdmin,
            MobileNumber = userinfo.MobileNumber ?? "-",
            Wallet = userinfo.Wallet.ToString().ToThousandSepratedInt(),
            ZipCode = userinfo.ZapCode ?? "-"
        };

        return user;
    }
}