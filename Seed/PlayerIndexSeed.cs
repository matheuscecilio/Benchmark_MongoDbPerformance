using MongoDB.Driver;
using MongoDbPerformance.Configurations;
using MongoDbPerformance.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbPerformance.Seed
{
    public class PlayerIndexSeed : PlayerSeed
    {
        private readonly string _indexName = "PlayerNameIndex";
        private readonly string _indexDate = "PlayerDateOfBirthIndex";

        public PlayerIndexSeed(
            int numberOfDocuments,
            MongoContext context
        ) : base
        (
            numberOfDocuments, 
            context.PlayersIndex
        )
        { }

        public override async Task Seed()
        {
            await base.Seed();
            await DropNameIndexAsync();
            await CreateNameIndexAsync();
        }

        private async Task CreateNameIndexAsync()
        {
            var indexKeysDefinition = Builders<Player>.IndexKeys.Ascending(x => x.Name);

            var indexModel = new CreateIndexModel<Player>(
                keys: indexKeysDefinition,
                options: new CreateIndexOptions<Player>
                {
                    Name = _indexName
                }
            );

            await _collection.Indexes.CreateOneAsync(indexModel);
        }

        private async Task DropNameIndexAsync()
        {
            var indexExist = await IndexExist(_indexName);

            if (indexExist)
            {
                await _collection.Indexes.DropOneAsync(
                    _indexName
                );
            }
        }

        private async Task CreateDateIndexAsync()
        {
            var indexKeysDefinition = Builders<Player>.IndexKeys.Ascending(x => x.DateOfBirth);

            var indexModel = new CreateIndexModel<Player>(
                keys: indexKeysDefinition,
                options: new CreateIndexOptions<Player>
                {
                    Name = _indexDate
                }
            );

            await _collection.Indexes.CreateOneAsync(indexModel);
        }

        private async Task DropDateIndexAsync()
        {
            var indexExist = await IndexExist(_indexDate);

            if (indexExist)
            {
                await _collection.Indexes.DropOneAsync(
                    _indexDate
                );
            }
        }

        private async Task<bool> IndexExist(string index)
        {
            var indices = await _collection.Indexes
                .List()
                .ToListAsync();

            return indices.Any(indice => indice.GetElement("name").Value == index);
        }
    }
}
