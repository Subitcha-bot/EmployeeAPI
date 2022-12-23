using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyEmployeeApplication.IService;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyEmployeeApplication.Service
{

    public class JwtServices
    { 

        private readonly string _secretKey;
        private readonly string _expTime;

        public JwtServices(IConfiguration config)
        {
            _secretKey = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expTime = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expTime)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}


