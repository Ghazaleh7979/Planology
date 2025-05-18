using Application.Interfaces;

namespace Application.Extensions
{
    public static class CurrentUserExtensions
    {
        public static string GetCurrentUserId(this ICurrentUserService currentUser)
        {
            var userId = currentUser.UserId;
            if (string.IsNullOrWhiteSpace(userId))
                throw new UnauthorizedAccessException("User ID not found in token.");
            return userId;
        }
    }

}
