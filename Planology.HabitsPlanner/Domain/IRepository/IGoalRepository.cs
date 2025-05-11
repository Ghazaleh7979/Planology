namespace Domain.IRepository
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetByUserIdAsync(string userId);
        Task<Goal?> GetByIdAsync(string id);
        Task CreateAsync(Goal goal);
        Task UpdateAsync(Goal goal);
        Task DeleteAsync(string id);

        Task<Goal?> GetActiveGoalByHabitAsync(string habitId, DateTime date);
        Task<int> GetProgressAmountAsync(string goalId);
    }

}
