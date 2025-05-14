using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Requests;
using Domain.Entities.HabitModels;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class LogHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;
        private readonly IMeasurementUnitRepository _unitRepo;

        public LogHabitUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser,
            UserSessionStore sessionStore,
            IMeasurementUnitRepository unitRepo)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
            _sessionStore = sessionStore;
            _unitRepo = unitRepo;
        }
        public async Task ExecuteAsync(LogHabitRequest request)
        {
            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var habit = await _habitRepo.GetByIdAsync(request.HabitId);
            if (habit == null || habit.UserId != userId)
                throw new UnauthorizedAccessException("You don't have access to this habit.");

            var today = DateTime.UtcNow.Date;

            var existingLog = habit.Logs.FirstOrDefault(l => l.Date == today);
            if (existingLog != null)
            {
                existingLog.Completed = request.Completed;
                existingLog.Amount = request.Amount;
                existingLog.MeasurementUnitId = request.MeasurementUnitId;

                await _habitRepo.ReplaceLogAsync(habit.Id, existingLog);
                return;
            }

            if (request.Amount.HasValue && !string.IsNullOrWhiteSpace(request.MeasurementUnitId))
            {
                var isValidUnit = await _unitRepo.ExistsAsync(request.MeasurementUnitId);
                if (!isValidUnit)
                    throw new ArgumentException("Invalid unit.");
            }

            var log = new HabitLog
            {
                Date = today,
                Completed = request.Completed,
                Amount = request.Amount,
                MeasurementUnitId = request.MeasurementUnitId
            };

            await _habitRepo.AddLogAsync(habit.Id, log);
        }
    }
}
