namespace RiverLoggerApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterInputModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }
    }
}
