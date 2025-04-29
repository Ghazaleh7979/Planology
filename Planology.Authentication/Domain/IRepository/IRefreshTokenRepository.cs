using Domain.Entities;

namespace Domain.IRepository
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenAsync(string token);
        Task<bool> IsValidAsync(string token); // optional
        Task AddAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);
        Task DeleteAllForUserAsync(Guid userId); // optional

    }
}
