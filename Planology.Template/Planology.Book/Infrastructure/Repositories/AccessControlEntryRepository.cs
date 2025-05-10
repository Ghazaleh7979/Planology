using Application;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccessControlEntryRepository : IAccessControlEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public AccessControlEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccessControlEntry>> GetPermissionsAsync(string userId, Guid permissionResourceTypeId)
        {
            return await _context.AccessControlEntries
                .Where(ace => ace.UserId == userId &&
                              ace.PermissionResourceTypeId == permissionResourceTypeId)
                .ToListAsync();
        }

        public async Task AddAsync(AccessControlEntry entry)
        {
            await _context.AccessControlEntries.AddAsync(entry);
        }

        public async Task RemoveAsync(string userId, Guid permissionResourceTypeId, PermissionEnum permission)
        {
            var entry = await _context.AccessControlEntries
                .FirstOrDefaultAsync(ace =>
                    ace.UserId == userId &&
                    ace.PermissionResourceTypeId == permissionResourceTypeId &&
                    ace.Permission == permission);

            if (entry != null)
            {
                _context.AccessControlEntries.Remove(entry);
            }
        }

        public async Task<bool> HasPermissionAsync(string userId, Guid permissionResourceTypeId, PermissionEnum permission)
        {
            return await _context.AccessControlEntries
                  .Where(ace => ace.UserId == userId &&
                  ace.PermissionResourceTypeId == permissionResourceTypeId &&
                  ace.Permission == permission)
                  .AnyAsync();
        }
    }
}
