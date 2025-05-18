using Application.DTOs;
using Application.Interfaces;
using Domain.Entities.HabitModels;
using MongoDB.Driver;

namespace Infrastructure.Services
{
    public class TaskQueryService : ITaskQueryService
    {
        private readonly IMongoCollection<Habit> _habits;

        public TaskQueryService(IMongoDatabase database)
        {
            _habits = database.GetCollection<Habit>("Habits");
        }

        public async Task<List<MissedTaskDto>> GetMissedTasksAsync(string userId)
        {
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            var dayOfWeekYesterday = yesterday.DayOfWeek;

            var filter = Builders<Habit>.Filter.Eq(h => h.UserId, userId);
            var userHabits = await _habits.Find(filter).ToListAsync();

            var missedTasks = userHabits
                .Where(h =>
                    h.Schedule.DaysOfWeek.Contains(dayOfWeekYesterday)
                    &&
                    !h.Logs.Any(log => log.Date.Date == yesterday && log.Completed))
                .Select(h => new MissedTaskDto
                {
                    Id = h.Id,
                    Title = h.Name
                })
                .ToList();

            return missedTasks;
        }
    }
}
