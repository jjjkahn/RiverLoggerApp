using System.Diagnostics;

namespace RiverLoggerApi.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public JWTSetting JwtSetting { get; set; }
    }

    public class JWTSetting
    {
        public string SecurityKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
