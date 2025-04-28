using Domain.IRepository;

namespace Infrastructure.ACL
{
    public class PermissionService
    {
        private readonly IUserRepository _userRepository;

        public PermissionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> HasAccessAsync(Guid userId, string objectType, string action)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            foreach (var role in user.Roles)
            {
                if (role.Permissions.Any(p => p.ObjectType == objectType && p.Action == action))
                    return true;
            }
            return false;
        }
    }
}
