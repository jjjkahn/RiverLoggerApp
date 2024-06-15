using Dapper;
using RiverLoggerApi.Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RiverLoggerApi.Repository.Repository.EventRepository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDbo>> GetAllEventsByUserId(string id)
        {
            using var connection = _context.CreateConnection();
            var sql = """SELECT * FROM Event WHERE UserId = @id """;
            return await connection.QueryAsync<EventDbo>(sql, new { id });
        }

        public async Task<EventDbo> GetById(string id)
        {
            using var connection = _context.CreateConnection();
            var sql = """SELECT * FROM Event WHERE Id = @id""";
            return await connection.QuerySingleOrDefaultAsync<EventDbo>(sql, new { id });
        }

        public async Task CreateEvent(EventDbo eventModel)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            INSERT INTO Event (Id, Title, Category, Date, UserId)
            VALUES (@Id, @Title, @Category, @Date, @UserId,)
            """;
            await connection.ExecuteAsync(sql, eventModel);
        }

        public async Task Update(EventDbo user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            UPDATE Event 
                SET Id = @Id,
                    Title = @Title, 
                    Category = @Category
                    Date = @Date,
                    UserId = @UserId
                WHERE Id = @Id
            """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Delete(string id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM Event 
            WHERE Id = @id
            """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}
