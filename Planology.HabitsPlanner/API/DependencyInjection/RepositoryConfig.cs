using Domain.IRepository;
using Infrastructure.Repositories;

namespace API.DependencyInjection
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHabitRepository, HabitRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();

            return services;
        }
    }
}
