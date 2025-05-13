using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Requests;
using Domain.Entities.HabitModels;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class CreateHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly UserSessionStore _sessionStore;
        private readonly ICurrentUserService _currentUser;
        public CreateHabitUseCase(IHabitRepository habitRepo, UserSessionStore sessionStore, ICurrentUserService currentUser)
        {
            _habitRepo = habitRepo;
            _sessionStore = sessionStore;
            _currentUser = currentUser;
        }
        public async Task<Habit> ExecuteAsync(CreateHabitRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Habit name is required.");

            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var habit = new Habit
            {
                UserId = userId,
                Name = request.Name,
                Schedule = new HabitSchedule
                {
                    DaysOfWeek = request.DaysOfWeek,
                    TimesPerWeek = request.TimesPerWeek,
                },
                CreatedAt = DateTime.UtcNow
            };

            await _habitRepo.CreateAsync(habit);
            return habit;
        }
    }
}
