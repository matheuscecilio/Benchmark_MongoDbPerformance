using MongoDbPerformance.Enums;
using System;

namespace MongoDbPerformance.Domain
{
    public class Player : MongoDbEntityBase
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
