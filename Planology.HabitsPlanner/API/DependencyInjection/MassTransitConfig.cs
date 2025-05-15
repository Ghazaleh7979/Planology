using Application.Helper;
using Infrastructure.Consumer;
using MassTransit;

namespace API.DependencyInjection
{
    public static class MassTransitConfig
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton<UserSessionStore>();
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<UserLoggedInConsumer>();
                cfg.AddConsumer<UserLoggedOutConsumer>();
                cfg.UsingRabbitMq((ctx, cfgRabbit) =>
                {
                    cfgRabbit.Host("localhost", "/", h => {
                        h.Username("guest");
                        h.Password("guest");
                    }); cfgRabbit.ReceiveEndpoint("auth-events", ep =>
                    {
                        ep.ConfigureConsumer<UserLoggedInConsumer>(ctx);
                        ep.ConfigureConsumer<UserLoggedOutConsumer>(ctx);
                    });
                });
            });
            return services;
        }
    }
}
