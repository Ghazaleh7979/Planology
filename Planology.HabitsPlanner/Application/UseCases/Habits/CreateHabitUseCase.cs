using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Application.Requests;
using Domain.Entities.HabitModels;
using Domain.Enums;
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
        public async Task ExecuteAsync(CreateHabitRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Habit name is required.");

            var userId = _currentUser.GetCurrentUserId();
            _currentUser.CheckUserLoggedIn(_sessionStore);
            
            switch (request.HabitTimingEnum)
            {
                case HabitTiming.EveryDay:
                    await CreateEveryDayHabitsAsync(request, userId);
                    break;
                case HabitTiming.DaysOfWeek:
                    if (request.DaysOfWeek.Count == 0)
                        throw new Exception("لطفا روزهای هفته ای که برای این عادت در نظر گرفته اید را انتخاب کنید");
                    await CreateDaysOfWeekHabitsAsync(request, userId);
                    break;
                case HabitTiming.TimesPerWeek:
                    if (request.TimesPerWeek == null || request.TimesPerWeek <= 0)
                        throw new Exception("تعداد روز ها باید بیشتر از صفر باشند");
                    await CreateTimesPerWeekHabitsAsync(request, userId);
                    break;
                default:
                    throw new ArgumentException("");
            }
        }
        public async Task CreateEveryDayHabitsAsync(CreateHabitRequest request, string userId)
        {
            var habit = new Habit
            {
                UserId = userId,
                Name = request.Name,
                Schedule = new HabitSchedule
                {
                    DaysOfWeek = [.. Enum.GetValues<DayOfWeek>()],
                    TimesPerWeek = null
                },
                CreatedAt = DateTime.UtcNow
            };

            await _habitRepo.CreateAsync(habit);
        }
        public async Task CreateDaysOfWeekHabitsAsync(CreateHabitRequest request, string userId)
        {
            var habit = new Habit
            {
                UserId = userId,
                Name = request.Name,
                Schedule = new HabitSchedule
                {
                    DaysOfWeek = request.DaysOfWeek,
                    TimesPerWeek = null
                },
                CreatedAt = DateTime.UtcNow
            };

            await _habitRepo.CreateAsync(habit);
        }
        public async Task CreateTimesPerWeekHabitsAsync(CreateHabitRequest request, string userId)
        {
            var habit = new Habit
            {
                UserId = userId,
                Name = request.Name,
                Schedule = new HabitSchedule
                {
                    DaysOfWeek = new List<DayOfWeek>(),
                    TimesPerWeek = request.TimesPerWeek
                },
                CreatedAt = DateTime.UtcNow
            };

            await _habitRepo.CreateAsync(habit);
        }
    }
}
