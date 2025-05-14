using Application.DTOs;
using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Mapper;
using Domain.Entities.HabitModels;
using Domain.IRepository;

namespace Application.UseCases.Habits
{
    public class GetTodayHabitsUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;
        private readonly IMeasurementUnitRepository _unitRepo;

        public GetTodayHabitsUseCase(
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
        public async Task<List<HabitDto>> ExecuteAsync()
        {
            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var startDateOfWeek = DateTime.UtcNow.StartOfWeekFromSaturday();
            var endDateOfWeek = startDateOfWeek.AddDays(6);

            var todayDateOfWeek = DateTime.UtcNow.DayOfWeek;

            var habits = await _habitRepo.GetByUserIdAsync(userId);

            var response = new List<Habit>();
            response.AddRange(habits.Where(hab => hab.Schedule.DaysOfWeek.Contains(todayDateOfWeek)));

            foreach (var item in habits.Where(hab => hab.Schedule.TimesPerWeek != 0).ToList())
            {
                if (item.Logs
                    .Where(log => log.Completed == true && log.Date.IsInCurrentWeekFromSaturday()).Count() 
                    < item.Schedule.TimesPerWeek)
                {
                    response.Add(item);
                }
            }
            return response.Distinct().Select(hab => hab.ToHabitDto()).ToList();
        }
    }
}
