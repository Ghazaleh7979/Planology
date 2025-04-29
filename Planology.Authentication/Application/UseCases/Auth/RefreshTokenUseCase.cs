using Application.DTOs;
using Application.Requests.Login;
using Application.ServiceInterfaces;

namespace Application.UseCases.Login
{
    public class RefreshTokenUseCase
    {
        private readonly IAuthService _authService;

        public RefreshTokenUseCase(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDto> Handle(RefreshTokenRequest command)
        {
            return await _authService.RefreshTokenAsync(command);
        }
    }
}
