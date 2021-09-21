using System.Threading.Tasks;

namespace MongoDbPerformance.Interfaces.Seed
{
    public interface ISeeder
    {
        Task Seed();
    }
}
