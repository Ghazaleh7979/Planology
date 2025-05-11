using Domain.Entities.GoalModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Goal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string UserId { get; set; }

    public string Name { get; set; } // مثلاً: "خواندن 200 صفحه"

    public string? RelatedHabitId { get; set; } // به کدام Habit مربوط است (در صورت وجود)

    public GoalFrequency Frequency { get; set; } // مثلا: Weekly، Monthly

    public int? TotalAmount { get; set; }
    public string? MeasurementUnitId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<GoalLog> ProgressLogs { get; set; } = new();
}

