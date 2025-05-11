namespace Domain.Entities.HabitModels
{
    public class HabitSchedule
    {
        public List<DayOfWeek> DaysOfWeek { get; set; } = new();
        public int? TimesPerWeek { get; set; }
    }
}
