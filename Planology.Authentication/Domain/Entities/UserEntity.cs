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
        public UserEntity(string username, string mobileNumber, string passwordHash, RoleEnum role)
        {
            Id = Guid.NewGuid();
            Username = username;
            MobileNumber = mobileNumber;
            PasswordHash = passwordHash;
            Role = role;
        }
    }

}
