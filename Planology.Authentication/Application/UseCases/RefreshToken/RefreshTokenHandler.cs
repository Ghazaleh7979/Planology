using Application.DTOs;
using Application.ServiceInterfaces;

namespace Application.UseCases.RefreshToken
{
    public class RefreshTokenHandler
    {
        private readonly IAuthService _authService;

        public RefreshTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(RefreshTokenCommand command)
        {
            return await _authService.RefreshTokenAsync(command);
        }
    }
}
