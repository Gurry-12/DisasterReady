using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Infrastructure.Repositories.AbstractRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        // Get user by email
        Task<User?> GetByEmailAsync(string email);
        
        // Get users by role
        Task<IEnumerable<User>> GetByRoleAsync(UserRoleEnum role);
        
        // Get users by location
        Task<IEnumerable<User>> GetByLocationAsync(string location);
        
        // Get users subscribed to alerts
        Task<IEnumerable<User>> GetSubscribedUsersAsync();
        
        // Check if email exists
        Task<bool> EmailExistsAsync(string email);
    }
} 