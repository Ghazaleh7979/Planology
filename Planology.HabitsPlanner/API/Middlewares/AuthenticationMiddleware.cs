using Application.Helper;
using Application.Interfaces;

namespace API.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUserService currentUser, UserSessionStore sessionStore)
        {
            var userId = currentUser.UserId;

            if (string.IsNullOrWhiteSpace(userId) || !sessionStore.IsLoggedIn(userId))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("User is not logged in.");
                return;
            }
            await _next(context);
        }
    }

}
