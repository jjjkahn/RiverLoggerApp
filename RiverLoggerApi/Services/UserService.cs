using Microsoft.Extensions.Options;
using RiverLoggerApi.DBContext;
using RiverLoggerApi.Models;

namespace RiverLoggerApi.Services
{
    public class UserService : IUserService
    {
        public readonly AppSettings _appSettings;
        public readonly DapperContext db;
        public UserService(IOptions<AppSettings> appSettings, DapperContext _db)
        {
            _appSettings = appSettings.Value;
            db = _db;
        }
        public Task<User?> AddAndUpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
