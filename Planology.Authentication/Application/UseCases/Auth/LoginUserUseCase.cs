using Application.DTOs;
using Application.Requests.Login;
using Application.ServiceInterfaces;

namespace Application.UseCases.Login
{
    public class LoginUserUseCase
    {
        private readonly IAuthService _authService;

        public LoginUserUseCase(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(LoginUserRequest command)
        {
            return await _authService.LoginAsync(command);
        }
    }
}
