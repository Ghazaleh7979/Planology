using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public List<Role> Roles { get; private set; } = new();
        public List<UserPermission> Permissions { get; private set; } = new();

        public User(string username, Email email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }
        public void AddRole(Role role)
        {
            if (!Roles.Contains(role))
                Roles.Add(role);
        }

        public void AddPermission(UserPermission permission)
        {
            Permissions.Add(permission);
        }
    }

}
