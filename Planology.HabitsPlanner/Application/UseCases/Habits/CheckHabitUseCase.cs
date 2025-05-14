using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Domain.Entities.HabitModels;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class CheckHabitUseCase
    {
        private readonly IHabitRepository _habitRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;
        public CheckHabitUseCase(
            IHabitRepository habitRepository,
            ICurrentUserService currentUser,
            UserSessionStore sessionStore)
        {
            _habitRepository = habitRepository;
            _currentUser = currentUser;
            _sessionStore = sessionStore;
        }
        public async Task ExecuteAsync(string habitId)
        {
            _currentUser.CheckUserLoggedIn(_sessionStore);

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
