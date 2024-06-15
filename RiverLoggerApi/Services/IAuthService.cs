using RiverLoggerApi.Repository.DbModels;

namespace RiverLoggerApi.Services
{
    public interface IAuthService
    {
        Task<UserDbo> ChangeRole(string email, string role);
        string DecodeEmailFromToken(string token);
        Task<bool> DoesUserExists(string email);
        string GenerateJwtToken(string email, string role);
        Task<IEnumerable<UserDbo>> GetAll();
        Task<UserDbo> GetByEmail(string email);
        Task<UserDbo> GetById(string id);
        Task<bool> IsAuthenticated(string email, string password);
        Task<UserDbo> RegisterUser(UserDbo model);
    }
}