using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string username, Email email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }
    }

}
