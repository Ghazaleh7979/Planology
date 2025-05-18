using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Mapper;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class GetUserHabitsUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;

        public GetUserHabitsUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
        }

        public async Task<List<HabitDto>> ExecuteAsync()
        {
            var userId = _currentUser.GetCurrentUserId();

            var habits = await _habitRepo.GetByUserIdAsync(userId);
            return habits.Select(h => h.ToHabitDto()).ToList();
        }
    }
}
