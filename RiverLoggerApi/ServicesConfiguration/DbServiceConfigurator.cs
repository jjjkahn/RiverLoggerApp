using RiverLoggerApi.Repository;

namespace RiverLoggerApi.ServicesConfiguration
{
    public class DbServiceConfigurator
    {
        public static void ConfigureDB(IServiceCollection services, WebApplicationBuilder builder)
        {
            // configure strongly typed settings object
            services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

            // configure DI for application services
            services.AddSingleton<DataContext>();
        }
    }
}
