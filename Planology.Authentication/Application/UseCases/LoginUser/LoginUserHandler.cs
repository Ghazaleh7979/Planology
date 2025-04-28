using Application.DTOs;
using Application.ServiceInterfaces;

namespace Application.UseCases.LoginUser
{
    public class LoginUserHandler
    {
        private readonly IAuthService _authService;

        public LoginUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(LoginUserCommand command)
        {
            return await _authService.LoginAsync(command);
        }
    }
}
