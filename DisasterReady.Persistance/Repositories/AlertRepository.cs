using DisasterReady.Persistence.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Data;
using DisasterReady.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace DisasterReady.Persistence.Repositories
{
    public class AlertRepository : Repository<Alert>, IAlertRepository
    {
        public AlertRepository(DisasterReadyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Alert>> GetByDisasterTypeAsync(int disasterTypeId)
        {
            return await _dbSet
                .Include(a => a.DisasterType)
                .Where(a => a.DisasterTypeId == disasterTypeId)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetBySeverityAsync(SeverityLevelEnum severity)
        {
            return await _dbSet
                .Include(a => a.DisasterType)
                .Where(a => a.SeverityLevel == severity)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
        {
            return await _dbSet
                .Include(a => a.DisasterType)
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetByRegionAsync(RegionEnum region)
        {
            return await _dbSet
                .Include(a => a.DisasterType)
                .Where(a => a.Region == region)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 10)
        {
            return await _dbSet
                .Include(a => a.DisasterType)
                .OrderByDescending(a => a.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
} 