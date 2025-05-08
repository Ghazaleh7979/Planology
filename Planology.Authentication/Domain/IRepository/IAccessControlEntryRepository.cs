using Application;
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IAccessControlEntryRepository
    {
        Task<List<AccessControlEntry>> GetPermissionsAsync(string userId, Guid permissionResourceTypeId);
        Task AddAsync(AccessControlEntry entry);
        Task RemoveAsync(string userId, Guid permissionResourceTypeId, PermissionEnum permission);
        Task<bool> HasPermissionAsync(string userId, Guid resourceId, PermissionEnum permission);
    }
}
