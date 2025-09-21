using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Qesatly.Core.Bases;
using Qesatly.Service.Abstracts;
using Qesatly.Service.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Qesatly.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ResponseHandler _responseHandler;
        private readonly IConfiguration _configuration;

        public AuthService(ResponseHandler responseHandler, IConfiguration configuration)
        {
            _responseHandler = responseHandler;
            _configuration = configuration;
        }
        public async Task<Response<string>> LoginAsync(LoginDto loginDto)
        {
            var fixedPhone = "01147379513";
            var fixedPassword = "123456";
            if (loginDto.Phone != fixedPhone || loginDto.Password != fixedPassword)
            {
                return _responseHandler.Unauthorized<string>();
            }
            var jwtSettings = _configuration.GetSection("Jwt");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, fixedPhone)
        }),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return _responseHandler.Success(jwtToken, null);
        }
    }
}
