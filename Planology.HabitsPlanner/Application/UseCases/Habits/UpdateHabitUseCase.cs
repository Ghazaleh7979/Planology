using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Requests;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class UpdateHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;

        public UpdateHabitUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser,
            UserSessionStore sessionStore)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
            _sessionStore = sessionStore;
        }

        public async Task ExecuteAsync(UpdateHabitRequest request)
        {
            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var habit = await _habitRepo.GetByIdAsync(request.HabitId);

            habit!.Name = request.Name;
            habit.Schedule.DaysOfWeek = request.DaysOfWeek ?? [];
            habit.Schedule.TimesPerWeek = request.TimesPerWeek;

            await _habitRepo.UpdateAsync(habit);
        }
    }

}
