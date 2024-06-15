using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RiverLoggerApi.Repository.DbModels
{
    public class UserDbo
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public IList<UserEventDbo> UserEvents { get; set; }
    }
}
