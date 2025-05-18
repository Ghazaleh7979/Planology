using Application.Events;
using MassTransit;

namespace Infrastructure.Consumer
{
    public class UserLoggedOutConsumer : IConsumer<UserLoggedOutEvent>
    {

        public UserLoggedOutConsumer()
        {
        }

        public Task Consume(ConsumeContext<UserLoggedOutEvent> context)
        {
            var userId = context.Message.UserId;
            return Task.CompletedTask;
        }
    }

}
