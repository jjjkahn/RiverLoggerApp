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
            await _initEvent();
            await _initUsersEvents();

            async Task _initUsers()
            {
                var sql = """
            DROP TABLE IF EXISTS `Users`;

            CREATE TABLE `Users` (
              `UserId` varchar(450) NOT NULL,
              `Name` varchar(255) default NULL,
              `LastName` varchar(255) default NULL,
              `Email` varchar(255) default NULL,
              `Password` varchar(255),
              `Role` varchar(255) NOT NULL,
              PRIMARY KEY (`UserId`)
            ) ;

            INSERT INTO `Users` (`UserId`,`Name`,`LastName`,`Email`,`Password`,`Role`)
            VALUES
              ("FBCD7EA4-7EC9-7646-AF4A-ED1AAF8A537D","Simon","Glenn","dui@yahoo.ca","IVW17GNL9AB","User"),
              ("44A6BC4E-79CB-3B08-7457-6276D2C444ED","Catherine","Dickson","metus.in.lorem@hotmail.org","QON48BHJ6QL","User"),
              ("158FE8B1-C3D8-4C7D-DC13-4D2969DDFAD2","Constance","Barrera","imperdiet@aol.ca","HHF12PWX5FV",1),
              ("F487FE43-6B9D-A5F5-0CC5-882EE71A4555","Lance","Mccray","metus.aliquam.erat@protonmail.net","PLJ19QHG5VU","User"),
              ("6D4EDD18-67D2-698C-7B33-775B882629D6","jason","kahn","jjjkahn@gmail.com","password","User");
            """;
                await connection.ExecuteAsync(sql);
            }

            async Task _initEvent()
            {
                var sql = """
            DROP TABLE IF EXISTS `Event`;

            CREATE TABLE `Event` (
              `Id` varchar(450) NOT NULL,
              `Title` varchar(255) NOT NULL,
              `Category` varchar(255) NOT NULL,
              `Date` DATETIME NOT NULL,
              `UserId` varchar(450) NOT NULL,
              PRIMARY KEY (`Id`)
            ) ;
            """;
                await connection.ExecuteAsync(sql);
            }

            async Task _initUsersEvents()
            {
                var sql = """
            DROP TABLE IF EXISTS `UsersEvents`;

            CREATE TABLE `UsersEvents` (
              `Id` varchar(450) NOT NULL,
              `UserId` varchar(450) NOT NULL,
              `EventId` varchar(450) NOT NULL,
              PRIMARY KEY (`id`)
            ); 
            """;
                await connection.ExecuteAsync(sql);
            }
        }
    }
}
