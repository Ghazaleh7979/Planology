using Application.DTOs;
using Application.Extensions;
using Domain.IRepository;

namespace Application.UseCases.User
{
    public class GetAllUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> ExecuteAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(x => x.ToDto()).ToList();
        }
    }

}
