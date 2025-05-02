using Application.Requests.Login;
using Application.UseCases.ACL;
using Application.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACLController : ControllerBase
    {
        private readonly CheckUserHasPermissionOnObjectUseCase _checkUserHasPermissionOnObjectUseCase;
        private readonly AssignPermissionToUserOnObjectUseCase _assignPermissionToUserOnObjectUseCase;
        private readonly LoginUserUseCase _loginUserHandler;

        public ACLController(
            CheckUserHasPermissionOnObjectUseCase checkUserHasPermissionOnObjectUseCase,
            AssignPermissionToUserOnObjectUseCase assignPermissionToUserOnObjectUseCase)
        {
            _checkUserHasPermissionOnObjectUseCase = checkUserHasPermissionOnObjectUseCase;
            _assignPermissionToUserOnObjectUseCase = assignPermissionToUserOnObjectUseCase;
        }

        [HttpPost("CheckUserHasPermission")]
        public async Task<IActionResult> CheckUserHasPermission(RegisterUserRequest request)
        {
            var result = await _checkUserHasPermissionOnObjectUseCase.ExecuteAsync(request);
            return Ok(result);
        }

        [HttpPost("AssignPermissionToUser")]
        public async Task<IActionResult> AssignPermissionToUser(LoginUserRequest request)
        {
            var result = await _assignPermissionToUserOnObjectUseCase.ExecuteAsync(request);
            return Ok(result);
        }

    }
}
