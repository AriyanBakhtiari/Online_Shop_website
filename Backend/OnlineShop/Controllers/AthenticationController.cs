using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.ViewModel;

namespace OnlineShop.Controllers;

public class AthenticationController : Controller
{
    public AthenticationController(AthenticationServices athenticationServices)
    {
        AthenticationServices = athenticationServices;
    }

    private AthenticationServices AthenticationServices { get; }

    [HttpPost]
    [AllowAnonymous]
    [Route("/Login")]
    public async Task<IResult> Login([FromBody] LoginModel user)
    {
        return await AthenticationServices.Login(user);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/SignUp")]
    public async Task<IResult> SignUp([FromBody] SignUpViewModel user)
    {
        return await AthenticationServices.SignUp(user);
    }
}