using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbPerformance.Constants;
using MongoDbPerformance.Domain;

namespace MongoDbPerformance.Configurations
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoOptions> mongoOptions)
        {
            var client = new MongoClient(mongoOptions.Value.Connection);
            _database = client.GetDatabase(mongoOptions.Value.Database);
        }

        public IMongoCollection<Player> PlayersIndex => _database.GetCollection<Player>(NamesCollections.PlayerIndex);
        public IMongoCollection<Player> PlayersNoIndex => _database.GetCollection<Player>(NamesCollections.PlayerNoIndex);
    }
}
