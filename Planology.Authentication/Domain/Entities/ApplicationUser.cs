using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public RoleEnum Role { get; private set; } = RoleEnum.user;
        public ICollection<AccessControlEntry> AccessControlEntries { get; private set; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; private set; } = [];
        public void AddRefreshToken(RefreshToken token)
        {
            RefreshTokens.Add(token);
        }
        public void RevokeRefreshToken(string token)
        {
            var refreshToken = RefreshTokens.FirstOrDefault(rt => rt.Token == token);
            if (refreshToken != null)
            {
                refreshToken.ExpiryDate = DateTime.UtcNow;
            }
        }
        public void SetRole(RoleEnum role)
        {
            Role = role;
        }
    }
}
