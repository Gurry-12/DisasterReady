using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using DisasterReady.Infrastucture;
using Microsoft.EntityFrameworkCore;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Persistence.Data;

namespace DisasterReady.Infrastucture.ConcreteRepositories
{
    public class AlertRepository : Repository<Alert>, IAlertRepository
    {
        public AlertRepository(DisasterReadyDbContext context) : base(context) { }

        public async Task<IEnumerable<Alert>> GetByDisasterTypeAsync(int disasterTypeId)
        {
            return await _dbSet.Where(a => a.DisasterTypeId == disasterTypeId).ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetBySeverityAsync(SeverityLevelEnum severity)
        {
            return await _dbSet.Where(a => a.SeverityLevel == severity).ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
        {
            return await _dbSet.Where(a => a.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetByRegionAsync(RegionEnum region)
        {
            return await _dbSet.Where(a => a.Region == region).ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 10)
        {
            return await _dbSet.OrderByDescending(a => a.CreatedAt).Take(count).ToListAsync();
        }
    }
} 