using Application.Requests.ACL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AclController : ControllerBase
    {
        private readonly CheckAccessUseCase _checkAccessUseCase;
        private readonly GrantPermissionUseCase _grantPermissionUseCase;
        private readonly RevokePermissionUseCase _revokePermissionUseCase;

        public AclController(
            CheckAccessUseCase checkAccessUseCase,
            GrantPermissionUseCase grantPermissionUseCase,
            RevokePermissionUseCase revokePermissionUseCase)
        {
            _checkAccessUseCase = checkAccessUseCase;
            _grantPermissionUseCase = grantPermissionUseCase;
            _revokePermissionUseCase = revokePermissionUseCase;
        }

        [Authorize]
        [HttpGet("check-access")]
        public async Task<IActionResult> CheckAccess([FromQuery] string resourceType, [FromQuery] string resourceId, [FromQuery] string permission)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _checkAccessUseCase.ExecuteAsync(new CheckAccessRequest
            {
                UserId = userId,
                ResourceType = resourceType,
                ResourceId = resourceId,
                Permission = permission
            });

            return result ? Ok() : Forbid();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("grant")]
        public async Task<IActionResult> GrantPermission([FromBody] GrantPermissionRequest request)
        {
            await _grantPermissionUseCase.ExecuteAsync(request);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("revoke")]
        public async Task<IActionResult> RevokePermission([FromBody] RevokePermissionRequest request)
        {
            await _revokePermissionUseCase.ExecuteAsync(request);
            return Ok();
        }
    }
}
