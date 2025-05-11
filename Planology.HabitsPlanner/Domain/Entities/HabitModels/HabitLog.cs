namespace Domain.Entities.HabitModels
{
    public class HabitLog
    {
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        // مقدار انجام‌شده (مثلاً: 20 دقیقه، 15 صفحه، 2 کیلومتر و ...)
        public int? Amount { get; set; }
        public string? MeasurementUnitId { get; set; }
    }
}
