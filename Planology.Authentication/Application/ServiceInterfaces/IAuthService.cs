using Application.DTOs;
using Application.UseCases.LoginUser;
using Application.UseCases.RefreshToken;
using Application.UseCases.RegisterUser;

namespace Application.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<TokenDto> RegisterAsync(RegisterUserCommand command);
        Task<TokenDto> LoginAsync(LoginUserCommand command);
        Task<TokenDto> RefreshTokenAsync(RefreshTokenCommand command);
    }
}
