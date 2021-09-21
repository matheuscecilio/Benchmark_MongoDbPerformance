using Microsoft.Extensions.Options;
using MongoDbPerformance.Configurations;

namespace MongoDbPerformance.Benchmark
{
    public abstract class BaseRepositoryConnectionBenchmark
    {
        protected MongoContext _context;

        public BaseRepositoryConnectionBenchmark()
        {
            var mongoOptions = new MongoOptions
            {
                Connection = "mongodb://localhost:27017",
                Database = "MongoDbIndexPerformanceTest"
            };

            var options = Options.Create(mongoOptions);

            _context = new MongoContext(options);
        }
    }
}
