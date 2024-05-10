using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RiverLoggerApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RiverLoggerApi.Configuration
{
    public class JwtMiddleware
    {
        private readonly AppSettings _appSettings;

        public JwtMiddleware(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_appSettings.JwtSetting.SecurityKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        public List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };
            return claims;
        }
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _appSettings.JwtSetting.ValidIssuer,
                audience: _appSettings.JwtSetting.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_appSettings.JwtSetting.ExpiryInMinutes)),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
