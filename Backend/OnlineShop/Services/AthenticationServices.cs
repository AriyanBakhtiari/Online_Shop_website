using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.Validation;
using OnlineShop.ViewModel;

namespace OnlineShop.Services;

public class AthenticationServices
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AthenticationServices(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<IResult> Login(LoginModel user)
    {
        var loginValidator = new LoginValidation();
        var validResult = await loginValidator.ValidateAsync(user);
        if (!validResult.IsValid)
            throw new ExceptionHandler(validResult.Errors[0].ErrorMessage, errorCode: StatusCodes.Status400BadRequest);

        if (!await _userRepository.UsernamePasswordIsCorrect(user))
            throw new ExceptionHandler("ایمیل یا پسورد وارد شده معتبر نمیباشد", errorCode: 400);

        var token = GetToken(user.Email);

        return Results.Ok(token);
    }

    public async Task<IResult> SignUp(SignUpViewModel user)
    {
        var signUpValidation = new SignUpValidation();
        var validResult = await signUpValidation.ValidateAsync(user);
        if (!validResult.IsValid) throw new ExceptionHandler(validResult.Errors[0].ErrorMessage, errorCode: 400);

        if (await _userRepository.UserIsExist(user.Email))
            throw new ExceptionHandler("با این ایمیل ثبت نام شده است لطفا وارد شوید");

        await _userRepository.RegisterUser(user);

        var token = GetToken(user.Email);
        if (string.IsNullOrEmpty(token))
            throw new ExceptionHandler("", "filed to create token");

        return Results.Ok(token);
    }

    private string GetToken(string email)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes
            (_configuration["Jwt:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }
}