
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
            services.AddSingleton<IDataBaseConfig>(sp => sp.GetRequiredService<IOptions<DataBaseConfig>>().Value);
            var applicationSetting = configuration.GetSection("DataBaseConfig").Get<DataBaseConfig>() ?? new DataBaseConfig("", "");
            //// Register the DbContext with the connection string from DataBaseConfig
            services.AddDbContext<KnightDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(applicationSetting.ConnectionString);
            });

            // Optionally, register other services here

            return services;
        }



    }
}
