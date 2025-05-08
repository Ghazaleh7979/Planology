using Application.DTOs;
using Application.Extensions;
using Domain.IRepository;

namespace Application.UseCases.User
{
    public class GetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> ExecuteAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;
            return user.ToDto();
        }
    }

}
