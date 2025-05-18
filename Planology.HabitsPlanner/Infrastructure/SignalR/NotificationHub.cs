using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task MoveTasksToToday(List<Guid> taskIds)
        {
            Console.WriteLine("🔁 انتقال تسک‌ها به امروز:");
            foreach (var id in taskIds)
            {
                Console.WriteLine($"✅ Task ID: {id}");
            }

            await Clients.Caller.SendAsync("TasksMovedConfirmation", taskIds);
        }
    }
}
