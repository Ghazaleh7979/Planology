using Application.DTOs;
using Domain.Entities;

namespace Application.Extensions
{
    public static class UserDtoMapper
    {
        public static UserDto ToDto(this ApplicationUser user)
        {
            return new UserDto(
                Role: user.Role,
                Username: user.UserName,
                Email: user.Email
            );
        }
    }
}
