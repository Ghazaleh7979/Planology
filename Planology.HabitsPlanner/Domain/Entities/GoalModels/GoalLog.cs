namespace Domain.Entities.GoalModels
{
    public class GoalLog
    {
        public string Period { get; set; }
        public List<DateTime> CompletedDates { get; set; } = [];
        public int? Amount { get; set; }
        public string? MeasurementUnitId { get; set; }
    }
}
