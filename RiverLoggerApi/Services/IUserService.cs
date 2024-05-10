using RiverLoggerApi.Models;

namespace RiverLoggerApi.Services
{
    public interface IUserService
    {
        Task Create(User model);
        Task Delete(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Update(Guid id, User model);
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<User> GetByEmail(string email);
    }
}