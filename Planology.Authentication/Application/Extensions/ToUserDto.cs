using Application.DTOs;
using Domain.Entities;

namespace Application.Extensions
{
    public static class ToUserDto
    {
        public static UserDto? MapToUserDto(this UserEntity? user)
        {
            if (user == null) return null;
            return new UserDto(user.Id, user.Role, user.Username, user.Email, user.MobileNumber, user.PasswordHash);
        }
    }
}
