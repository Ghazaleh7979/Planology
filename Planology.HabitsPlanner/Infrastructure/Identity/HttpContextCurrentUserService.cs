using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class HttpContextCurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public HttpContextCurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string? UserId =>
            _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? _accessor.HttpContext?.User?.FindFirst("user_id")?.Value;
    }
}
