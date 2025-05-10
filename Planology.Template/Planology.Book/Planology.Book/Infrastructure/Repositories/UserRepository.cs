using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            var identityUser = await _userManager.FindByIdAsync(id);
            return identityUser == null ? null : new ApplicationUser
            {
                Id = identityUser.Id,
                UserName = identityUser.UserName,
                Email = identityUser.Email
            };
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var users = _userManager.Users.ToList();
            return users.Select(u => new ApplicationUser
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            });
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            var identityUser = await _userManager.FindByIdAsync(user.Id);
            if (identityUser == null) return;

            identityUser.UserName = user.UserName;
            identityUser.Email = user.Email;
            await _userManager.UpdateAsync(identityUser);
        }

        public async Task DeleteAsync(string id)
        {
            var identityUser = await _userManager.FindByIdAsync(id);
            if (identityUser == null) return;

            await _userManager.DeleteAsync(identityUser);
        }
    }
}
