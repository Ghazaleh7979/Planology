using Application.DTOs;
using Application.Requests.Login;

namespace Application.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<TokenDto> RegisterAsync(RegisterUserRequest command);
        Task<TokenDto> LoginAsync(LoginUserRequest command);
        Task<TokenDto> RefreshTokenAsync(RefreshTokenRequest command);
    }
}
