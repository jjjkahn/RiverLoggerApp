
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RiverLoggerApi.Configuration;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository;
using RiverLoggerApi.Repository.Repository.UserRepository;
using RiverLoggerApi.Services;
using RiverLoggerApi.ServicesConfiguration;
using System.Text;

namespace RiverLoggerApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            var appSettings = builder.Configuration.GetSection("AppSettings");
            // Add services to the container.
            services.Configure<AppSettings>(appSettings);

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            DbServiceConfigurator.ConfigureDB(services, builder);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<JwtMiddleware>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //JWT token
            var jwtSettings = builder.Configuration.GetSection("AppSettings");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["JwtSetting:ValidIssuer"],
                    ValidAudience = jwtSettings["JwtSetting:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings["JwtSetting:SecurityKey"]))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await context.Init();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
