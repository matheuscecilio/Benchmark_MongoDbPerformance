using Microsoft.Extensions.Configuration;
using MongoDbPerformance.Configurations;
using MongoDbPerformance.Interfaces.Seed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbPerformance.Seed
{
    public class MongoSeed : ISeeder
    {
        private readonly List<ISeeder> _seeders;

        public MongoSeed(
            IConfiguration configuration,
            MongoContext contexto
        )
        {
            var numberOfDocuments = configuration.GetValue<int>("NumberOfDocuments");

            _seeders = new List<ISeeder>
            {
                new PlayerIndexSeed(
                    numberOfDocuments,
                    contexto
                ),
                new PlayerNoIndexSeed(
                    numberOfDocuments,
                    contexto
                )
            };
        }

        public async Task Seed()
        {
            foreach(var seed in _seeders)
            {
                await seed.Seed();
            }
        }
    }
}
