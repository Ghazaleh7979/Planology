using Domain.Enums;

namespace Application.DTOs
{
    public record UserDto(
        RoleEnum Role,
        string Username,
        string Email,
        string MobileNumber,
        string Password
    );
}
