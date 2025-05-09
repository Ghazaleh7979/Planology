using Domain.IRepository;
using Infrastructure.Repositories;

namespace API.DependencyInjection
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccessControlEntryRepository, AccessControlEntryRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
