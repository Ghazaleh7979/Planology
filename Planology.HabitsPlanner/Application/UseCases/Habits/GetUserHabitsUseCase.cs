using Application.DTOs;
using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Mapper;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class GetUserHabitsUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;

        public GetUserHabitsUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser,
            UserSessionStore sessionStore)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
            _sessionStore = sessionStore;
        }

        public async Task<List<HabitDto>> ExecuteAsync()
        {
            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var habits = await _habitRepo.GetByUserIdAsync(userId);
            return habits.Select(h => h.ToHabitDto()).ToList();
        }
    }
}
