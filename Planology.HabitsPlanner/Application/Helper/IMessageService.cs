using Application.DTOs;

namespace Application.Helper
{
    public interface IMessageService
    {
        Task SendMissedTasks(string userId, List<MissedTaskDto> missedTasks);
    }
}
