using Application.DTOs;
using Application.Requests;
using Application.UseCases.Habits;

namespace Application.Helper
{
    public class HabitService
    {
        private readonly CreateHabitUseCase _createHabit;
        private readonly UpdateHabitUseCase _updateHabit;
        private readonly DeleteHabitUseCase _deleteHabit;
        private readonly LogHabitUseCase _logHabit;
        private readonly CheckHabitUseCase _checkHabit;
        private readonly GetTodayHabitsUseCase _getTodayHabits;
        private readonly GetUserHabitsUseCase _getUserHabits;

        public HabitService(
            CreateHabitUseCase createHabit,
            UpdateHabitUseCase updateHabit,
            DeleteHabitUseCase deleteHabit,
            LogHabitUseCase logHabit,
            CheckHabitUseCase checkHabit,
            GetTodayHabitsUseCase getTodayHabits,
            GetUserHabitsUseCase getUserHabits)
        {
            _createHabit = createHabit;
            _updateHabit = updateHabit;
            _deleteHabit = deleteHabit;
            _logHabit = logHabit;
            _checkHabit = checkHabit;
            _getTodayHabits = getTodayHabits;
            _getUserHabits = getUserHabits;
        }

        public async Task CreateAsync(CreateHabitRequest request)
            => await _createHabit.ExecuteAsync(request);

        public async Task UpdateAsync(UpdateHabitRequest request)
            => await _updateHabit.ExecuteAsync(request);

        public async Task DeleteAsync(string habitId)
            => await _deleteHabit.ExecuteAsync(habitId);

        public async Task LogAsync(LogHabitRequest request)
            => await _logHabit.ExecuteAsync(request);

        public async Task CheckAsync(string habitId)
            => await _checkHabit.ExecuteAsync(habitId);

        public async Task<List<HabitDto>> GetTodayHabitsAsync()
            => await _getTodayHabits.ExecuteAsync();

        public async Task<List<HabitDto>> GetUserHabitsAsync()
            => await _getUserHabits.ExecuteAsync();
    }

}
