using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Data;
using OnlineShop.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.Services
{
    public class AthenticationServices 
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        public AthenticationServices(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public IResult Login (LoginModel user)
        {
            if (!_userRepository.UsernamePasswordIsCorrect(user))
                return Results.Unauthorized();

            var token = GetToken(user.Email);

            return Results.Ok(token);
        }
        public IResult SignUp(RegisterModel user)
        {
            if (_userRepository.UserIsExist(user.Email))
                return Results.Problem();

            var test = _userRepository.RegisterUser(user);

            var token = GetToken(user.Email);

            return Results.Ok(token);
        }

        public string GetToken(string Email)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, Email),
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
}
