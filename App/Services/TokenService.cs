using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using dotnet_webapi_erp;
using System.IdentityModel.Tokens.Jwt;
using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;

namespace dotnet_webapi_erp.App.Services
{
    public class TokenService
    {
        public static Token GenerateToken(Guid id)
        {
            var key = Encoding.ASCII.GetBytes(Key.secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new Token(id, tokenString);

        }
        public static bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key.secret);

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}