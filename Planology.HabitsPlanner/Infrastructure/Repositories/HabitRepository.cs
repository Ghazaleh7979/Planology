using Domain.Entities.HabitModels;
using Domain.IRepository;
using MongoDB.Driver;

public class HabitRepository : IHabitRepository
{
    private readonly IMongoCollection<Habit> _collection;

    public HabitRepository(IMongoDatabase database) => _collection = database.GetCollection<Habit>("Habits");

    public async Task<List<Habit>> GetByUserIdAsync(string userId)
    {
        return await _collection.Find(h => h.UserId == userId).ToListAsync();
    }

    public async Task<Habit?> GetByIdAsync(string id)
    {
        return await _collection.Find(h => h.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Habit habit)
    {
        await _collection.InsertOneAsync(habit);
    }

    public async Task UpdateAsync(Habit habit)
    {
        var filter = Builders<Habit>.Filter.Eq(h => h.Id, habit.Id);
        await _collection.ReplaceOneAsync(filter, habit);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Habit>.Filter.Eq(h => h.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task AddLogAsync(string habitId, HabitLog log)
    {
        var filter = Builders<Habit>.Filter.Eq(h => h.Id, habitId);
        var update = Builders<Habit>.Update.Push(h => h.Logs, log);
        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task<List<HabitLog>> GetLogsAsync(string habitId, DateTime from, DateTime to)
    {
        var habit = await _collection
            .Find(h => h.Id == habitId)
            .FirstOrDefaultAsync();

        return habit?.Logs
            .Where(l => l.Date >= from && l.Date <= to)
            .ToList() ?? [];
    }

    public async Task<int> GetCurrentStreakAsync(string habitId)
    {
        var habit = await _collection.Find(h => h.Id == habitId).FirstOrDefaultAsync();
        if (habit == null) return 0;

        var logs = habit.Logs
            .OrderByDescending(l => l.Date)
            .ToList();

        int streak = 0;
        var today = DateTime.UtcNow.Date;

        foreach (var log in logs)
        {
            if (log.Date.Date == today || log.Date.Date == today.AddDays(-streak))
            {
                if (log.Completed)
                    streak++;
                else
                    break;
            }
        }

        return streak;
    }
}
