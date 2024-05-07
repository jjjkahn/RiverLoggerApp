using System.ComponentModel.DataAnnotations;

namespace RiverLoggerApi.Repository.DbModels
{
    public class UserDbo
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string EmailConfirmed { get; set; }
    }
}
