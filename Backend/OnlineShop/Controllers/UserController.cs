using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

[Authorize]
[Route("/[controller]")]
public class UserController : ControllerBase
{
    public UserController(UserServices userServices)
    {
        UserServices = userServices;
    }

    private UserServices UserServices { get; }

    [HttpGet]
    public async Task<UserViewModel> GetUserInfo()
    {
        var token = Request.Headers.Authorization;
        return await UserServices.GetUserInfoAsync(token);
    }

    [HttpPost]
    public async Task<UserViewModel> EditUserInfo([FromBody] EditUserModel user)
    {
        var token = Request.Headers.Authorization;
        return await UserServices.EditUserInfo(token, user);
    }
}