using Application.DTOs;

namespace Application.ServiceInterfaces
{
    public interface ITokenService
    {
        TokenDto GenerateToken(UserLoginDto user);
    }
}
