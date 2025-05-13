namespace Application.Requests
{
    public class LogHabitRequest
    {
        public string HabitId { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public int? Amount { get; set; }
        public string? MeasurementUnitId { get; set; }
    }
}
