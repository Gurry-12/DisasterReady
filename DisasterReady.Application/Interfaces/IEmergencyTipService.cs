using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Interfaces
{
    public interface IEmergencyTipService
    {
        Task<IEnumerable<EmergencyTip>> GetAllEmergencyTipsAsync();
        Task<EmergencyTip?> GetEmergencyTipByIdAsync(int id);
        Task<IEnumerable<EmergencyTip>> GetEmergencyTipsByDisasterTypeAsync(DisasterTypeEnum disasterType);
        Task<EmergencyTip> CreateEmergencyTipAsync(EmergencyTip tip);
        Task<bool> DeleteEmergencyTipAsync(int id);
        Task<EmergencyTip?> UpdateEmergencyTipAsync(EmergencyTip tip);
        Task<IEnumerable<EmergencyTip>> GetRandomTipsAsync(int count = 5);
    }
} 