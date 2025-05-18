using Domain.Entities.HabitModels;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class CheckHabitUseCase
    {
        private readonly IHabitRepository _habitRepository;
        public CheckHabitUseCase(
            IHabitRepository habitRepository) => _habitRepository = habitRepository;
        public async Task ExecuteAsync(string habitId)
        {
            var habit = await _habitRepository.GetByIdAsync(habitId);
            var existingLog = habit!.Logs.FirstOrDefault(log => log.Date == DateTime.UtcNow);
            if (existingLog != null)
            {
                existingLog.Completed = !existingLog.Completed;
                await _habitRepository.ReplaceLogAsync(habit.Id, existingLog);
                return;
            }
            var log = new HabitLog
            {
                Date = DateTime.UtcNow,
                Completed = true
            };

            await _habitRepository.AddLogAsync(habit!.Id, log);
        }
    }
}
