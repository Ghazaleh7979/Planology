using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs
{
    public record UserDto(
        Guid UserId,
        RoleEnum Role,
        string Username,
        Email? Email,
        string MobileNumber,
        string Password
    );
}
