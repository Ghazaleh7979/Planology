using Application;

namespace Domain.Entities
{
    public class AccessControlEntry : BaseEntity
    {
        public string UserId { get; private set; }
        public Guid PermissionResourceTypeId { get; private set; }
        public PermissionEnum Permission { get; private set; }
        public PermissionResourceType? PermissionResourceType { get; private set; }
        public AccessControlEntry(string userId, Guid permissionResourceTypeId, PermissionEnum permission)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PermissionResourceTypeId = permissionResourceTypeId;
            Permission = permission;
        }
    }
}
