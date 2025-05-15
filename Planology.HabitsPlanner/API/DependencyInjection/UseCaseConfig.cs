using Application.Helper;
using Application.Interfaces;
using Application.UseCases.Habits;
using Infrastructure.Identity;

namespace API.DependencyInjection
{
    public static class UseCaseConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<HabitService>();
            services.AddScoped<UserSessionStore>();
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, HttpContextCurrentUserService>();

            services.AddScoped<CheckHabitUseCase>();
            services.AddScoped<CreateHabitUseCase>();
            services.AddScoped<DeleteHabitUseCase>();
            services.AddScoped<GetTodayHabitsUseCase>();
            services.AddScoped<GetUserHabitsUseCase>();
            services.AddScoped<LogHabitUseCase>();
            services.AddScoped<UpdateHabitUseCase>();
            return services;
        }
    }
}
