using Application.Events;
using Application.Helper;
using MassTransit;

namespace Infrastructure.Consumer
{
    public class UserLoggedInConsumer : IConsumer<UserLoggedInEvent>
    {
        private readonly UserSessionStore _sessionStore;

        public UserLoggedInConsumer(UserSessionStore sessionStore)
        {
            _sessionStore = sessionStore;
        }

        public Task Consume(ConsumeContext<UserLoggedInEvent> context)
        {
            var userId = context.Message.UserId;
            var loggedIn = context.Message.IsLoggedIn;

            _sessionStore.SetLoggedIn(userId, loggedIn);
            return Task.CompletedTask;
        }
    }

}
