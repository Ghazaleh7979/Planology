using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class DeleteHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;

        public DeleteHabitUseCase(
            IHabitRepository habitRepo)
        {
            _habitRepo = habitRepo;
        }

        public async Task ExecuteAsync(string habitId)
        {
            var habit = await _habitRepo.GetByIdAsync(habitId);
            if (habit == null)
                throw new KeyNotFoundException("Habit not found.");

            await _habitRepo.DeleteAsync(habitId);
        }
    }

}
