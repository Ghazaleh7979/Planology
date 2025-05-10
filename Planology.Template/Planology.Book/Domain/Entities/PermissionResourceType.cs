namespace Domain.Entities
{
    public class PermissionResourceType : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<AccessControlEntry> AccessControlEntries { get; private set; } = new List<AccessControlEntry>();
    }
}
