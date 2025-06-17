using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Interfaces;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services
{
    public class AlertService : IAlertService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Alert>> GetAllAlertsAsync()
        {
            return await _unitOfWork.Alerts.GetAllAsync();
        }

        public async Task<Alert?> GetAlertByIdAsync(int id)
        {
            return await _unitOfWork.Alerts.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Alert>> GetAlertsByDisasterTypeAsync(int disasterTypeId)
        {
            return await _unitOfWork.Alerts.GetByDisasterTypeAsync(disasterTypeId);
        }

        public async Task<IEnumerable<Alert>> GetAlertsBySeverityAsync(SeverityLevelEnum severity)
        {
            return await _unitOfWork.Alerts.GetBySeverityAsync(severity);
        }

        public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
        {
            return await _unitOfWork.Alerts.GetActiveAlertsAsync();
        }

        public async Task<IEnumerable<Alert>> GetAlertsByRegionAsync(RegionEnum region)
        {
            return await _unitOfWork.Alerts.GetByRegionAsync(region);
        }

        public async Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 10)
        {
            return await _unitOfWork.Alerts.GetRecentAlertsAsync(count);
        }

        public async Task<Alert> CreateAlertAsync(Alert alert)
        {
            var createdAlert = await _unitOfWork.Alerts.AddAsync(alert);
            await _unitOfWork.SaveChangesAsync();
            return createdAlert;
        }

        public async Task<bool> DeleteAlertAsync(int id)
        {
            var alert = await _unitOfWork.Alerts.GetByIdAsync(id);
            if (alert == null) return false;
            _unitOfWork.Alerts.Delete(alert);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Alert?> UpdateAlertAsync(Alert alert)
        {
            var existing = await _unitOfWork.Alerts.GetByIdAsync(alert.Id);
            if (existing == null) return null;
            existing.Title = alert.Title;
            existing.Message = alert.Message;
            existing.Location = alert.Location;
            existing.SeverityLevel = alert.SeverityLevel;
            existing.Region = alert.Region;
            existing.IsActive = alert.IsActive;
            existing.DisasterTypeId = alert.DisasterTypeId;
            existing.ExpiresAt = alert.ExpiresAt;
            // Add more fields as needed
            _unitOfWork.Alerts.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }
    }
} 