using Application.DTOs;
using Application.Extensions;
using Domain.Entities;
using Domain.IRepository;

namespace Application.UseCases.User
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> ExecuteAsync(UserDto input)
        {
            var passwordHash = _userRepository.HashPassword(input.Password);
            UserEntity user = new();

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user.MapToUserDto()!;
        }
    }

}
