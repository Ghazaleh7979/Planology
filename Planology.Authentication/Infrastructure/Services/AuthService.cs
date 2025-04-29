using Application.DTOs;
using Application.Requests.Login;
using Application.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        private static List<UserDto> _users = new();

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<TokenDto> RegisterAsync(RegisterUserRequest command)
        {
            var hashedPassword = PasswordHasher.HashPassword(command.Password);
            var user = new UserDto
            {
                UserId = Guid.NewGuid(),
                Email = command.Email,
                Password = hashedPassword,
                FullName = command.FullName
            };
            _users.Add(user);

            return await Task.FromResult(_tokenService.GenerateToken(user));
        }

        public async Task<TokenDto> LoginAsync(LoginUserRequest command)
        {
            var user = _users.FirstOrDefault(u => u.Email == command.Email);

            if (user == null || !PasswordHasher.VerifyPassword(user.Password, command.Password))
            {
                throw new Exception("Invalid credentials");
            }

            return await Task.FromResult(_tokenService.GenerateToken(user));
        }

        public async Task<TokenDto> RefreshTokenAsync(RefreshTokenRequest command)
        {
            var user = _users.First();

            return await Task.FromResult(_tokenService.GenerateToken(user));
        }
    }
}
