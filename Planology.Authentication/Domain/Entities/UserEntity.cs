using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public RoleEnum Role { get; private set; }
        public string Username { get; private set; }
        public Email? Email { get; private set; }
        public string MobileNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public ICollection<AccessControlEntry> AccessControlEntries { get; private set; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; private set; } = [];
        public UserEntity(string username, string mobileNumber, string passwordHash, RoleEnum role, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            MobileNumber = mobileNumber;
            PasswordHash = passwordHash;
            Role = role;
            Email = new Email(email);
        }
    }

}
