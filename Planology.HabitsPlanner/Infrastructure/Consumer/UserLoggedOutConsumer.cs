using Application.Events;
using Application.Helper;
using MassTransit;

namespace Infrastructure.Consumer
{
    public class UserLoggedOutConsumer : IConsumer<UserLoggedOutEvent>
    {
        private readonly UserSessionStore _sessionStore;

        public UserLoggedOutConsumer(UserSessionStore sessionStore)
        {
            _sessionStore = sessionStore;
        }

        public Task Consume(ConsumeContext<UserLoggedOutEvent> context)
        {
            var userId = context.Message.UserId;
            _sessionStore.SetLoggedIn(userId, false);
            return Task.CompletedTask;
        }
    }

}
