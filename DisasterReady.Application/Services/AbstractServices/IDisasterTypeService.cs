using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services.AbstractServices
{
    public interface IDisasterTypeService
    {
        Task<IEnumerable<DisasterType>> GetAllDisasterTypesAsync();
        Task<DisasterType?> GetDisasterTypeByIdAsync(int id);
        Task<DisasterType?> GetDisasterTypeByNameAsync(DisasterTypeEnum name);
        Task<IEnumerable<DisasterType>> GetDisasterTypesByRegionAsync(RegionEnum region);
        Task<DisasterType> CreateDisasterTypeAsync(DisasterType disasterType);
        Task<bool> DeleteDisasterTypeAsync(int id);
        Task<DisasterType?> UpdateDisasterTypeAsync(DisasterType disasterType);
    }
} 