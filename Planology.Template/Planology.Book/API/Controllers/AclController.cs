using Application.Requests.ACL;
using Application.UseCases.ACL;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACLController : ControllerBase
    {
        private readonly CheckUserHasPermissionOnObjectUseCase _checkUserHasPermissionOnObjectUseCase;
        private readonly AssignPermissionToUserOnObjectUseCase _assignPermissionToUserOnObjectUseCase;

        public ACLController(
            CheckUserHasPermissionOnObjectUseCase checkUserHasPermissionOnObjectUseCase,
            AssignPermissionToUserOnObjectUseCase assignPermissionToUserOnObjectUseCase)
        {
            _checkUserHasPermissionOnObjectUseCase = checkUserHasPermissionOnObjectUseCase;
            _assignPermissionToUserOnObjectUseCase = assignPermissionToUserOnObjectUseCase;
        }

        [HttpPost("CheckUserHasPermission")]
        public async Task<IActionResult> CheckUserHasPermission(CheckPermissionRequest request)
        {
            var result = await _checkUserHasPermissionOnObjectUseCase.ExecuteAsync(request);
            return Ok(result);
        }

        [HttpPost("AssignPermissionToUser")]
        public async Task<IActionResult> AssignPermissionToUser(AssignPermissionRequest request)
        {
            await _assignPermissionToUserOnObjectUseCase.ExecuteAsync(request);
            return Ok();
        }

    }
}
