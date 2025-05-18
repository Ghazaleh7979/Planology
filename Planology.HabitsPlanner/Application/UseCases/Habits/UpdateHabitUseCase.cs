using Application.Extensions;
using Application.Interfaces;
using Application.Requests;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class UpdateHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;

        public UpdateHabitUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
        }

        public async Task ExecuteAsync(UpdateHabitRequest request)
        {
            var userId = _currentUser.GetCurrentUserId();

            var habit = await _habitRepo.GetByIdAsync(request.HabitId);

            habit!.Name = request.Name;
            habit.Schedule.DaysOfWeek = request.DaysOfWeek ?? [];
            habit.Schedule.TimesPerWeek = request.TimesPerWeek;

            await _habitRepo.UpdateAsync(habit);
        }
    }

}
