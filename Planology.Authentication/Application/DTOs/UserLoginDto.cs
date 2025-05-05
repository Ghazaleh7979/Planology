using Domain.ValueObjects;

namespace Application.DTOs
{
    public record UserLoginDto(
        Email? Email,
        string Password
    );
}
