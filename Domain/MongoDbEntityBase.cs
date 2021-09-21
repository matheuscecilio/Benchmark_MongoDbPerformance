using System;

namespace MongoDbPerformance.Domain
{
    public class MongoDbEntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
