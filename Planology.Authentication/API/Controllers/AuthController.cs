using Application.Requests.Login;
using Application.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserHandler;
        private readonly RefreshTokenUseCase _refreshTokenHandler;
        private readonly LoginUserUseCase _loginUserHandler;

        public AuthController(RegisterUserUseCase registerUserHandler, RefreshTokenUseCase refreshTokenHandler, LoginUserUseCase loginUserHandler)
        {
            _registerUserHandler = registerUserHandler;
            _refreshTokenHandler = refreshTokenHandler;
            _loginUserHandler = loginUserHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var result = await _registerUserHandler.Handle(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var result = await _loginUserHandler.Handle(request);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var result = await _refreshTokenHandler.Handle(request);
            return Ok(result);
        }
    }
}
