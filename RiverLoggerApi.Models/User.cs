using System.ComponentModel.DataAnnotations;

namespace RiverLoggerApi.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public IList<UserEvent> UserEvents { get; set; }

        public User()
        {
            UserId = Guid.NewGuid();
        }
    }
}
