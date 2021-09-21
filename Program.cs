using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDbPerformance.Benchmark;
using MongoDbPerformance.Configurations;
using MongoDbPerformance.Seed;
using System;
using System.Threading.Tasks;

namespace MongoDbPerformance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configuration) =>
            {
                configuration.Sources.Clear();
                configuration.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices(async (hostContext, services) =>
            {
                services.InstalarMongo(hostContext.Configuration);

                Console.WriteLine($"{DateTime.UtcNow} - Inicilizando aplicação de seeds");
                await AplicarSeeds(hostContext.Configuration, services);
                Console.WriteLine($"{DateTime.UtcNow} - Finalizada aplicação de seeds");

                BenchmarkRunner.Run<PlayerNameBenchmark>();
                BenchmarkRunner.Run<PlayerDateOfBirthBenchmark>();
            });

        private static async Task AplicarSeeds(
            IConfiguration configuration,
            IServiceCollection services
        )
        {
            var provider = services.BuildServiceProvider();
            var contexto = provider.GetRequiredService<MongoContext>();
            await new MongoSeed(configuration, contexto).Seed();
        }
    }
}
