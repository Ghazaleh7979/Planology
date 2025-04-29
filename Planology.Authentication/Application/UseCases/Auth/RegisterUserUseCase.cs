using Application.DTOs;
using Application.Requests.Login;
using Application.ServiceInterfaces;

namespace Application.UseCases.Login
{
    public class RegisterUserUseCase
    {
        private readonly IAuthService _authService;

        public RegisterUserUseCase(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(RegisterUserRequest command)
        {
            return await _authService.RegisterAsync(command);
        }
    }
}
