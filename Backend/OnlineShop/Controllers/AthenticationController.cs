using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

public class AthenticationController : Controller
{
    public AthenticationServices AthenticationServices { get; set; }

    public AthenticationController(AthenticationServices athenticationServices)
    {
        AthenticationServices = athenticationServices;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/Login")]
    public async Task<IResult> Login([FromBody] LoginModel user)
    {
        return await Task.FromResult(AthenticationServices.Login(user));
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/SingUp")]
    public async Task<IResult> SingUp([FromBody] RegisterModel user)
    {
        return await Task.FromResult(AthenticationServices.SingUp(user));
    }
}
