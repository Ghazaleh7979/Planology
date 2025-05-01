using Application;

namespace Domain.Entities
{
    public class AccessControlEntry
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid PermissionResourceTypeId { get; private set; }
        public PermissionResourceType? PermissionResourceType { get; private set; }
        public User? User { get; private set; }
        public PermissionEnum Permission { get; private set; }
        public AccessControlEntry(Guid userId, Guid permissionResourceTypeId, PermissionEnum permission)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PermissionResourceTypeId = permissionResourceTypeId;
            Permission = permission;
        }
    }
}
