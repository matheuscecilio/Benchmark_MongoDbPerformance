using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MongoDbPerformance.Configurations
{
    public static class MongoInstaller
    {
        public static void InstalarMongo(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
            var database = configuration.GetSection("MongoDb:Database").Value;

            services.Configure<MongoOptions>(config =>
            {
                config.Connection = connectionString;
                config.Database = database;
            });

            services.AddScoped<MongoContext>();
        }
    }
}
