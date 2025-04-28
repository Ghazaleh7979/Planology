using Application.DTOs;
using Application.ServiceInterfaces;

namespace Application.UseCases.RegisterUser
{
    public class RegisterUserHandler
    {
        private readonly IAuthService _authService;

        public RegisterUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(RegisterUserCommand command)
        {
            return await _authService.RegisterAsync(command);
        }
    }
}
