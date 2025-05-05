using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            var refreshTokens = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token);
            if (refreshTokens == null)
                throw new Exception("");
            return refreshTokens;
        }

        public async Task<bool> IsValidAsync(string token)
        {
            var refreshToken = await GetByTokenAsync(token);
            return refreshToken != null && refreshToken.ExpiryDate > DateTime.UtcNow;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public void Delete(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
        }

        public async Task DeleteAllForUserAsync(Guid userId)
        {
            var tokens = await _context.RefreshTokens.Where(r => r.UserId == userId).ToListAsync();
            _context.RefreshTokens.RemoveRange(tokens);
        }
    }
}
