using Application.UseCases.ACL;
using Application.UseCases.User;

namespace API.DependencyInjection
{
    public static class UseCaseConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<AssignPermissionToUserOnObjectUseCase>();
            services.AddScoped<CheckUserHasPermissionOnObjectUseCase>();

            services.AddScoped<GetAllUserUseCase>();
            services.AddScoped<UpdateUserUseCase>();
            services.AddScoped<GetUserByIdUseCase>();
            services.AddScoped<DeleteUserUseCase>();

            return services;
        }
    }
}
