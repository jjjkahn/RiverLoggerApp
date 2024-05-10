namespace RiverLoggerApi.Models
{
    public class AuthenticateResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
