using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace RiverLoggerApi.Repository
{
    public class DataContext
    {
        private DbSettings _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Server={_dbSettings.Server}; Database={_dbSettings.Database}; Uid={_dbSettings.UserId}; Pwd={_dbSettings.Password};";
            return new MySqlConnection(connectionString);
        }

        public async Task Init()
        {
            await _initDatabase();
            await _initTables();
        }

        private async Task _initDatabase()
        {
            // create database if it doesn't exist
            var connectionString = $"Server={_dbSettings.Server};Port={_dbSettings.Port};Uid={_dbSettings.UserId};Pwd={_dbSettings.Password};";
            using var connection = new MySqlConnection(connectionString);
            var sql = $"CREATE DATABASE IF NOT EXISTS `{_dbSettings.Database}`;";
            await connection.ExecuteAsync(sql);
        }

        private async Task _initTables()
        {
            // create tables if they don't exist
            using var connection = CreateConnection();
            await _initUsers();

            async Task _initUsers()
            {
                var sql = """
            DROP TABLE IF EXISTS `Users`;

            CREATE TABLE `Users` (
              `id` mediumint(8) unsigned NOT NULL auto_increment,
              `UserId` varchar(36) NOT NULL,
              `Name` varchar(255) default NULL,
              `LastName` varchar(255) default NULL,
              `Email` varchar(255) default NULL,
              `Password` varchar(255),
              PRIMARY KEY (`id`)
            ) AUTO_INCREMENT=1;

            INSERT INTO `Users` (`UserId`,`Name`,`LastName`,`Email`,`Password`)
            VALUES
              ("FBCD7EA4-7EC9-7646-AF4A-ED1AAF8A537D","Simon","Glenn","dui@yahoo.ca","IVW17GNL9AB"),
              ("44A6BC4E-79CB-3B08-7457-6276D2C444ED","Catherine","Dickson","metus.in.lorem@hotmail.org","QON48BHJ6QL"),
              ("158FE8B1-C3D8-4C7D-DC13-4D2969DDFAD2","Constance","Barrera","imperdiet@aol.ca","HHF12PWX5FV"),
              ("F487FE43-6B9D-A5F5-0CC5-882EE71A4555","Lance","Mccray","metus.aliquam.erat@protonmail.net","PLJ19QHG5VU"),
              ("6D4EDD18-67D2-698C-7B33-775B882629D6","Amir","Bullock","eget@icloud.ca","LDB66XUK8MI");
            """;
                await connection.ExecuteAsync(sql);
            }
        }
    }
}
