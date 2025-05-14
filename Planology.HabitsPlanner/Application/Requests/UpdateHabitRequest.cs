namespace Application.Requests
{
    public class UpdateHabitRequest
    {
        public string HabitId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<DayOfWeek>? DaysOfWeek { get; set; }
        public int? TimesPerWeek { get; set; }
    }

}
