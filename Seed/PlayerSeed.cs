using Bogus;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbPerformance.Constants;
using MongoDbPerformance.Domain;
using MongoDbPerformance.Enums;
using MongoDbPerformance.Interfaces.Seed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbPerformance.Seed
{
    public abstract class PlayerSeed : ISeeder
    {
        private readonly int _numberOfDocuments;
        private readonly Faker _faker;
        protected readonly IMongoCollection<Player> _collection;

        public PlayerSeed(
            int numberOfDocuments,
            IMongoCollection<Player> collection
        )
        {
            _faker = new();
            _collection = collection;
            _numberOfDocuments = numberOfDocuments;
        }

        public virtual async Task Seed()
        {
            var emptyCollection = await GetEmptyCollection();

            if (emptyCollection)
            {
                var players = CreatePlayers();
                await InsertData(players);
            }
        }

        private IEnumerable<Player> CreatePlayers()
        {
            var players = new List<Player>();

            for (var i = 0; i < _numberOfDocuments; i++)
            {
                var playerName = i == (_numberOfDocuments / 2)
                    ? DefaultPlayerNames.CristianoRonaldo
                    : _faker.Name.FullName();

                var player = new Player
                {
                    Name = playerName,
                    DateOfBirth = _faker.Date.Between(
                        new DateTime(1990, 01, 01),
                        new DateTime(2000, 01, 01)
                    ),
                    Position = _faker.PickRandom<Position>()
                };

                players.Add(player);
            }

            return players;
        }

        private async Task<bool> GetEmptyCollection()
        {
            var numberOfDocuments = await _collection
                .AsQueryable()
                .CountAsync();

            return numberOfDocuments == 0;
        }

        private async Task InsertData(IEnumerable<Player> data)
            => await _collection.InsertManyAsync(data);
    }
}
