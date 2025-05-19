using Application.UseCases.Habits;

namespace API.DependencyInjection
{
    public static class UseCaseConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
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
