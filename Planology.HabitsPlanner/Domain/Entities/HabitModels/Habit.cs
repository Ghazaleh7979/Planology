using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.HabitModels
{
    public class Habit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public HabitSchedule Schedule { get; set; }
        public List<HabitLog> Logs { get; set; } = new();
    }
}
