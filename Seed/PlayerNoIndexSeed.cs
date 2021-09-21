using MongoDbPerformance.Configurations;

namespace MongoDbPerformance.Seed
{
    public class PlayerNoIndexSeed : PlayerSeed
    {
        public PlayerNoIndexSeed(
            int numberOfDocuments,
            MongoContext context
        ) : base
        (
            numberOfDocuments,
            context.PlayersNoIndex
        )
        { }
    }
}
