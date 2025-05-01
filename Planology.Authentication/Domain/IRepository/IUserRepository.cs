using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username); // optional
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User user);
        void Update(User user);

    }
}
