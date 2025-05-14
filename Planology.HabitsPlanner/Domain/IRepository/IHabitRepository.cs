using Domain.Entities.HabitModels;

namespace Domain.IRepository
{
    public interface IHabitRepository
    {
        Task<List<Habit>> GetByUserIdAsync(string userId);
        Task<Habit?> GetByIdAsync(string id);
        Task CreateAsync(Habit habit);
        Task UpdateAsync(Habit habit);
        Task DeleteAsync(string id);
        Task AddLogAsync(string habitId, HabitLog log);
        Task<List<HabitLog>> GetLogsAsync(string habitId, DateTime from, DateTime to);
        Task<int> GetCurrentStreakAsync(string habitId);
        Task ReplaceLogAsync(string id, HabitLog existingLog);
    }
}
