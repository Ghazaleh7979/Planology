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

        public LogHabitUseCase()
        {

        }
        public async Task ExecuteAsync(LogHabitRequest request)
        {
            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            if (request.MeasurementUnitId != null && request.Amount == null)
                throw new Exception("لطفا برای واحد مقدار وارد کنید");

            if (request.MeasurementUnitId != null && await _unitRepo.GetByIdAsync(request.MeasurementUnitId!) == null)
                throw new Exception("واحد وارد شده وجود ندارد");

            var log = new HabitLog
            {
                Completed = request.Completed,
                Date = DateTime.UtcNow,
                Amount = request.Amount,
                MeasurementUnitId = request.MeasurementUnitId,
            };
            await _habitRepo.AddLogAsync(request.HabitId, log);
        }
    }
}
