using System.Data;
using System.Data.SqlClient;

namespace RiverLoggerApi.DBContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {            
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() 
            => new SqlConnection(_connectionString);
    }
}
