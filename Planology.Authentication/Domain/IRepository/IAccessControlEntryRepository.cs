using Application;
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IAccessControlEntryRepository
    {
        Task<List<AccessControlEntry>> GetPermissionsAsync(Guid userId, Guid permissionResourceTypeId);
        Task AddAsync(AccessControlEntry entry);
        Task RemoveAsync(Guid userId, Guid permissionResourceTypeId, PermissionEnum permission);
        Task<bool> HasPermissionAsync(Guid userId, Guid resourceId, PermissionEnum permission);
    }
}
