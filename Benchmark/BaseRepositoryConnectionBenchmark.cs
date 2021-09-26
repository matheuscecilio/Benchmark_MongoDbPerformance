using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using MongoDbPerformance.Configurations;
using System.IO;

namespace MongoDbPerformance.Benchmark
{
    public abstract class BaseRepositoryConnectionBenchmark
    {
        protected MongoContext _context;

        public BaseRepositoryConnectionBenchmark()
        {
            var configuration = GetConfigurations();

            var connectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
            var database = configuration.GetSection("MongoDb:Database").Value;

            var mongoOptions = new MongoOptions
            {
                Connection = connectionString,
                Database = database
            };

            var options = Options.Create(mongoOptions);

            _context = new MongoContext(options);
        }

        private static IConfigurationRoot GetConfigurations()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
    }
}
