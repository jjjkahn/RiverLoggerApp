using RiverLoggerApi.Models;

namespace RiverLoggerApi.Services
{
    public interface IUserService
    {
        Task Create(User model);
        Task Delete(string id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task Update(string id, User model);
        Task<User> GetByEmail(string email);
    }
}