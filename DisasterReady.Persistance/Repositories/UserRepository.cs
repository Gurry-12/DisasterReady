using DisasterReady.Persistence.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Data;
using DisasterReady.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace DisasterReady.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DisasterReadyDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(u => u.Household)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(UserRoleEnum role)
        {
            return await _dbSet
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByLocationAsync(string location)
        {
            return await _dbSet
                .Where(u => u.Location.Contains(location))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscribedUsersAsync()
        {
            return await _dbSet
                .Where(u => u.IsSubscribedToAlerts)
                .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
} 