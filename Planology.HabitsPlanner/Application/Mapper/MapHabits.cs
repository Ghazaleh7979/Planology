using Application.DTOs;
using Domain.Entities.HabitModels;

namespace Application.Mapper
{
    public static class MapHabits
    {
        public static HabitDto ToHabitDto(this Habit habit)
        {
            return new HabitDto
            {
                CreatedAt = habit.CreatedAt,
                Id = habit.Id,
                Name = habit.Name
            };
        }
    }
}
