using RiverLoggerApi.Repository.DbModels;

namespace RiverLoggerApi.Repository.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task Create(UserDbo user);
        Task Delete(Guid id);
        Task<IEnumerable<UserDbo>> GetAll();
        Task<UserDbo> GetByEmail(string email);
        Task<UserDbo> GetById(Guid id);
        Task Update(UserDbo user);
    }
}