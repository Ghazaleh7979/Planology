using Domain.IRepository;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly IMongoCollection<Goal> _collection;

        public GoalRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Goal>("Goals");
        }

        public async Task<List<Goal>> GetByUserIdAsync(string userId)
        {
            return await _collection.Find(g => g.UserId == userId).ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(string id)
        {
            return await _collection.Find(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Goal goal)
        {
            await _collection.InsertOneAsync(goal);
        }

        public async Task UpdateAsync(Goal goal)
        {
            var filter = Builders<Goal>.Filter.Eq(g => g.Id, goal.Id);
            await _collection.ReplaceOneAsync(filter, goal);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Goal>.Filter.Eq(g => g.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        // گرفتن هدف فعال مرتبط با یک عادت در یک بازه
        public async Task<Goal?> GetActiveGoalByHabitAsync(string habitId, DateTime date)
        {
            return await _collection.Find(g =>
                g.RelatedHabitId == habitId &&
                g.StartDate <= date &&
                g.EndDate >= date
            ).FirstOrDefaultAsync();
        }

        // محاسبه مجموع پیشرفت یک هدف (مثلاً جمع صفحات خونده شده)
        public async Task<int> GetProgressAmountAsync(string goalId)
        {
            var goal = await _collection.Find(g => g.Id == goalId).FirstOrDefaultAsync();
            return goal?.ProgressLogs.Sum(x => x.Amount) ?? 0;
        }
    }

}
