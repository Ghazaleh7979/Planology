using Application.Events;
using Application.Helper;
using Application.Interfaces;
using MassTransit;

namespace Infrastructure.Consumer
{
    public class UserLoggedInConsumer : IConsumer<UserLoggedInEvent>
    {
        private readonly IMessageService _messageService;
        private readonly ITaskQueryService _taskQueryService;

        public UserLoggedInConsumer(IMessageService messageService, ITaskQueryService taskQueryService)
        {
            _messageService = messageService;
            _taskQueryService = taskQueryService;
        }

        public async Task Consume(ConsumeContext<UserLoggedInEvent> context)
        {
            var userId = context.Message.UserId;

            var missedTasks = await _taskQueryService.GetMissedTasksAsync(userId);

            if (missedTasks.Count != 0)
            {
                await _messageService.SendMissedTasks(userId, missedTasks);
            }

        }
    }

}
