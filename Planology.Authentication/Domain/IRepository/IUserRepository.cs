namespace Domain.IRepository
{
    public interface IUserRepository
    {
        //Task<UserEntity> GetByIdAsync(Guid id);
        //Task<UserEntity> GetByEmailAsync(string email);
        //Task<UserEntity> GetByUsernameAsync(string username); // optional
        Task<bool> ExistsByEmailAsync(string email);
        //Task AddAsync(UserEntity user);
        //void Update(UserEntity user);
        //void Delete(UserEntity user);
        // string HashPassword(string password);
    }
}
