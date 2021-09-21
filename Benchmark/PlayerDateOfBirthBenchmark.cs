using BenchmarkDotNet.Attributes;
using MongoDB.Driver;
using MongoDbPerformance.Domain;
using System.Threading.Tasks;

namespace MongoDbPerformance.Benchmark
{
    public class PlayerDateOfBirthBenchmark : BaseRepositoryConnectionBenchmark
    {
        public PlayerDateOfBirthBenchmark() : base() { }

        [Benchmark]
        public async Task<Player> GetOldestPlayerIndexAsync()
        {
            var sort = Builders<Player>.Sort.Ascending(x => x.DateOfBirth);

            return await _context.PlayersIndex
                .Find(_ => true)
                .Sort(sort)
                .FirstOrDefaultAsync();
        }

        [Benchmark]
        public async Task<Player> GetOldestPlayerNoIndexAsync()
        {
            var sort = Builders<Player>.Sort.Ascending(x => x.DateOfBirth);

            return await _context.PlayersNoIndex
                .Find(_ => true)
                .Sort(sort)
                .FirstOrDefaultAsync();
        }
    }
}
