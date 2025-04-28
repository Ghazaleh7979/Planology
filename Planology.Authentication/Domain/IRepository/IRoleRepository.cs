using Domain.Entities;

namespace Domain.IRepository
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(Guid id);
        Task<Role> GetByNameAsync(string name);
        Task AddAsync(Role role);
    }
}
