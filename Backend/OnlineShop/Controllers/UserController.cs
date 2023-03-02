using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using OnlineShop.Services;
using OnlineShop.ViewModel;
using System.Net;
using System.Net.Http.Headers;

namespace OnlineShop.Controllers;

[Route("/User")]
public class UserController : ControllerBase
{
    private  UserServices UserServices { get; set; }

    public UserController(UserServices userServices)
    {
        UserServices = userServices;
    }

    [HttpGet]
    [Authorize]
    public async Task<UserModel> GetUserInfo()
    {
        var token = Request.Headers.Authorization;
        return await UserServices.GetUserInfoAsync(token);
    }

    [HttpPost]
    [Authorize]
    public async Task<UserModel> EditUserInfo([FromBody] EditUserModel user)
    {
        var token = Request.Headers.Authorization;
        return await Task.FromResult(UserServices.EditUserInfo(token,user));
    }
}
