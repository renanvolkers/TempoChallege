
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Tempo.Knight.Infra
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DataBaseConfig as a configuration instance
            services.Configure<DataBaseConfig>(configuration.GetSection("DataBaseConfig"));

            // Register the DbContext with the connection string from DataBaseConfig
            services.AddDbContext<KnightDbContext>((serviceProvider, options) =>
            {
                var databaseConfig = serviceProvider.GetRequiredService<IOptions<DataBaseConfig>>().Value;
                options.UseSqlServer(databaseConfig.ConnectionString);
            });

            // Optionally, register other services here

            return services;
        }



    }
}
