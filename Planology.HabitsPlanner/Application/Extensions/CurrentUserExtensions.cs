using Application.Helper;
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

        public static void CheckUserLoggedIn(this ICurrentUserService currentUser, UserSessionStore session)
        {
            var userId = currentUser.GetCurrentUserId();
            if (!session.IsLoggedIn(userId))
                throw new UnauthorizedAccessException("User is not logged in.");
        }
    }

}
