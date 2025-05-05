using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Value == email);
        }

        public async Task AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
        }
        public string HashPassword(string password)
        {
            return PasswordHasher.HashPassword(password);
        }

        public void Update(UserEntity user)
        {
            _context.Users.Update(user);
        }

        public void Delete(UserEntity user)
        {
            _context.Users.Remove(user);
        }
    }
}
