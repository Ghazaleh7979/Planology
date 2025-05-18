using Application.DTOs;

namespace Application.Interfaces
{
    public interface ITaskQueryService
    {
        Task<List<MissedTaskDto>> GetMissedTasksAsync(string userId);
    }
}
