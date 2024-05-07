using RiverLoggerApi.DBContext;

namespace RiverLoggerApi.Configuration
{
    public class ConfigureServices
    {
        public ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
        }
    }
}
