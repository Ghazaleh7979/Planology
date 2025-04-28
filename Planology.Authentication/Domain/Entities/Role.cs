namespace Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Permission> Permissions { get; private set; } = new();

        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public void AddPermission(Permission permission)
        {
            Permissions.Add(permission);
        }
    }
}
