using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository.DbModels;
using RiverLoggerApi.Repository.Repository.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace RiverLoggerApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository dataContext;
        private readonly IConfiguration configuration;

        public AuthService(IUserRepository dataContext, IConfiguration configuration)
        {
            this.dataContext = dataContext;
            this.configuration = configuration;
        }

        public async Task<bool> IsAuthenticated(string email, string password)
        {
            var user = await this.GetByEmail(email);
            return await DoesUserExists(email) && BC.Verify(password, user.Password);
        }

        public async Task<bool> DoesUserExists(string email)
        {
            var user = await dataContext.GetByEmail(email);
            return user != null;
        }

        public async Task<UserDbo> GetById(string id)
        {
            return await this.dataContext.GetById(id);
        }

        public async Task<IEnumerable<UserDbo>> GetAll()
        {
            return await this.dataContext.GetAll();
        }

        public async Task<UserDbo> GetByEmail(string email)
        {
            return await this.dataContext.GetByEmail(email);
        }

        public async Task<UserDbo> RegisterUser(UserDbo model)
        {
            var id = Guid.NewGuid().ToString();
            var existWithId = await GetById(id);
            while (existWithId != null)
            {
                id = Guid.NewGuid().ToString();
                existWithId = await GetById(id);
            }
            model.UserId = id;
            model.Password = BC.HashPassword(model.Password);

            await dataContext.Create(model);

            return model;
        }

        public string GenerateJwtToken(string email, string role)
        {
            var appSettings = configuration.GetSection("AppSettings");
            var issuer = appSettings["JwtSetting:ValidIssuer"];
            var audience = appSettings["JwtSetting:ValidAudience"];
            var key = Encoding.ASCII.GetBytes(appSettings["JwtSetting:SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, email),
                            new Claim(JwtRegisteredClaimNames.Email, email),
                            new Claim(ClaimTypes.Role, role),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                        }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string DecodeEmailFromToken(string token)
        {
            var decodedToken = new JwtSecurityTokenHandler();
            var indexOfTokenValue = 7;

            var t = decodedToken.ReadJwtToken(token.Substring(indexOfTokenValue));

            return t.Payload.FirstOrDefault(x => x.Key == "email").Value.ToString();
        }

        public async Task<UserDbo> ChangeRole(string email, string role)
        {
            var user = await this.GetByEmail(email);
            user.Role = role;
            await this.dataContext.Update(user);

            return user;
        }
    }
}
