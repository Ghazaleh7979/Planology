using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalR
{
    public class NotificationMessageService : IMessageService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationMessageService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task SendMissedTasks(string userId, List<MissedTaskDto> missedTasks)
        {
            var notification = new MissedTaskNotification
            {
                Tasks = missedTasks
            };

            return _hubContext.Clients.User(userId).SendAsync("ReceiveMissedTasks", notification);
        }
    }
}
