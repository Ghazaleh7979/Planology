using Domain.Enums;

namespace Application.Requests
{
    public class CreateHabitRequest
    {
        public string Name { get; set; }
        public HabitTiming HabitTimingEnum { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; } = new();
        public int? TimesPerWeek { get; set; }
    }
}
