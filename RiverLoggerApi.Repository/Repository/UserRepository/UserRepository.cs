using Dapper;
using RiverLoggerApi.Repository.DbModels;

namespace RiverLoggerApi.Repository.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDbo>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users
        """;
            return await connection.QueryAsync<UserDbo>(sql);
        }

        public async Task<UserDbo> GetById(Guid id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users 
            WHERE UserId = @UserId
        """;
            return await connection.QuerySingleOrDefaultAsync<UserDbo>(sql, new { id });
        }

        public async Task<UserDbo> GetByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users 
            WHERE Email = @email
        """;
            return await connection.QuerySingleOrDefaultAsync<UserDbo>(sql, new { email });
        }

        public async Task Create(UserDbo user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            INSERT INTO Users (UserId, Name, LastName, Email, Password)
            VALUES (@UserId, @Name, @LastName, @Email, @Password)
        """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Update(UserDbo user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            UPDATE Users 
            SET Name = @Name,
                LastName = @LastName, 
                Email = @Email, 
                Password = @Password
            WHERE UserId = @UserId
        """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Delete(Guid id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM Users 
            WHERE Id = @id
        """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}
