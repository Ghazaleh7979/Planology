using Application.Helper;
using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Infrastructure.SignalR;

namespace API.DependencyInjection
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<HabitService>();
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, HttpContextCurrentUserService>();
            services.AddScoped<IMessageService, NotificationMessageService>();
            services.AddScoped<ITaskQueryService, TaskQueryService>();

            return services;
        }
    }
}
