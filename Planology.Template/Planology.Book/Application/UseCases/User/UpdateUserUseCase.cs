using Application.DTOs;
using Domain.IRepository;

namespace Application.UseCases.User
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExecuteAsync(string userId, UserDto input)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            await _userRepository.UpdateAsync(user);
            return true;
        }
    }

}
