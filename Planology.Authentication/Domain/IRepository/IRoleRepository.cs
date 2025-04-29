using Domain.Entities;

namespace Domain.IRepository
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(Guid id);
        Task<Role> GetByNameAsync(string name);
        Task<IEnumerable<Role>> GetAllAsync(); // optional
        Task AddAsync(Role role);

    }
}
