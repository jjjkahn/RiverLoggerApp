namespace RiverLoggerApi.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
        }
    }
}
