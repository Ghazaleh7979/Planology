using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        Task DeleteAsync(string id);
        Task UpdateAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser?> GetByIdAsync(string id);
    }
}
