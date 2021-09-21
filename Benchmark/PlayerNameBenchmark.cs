using BenchmarkDotNet.Attributes;
using MongoDB.Driver;
using MongoDbPerformance.Constants;
using MongoDbPerformance.Domain;
using System.Threading.Tasks;

namespace MongoDbPerformance.Benchmark
{
    public class PlayerNameBenchmark : BaseRepositoryConnectionBenchmark
    {
        public PlayerNameBenchmark() : base() { }

        [Benchmark]
        public async Task<Player> GetByNameIndexAsync()
            => await _context.PlayersIndex
                .Find(x => x.Name == DefaultPlayerNames.CristianoRonaldo)
                .FirstOrDefaultAsync();

        [Benchmark]
        public async Task<Player> GetByNameNoIndexAsync()
            => await _context.PlayersNoIndex
                .Find(x => x.Name == DefaultPlayerNames.CristianoRonaldo)
                .FirstOrDefaultAsync();
    }
}

